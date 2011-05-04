
using System;
using Castle.DynamicProxy;

namespace Lemonade
{
  public interface IContext : IDisposable
  {
    Configuration Config { get; }
    ObjectClient Client { get; }

    IKeyManager Keys { get; }
    IImplBuilder Implementations { get; }
    ProxyGenerator Proxies { get; }

    T GetRoot<T>() where T : class;
  }
}
