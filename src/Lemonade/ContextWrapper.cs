
using System;
using Castle.DynamicProxy;

namespace Lemonade
{
  public abstract class ContextWrapper
  {
    private IContext _context;
    private string _key;


    protected IContext Context { get { return _context; } }

    protected ObjectClient Client { get { return _context.Client; } }
    protected string Key { get { return _key; } }

    protected IImplBuilder Implementations { get { return _context.Implementations; } }
    protected ProxyGenerator Proxies { get { return _context.Proxies; } }
    protected IKeyManager Keys { get { return _context.Keys; } }

    protected ContextWrapper(IContext context, string key)
    {
      _context = context;
      _key = key;
    }


    protected void UntilTrue(Func<bool> work)
    {
      // save from having to repeat `bool success = false; do while (success) { }`
      // splatterred everywhere and so we can put in a better transaction
      // control in the future
      while (!work()) ;
    }
  }
}
