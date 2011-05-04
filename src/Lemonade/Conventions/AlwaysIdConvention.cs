
using System.Reflection;

namespace Lemonade.Conventions
{
  public class AlwaysIdConvention : IIdConvention
  {
    public string GetObjectId<T>(T obj)
    {
      return typeof(T)
        .GetProperty("Id", BindingFlags.Public | BindingFlags.Instance)
        .GetValue(obj, null)
        .ToString();
    }
  }
}
