
namespace Lemonade.Conventions
{
  public interface IIdConvention : IConvention
  {
    string GetObjectId<T>(T obj);
  }
}
