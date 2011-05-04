
using Sider;

namespace Lemonade
{
  public class ObjectClientsPool : ThreadwisePool<object>
  {
    public ObjectClientsPool(RedisSettings settings) :
      base(settings) { }


    protected override IRedisClient<object> BuildClient()
    {
      return new ObjectClient(Settings);
    }
  }
}
