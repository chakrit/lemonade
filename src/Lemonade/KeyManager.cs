
namespace Lemonade
{
  public class KeyManager : IKeyManager
  {
    public string GetNewTypedKey<T>()
    {
      return typeof(T).Name
    }
  }
}
