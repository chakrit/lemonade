
using Sider;

namespace Lemonade
{
  public class ObjectClientsPool : ThreadwisePool<object>
  {
    // TODO: Make IClientsPool in Sider expose the settings
    private RedisSettings _settings;

    public ObjectClientsPool(RedisSettings settings) :
      base(settings)
    {
      _settings = settings;
    }


    protected override IRedisClient<object> BuildClient()
    {
      return new ObjectClient(_settings);
    }
  }
}
