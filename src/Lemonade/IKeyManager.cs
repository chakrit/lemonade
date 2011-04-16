
using System;

namespace Lemonade
{
  public interface IKeyManager
  {
    string GetNewTypedKey<T>();

    bool IsValidType(string key, Type t);
    Type GetKeyType(string key);
  }
}
