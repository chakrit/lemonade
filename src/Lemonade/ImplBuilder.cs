
using System;
using System.Collections.Generic;

namespace Lemonade
{
  public class ImplBuilder : IImplBuilder
  {
    private Configuration _config;

    public ImplBuilder(Configuration config)
    {
      _config = config;
    }


    public T BuildImplementationFor<T>(IContext context, string key)
      where T : class
    {
      var type = typeof(T);

      if (type == typeof(ICounter))
        return (T)(object)new CounterImpl(context, key);

      if (type.IsGenericTypeDefinition) {
        var genericType = type.GetGenericTypeDefinition();
        var genericArg = genericType.GetGenericArguments()[0];

        if (genericType == typeof(IList<>)) {
          var listType = typeof(RedisList<>)
            .MakeGenericType(genericArg);

          return (T)Activator.CreateInstance(listType, context, key);
        }

        if (genericType == typeof(ISet<>)) {
          var setType = typeof(RedisSet<>)
            .MakeGenericType(genericArg);

          return (T)Activator.CreateInstance(setType, context, key);
        }
      }


      throw new NotSupportedException(string.Format(
        "There is no supporting implementation for type {0}.",
        typeof(T).FullName));
    }
  }
}
