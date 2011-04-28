
using System.Collections.Generic;
using System.Linq;

namespace Lemonade
{
  public static class ObjectEnumExtensions
  {
    public static TElem Single<TElem>(this IEnumerable<object> enumerable)
    {
      return (TElem)enumerable.Single();
    }
  }
}
