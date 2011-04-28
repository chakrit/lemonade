
namespace Lemonade
{
  public interface IKeyManager
  {
    string GetRootKey();
    string GetKey<T>(string objId);
  }
}
