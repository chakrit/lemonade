
using Castle.DynamicProxy;

namespace Lemonade
{
  internal class Context : IContext
  {
    public Configuration Config { get; private set; }
    public ObjectClient Client { get; private set; }

    public IKeyManager Keys { get; private set; }
    public IImplBuilder Implementations { get; private set; }
    public ProxyGenerator Proxies { get; private set; }


    public Context(Configuration config, ObjectClient client,
      IKeyManager keyMgr, IImplBuilder implSelector, ProxyGenerator proxyGen)
    {
      Config = config;
      Client = client;

      Keys = keyMgr;
      Implementations = implSelector;
      Proxies = proxyGen;
    }


    public T GetRoot<T>() where T : class
    {
      return (T)Implementations
        .GetActivatorFor(typeof(T), this, Keys.GetRootKey())
        .Invoke();
    }


    public void Dispose()
    {
      // don't dispose Client here because it's managed by a pool
    }
  }
}
