
using System;
using Sider;

namespace Lemonade
{
  public abstract class RedisClientWrapper<T> : IDisposable
  {
    protected IRedisClient<T> Client { get; private set; }

    protected RedisClientWrapper(IRedisClient<T> client)
    {
      Client = client;
    }
  }
}
