
using Sider;

namespace Lemonade
{
  public sealed class Configuration
  {
    public string Host { get; private set; }
    public int Port { get; private set; }

    private Configuration()
    {
      Host = RedisSettings.Default.Host;
      Port = RedisSettings.Default.Port;
    }

    public static Builder New() { return new Builder(); }
    public Builder CopyNew() { return new Builder(this); }


    public RedisSettings GetRedisSettings()
    {
      return RedisSettings.New()
        .Host(Host)
        .Port(Port);
    }


    public class Builder
    {
      private Configuration _settings;

      public Builder() { _settings = new Configuration(); }
      public Builder(Configuration settings) { _settings = settings; }

      public static implicit operator Configuration(Builder b)
      {
        return b._settings;
      }


      public Builder Host(string host)
      {
        _settings.Host = host;
        return this;
      }

      public Builder Port(int port)
      {
        _settings.Port = port;
        return this;
      }
    }
  }
}
