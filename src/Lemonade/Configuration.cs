
using System;
using System.Collections.Generic;
using System.Linq;
using Lemonade.Conventions;
using Sider;

namespace Lemonade
{
  public sealed class Configuration
  {
    private static Configuration _default = new Configuration();

    public static Configuration Default { get { return _default; } }


    public string Host { get; private set; }
    public int Port { get; private set; }

    public string KeyPrefix { get; private set; }
    public string KeySeparator { get; private set; }
    public string RootKey { get; private set; }

    public ICollection<IConvention> ConventionOverrides { get; private set; }

    private Configuration()
    {
      Host = RedisSettings.Default.Host;
      Port = RedisSettings.Default.Port;

      KeySeparator = ":";
      KeyPrefix = "lemon" + KeySeparator;
      RootKey = "root";

      ConventionOverrides = Array.AsReadOnly(new IConvention[] { });
    }

    public static Builder New() { return new Builder(); }
    public Builder CopyNew() { return new Builder(this); }


    public RedisSettings GetRedisSettings()
    {
      return RedisSettings.New()
        .Host(Host)
        .Port(Port);
    }

    public T GetConventionOrDefault<T>(T defaultConvention)
      where T : class, IConvention
    {
      return ConventionOverrides
        .OfType<T>()
        .LastOrDefault() ?? defaultConvention;
    }


    public class Builder
    {
      private Configuration _settings;
      private IList<IConvention> _conventions;

      public Builder() { _settings = new Configuration(); }
      public Builder(Configuration settings) { _settings = settings; }

      public static implicit operator Configuration(Builder b) { return b.Build(); }

      public Configuration Build()
      {
        if (_conventions != null)
          _settings.ConventionOverrides = Array.AsReadOnly(_conventions.ToArray());

        return _settings;
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

      public Builder KeyPrefix(string prefix)
      {
        _settings.KeyPrefix = prefix;
        return this;
      }

      public Builder RootKey(string rootKey)
      {
        _settings.RootKey = rootKey;
        return this;
      }

      public Builder OverrideConvention(IConvention convention)
      {
        _conventions = _conventions ?? new List<IConvention>();
        _conventions.Add(convention);
        return this;
      }
    }
  }
}
