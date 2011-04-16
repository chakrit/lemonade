
namespace Lemonade
{
  public interface ILemonadeFactory
  {
    IContext BuildContext();
    T BuildProxy<T>();
  }
}
