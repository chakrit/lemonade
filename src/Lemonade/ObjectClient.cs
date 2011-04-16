
using Sider;

namespace Lemonade
{
  public class ObjectClient : RedisClient<object>
  {
    public ObjectClient(RedisSettings settings) : base(settings) { }
  }
}
