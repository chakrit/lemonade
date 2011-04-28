
namespace Lemonade
{
  public class KeyManager : IKeyManager
  {
    private Configuration _config;

    public KeyManager(Configuration config) { _config = config; }


    public string GetRootKey()
    {
      return stitch(_config.KeyPrefix, _config.RootKey);
    }

    public string GetKey<T>(string objId)
    {
      return stitch(_config.KeyPrefix, "objs", objId);
    }


    private string stitch(params string[] keys)
    {
      return string.Join(_config.KeySeparator, keys);
    }
  }
}
