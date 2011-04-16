
using Sider;

namespace Lemonade
{
  public interface ILemonadeFactory
  {
    IKeyManager Keys { get; }
    IClientsPool<object> ClientsPool { get; }

    T BuildRootObject<T>();
  }
}
