
namespace Lemonade
{
  public interface IImplBuilder
  {
    T BuildImplementationFor<T>(IContext context, string key) where T : class;
  }
}
