
namespace Lemonade
{
  public interface IKeyFilter
  {
    string ToKey(object incomingObject);
    T ToObject<T>(string outgoingKey);
  }
}
