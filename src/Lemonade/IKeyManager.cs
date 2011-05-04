
using System;

namespace Lemonade
{
  // TODO: Work out the relationship between object Ids and keys
  public interface IKeyManager
  {
    string GetObjectKey(object obj);

    string GetRootKey();
    string GetChildKey(Type childType, string parentKey, string childName);
  }
}
