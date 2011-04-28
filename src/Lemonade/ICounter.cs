
namespace Lemonade
{
  public interface ICounter
  {
    int GetValue();

    int Increment();
    int Decrement();
  }

  public interface ICounter64
  {
    long GetValue();

    long Increment();
    long Decrement();
  }
}
