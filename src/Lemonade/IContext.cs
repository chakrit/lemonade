
using System.Collections.Generic;
using Lemonade.Conventions;
using Sider;

namespace Lemonade
{
  public interface IContext
  {
    IClientsPool<object> ClientsPool { get; }
    IKeyManager Keys { get; }

    IEnumerable<IConvention> Conventions { get; }
  }
}
