
using System;

namespace Lemonade
{
  // TODO: Rename to proxy manager?
  // TODO: Implement proper unit of work?
  public interface IImplBuilder
  {
    // TODO: Prevent boxing?
    Func<object> GetActivatorFor(Type type, IContext context, string key);

    // TODO: Manage incoming implementations
    //       i.e. persist them or make reference checks etc.
    void AcceptIncomingObject(Type type, object obj);
  }
}
