
using System;
using Lemonade.Conventions;

namespace Lemonade
{
  public class KeyManager : IKeyManager
  {
    private IIdConvention _convention;
    private string _keySeparator;
    private string _keyPrefix;
    private string _rootKey;

    public KeyManager(Configuration config)
    {
      _convention = config.GetConventionOrDefault<IIdConvention>(
        new HashCodeIdConvention());

      _keySeparator = config.KeySeparator;
      _keyPrefix = config.KeyPrefix;
      _rootKey = config.RootKey;
    }


    public string GetObjectKey(object obj)
    {
      return stitch(_keyPrefix, _convention.GetObjectId(obj));
    }

    public string GetRootKey()
    {
      return stitch(_keyPrefix, _rootKey);
    }

    public string GetChildKey(Type childType, string parentKey, string childName)
    {
      return stitch(parentKey, childName);
    }


    private string stitch(params string[] keys)
    {
      return string.Join(_keySeparator, keys);
    }
  }
}
