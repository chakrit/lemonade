
namespace Lemonade.Conventions
{
  public class HashCodeIdConvention : IIdConvention
  {
    public string GetObjectId<T>(T obj)
    {
      return obj.GetHashCode().ToString();
    }
  }
}
