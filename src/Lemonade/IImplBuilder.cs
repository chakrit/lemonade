
using System;

namespace Lemonade
{
  public interface IImplBuilder
  {
    // TODO: Prevent boxing?
    Func<object> GetActivatorFor(Type type, IContext context, string key);
  }
}
