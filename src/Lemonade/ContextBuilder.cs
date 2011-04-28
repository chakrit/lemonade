
using System;
using Castle.DynamicProxy;
using Sider;

namespace Lemonade
{
  public class ContextBuilder
  {
    private Configuration _config;
    private RedisSettings _redisConfig;

    private ObjectClientsPool _clientsPool;
    private IKeyManager _keys;
    private IImplBuilder _implSelector;
    private ProxyGenerator _proxyGen;


    public ContextBuilder() : this(Configuration.Default) { }

    public ContextBuilder(Func<Configuration.Builder, Configuration> configAction) :
      this(configAction(Configuration.New())) { }

    public ContextBuilder(Configuration config)
    {
      _config = config;
      _redisConfig = _config.GetRedisSettings();

      _clientsPool = new ObjectClientsPool(_redisConfig);
      _keys = new KeyManager(_config);
      _proxyGen = new ProxyGenerator();
      _implSelector = new ImplBuilder(_config);
    }


    public IContext NewContext()
    {
      var context = new Context(
      config: _config,
      client: (ObjectClient)_clientsPool.GetClient(),
      keyMgr: _keys,
      implSelector: _implSelector,
      proxyGen: _proxyGen);

      return context;
    }

    public T GetRoot<T>() where T : class
    {
      return NewContext().GetRoot<T>();
    }
  }
}
