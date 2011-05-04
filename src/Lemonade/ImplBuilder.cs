
using System;
using System.Collections.Generic;
using Lemonade.Implementations;

namespace Lemonade
{
  public class ImplBuilder : IImplBuilder
  {
    private Configuration _config;

    public ImplBuilder(Configuration config)
    {
      _config = config;
    }


    public Func<object> GetActivatorFor(Type type, IContext context, string key)
    {
      if (Types.IsSimpleType(type))
        return null; // doesn't support building simple types

      if (type == typeof(ICounter))
        return () => new Counter(context, key);

      if (type.IsGenericType) {
        var genericDef = type.GetGenericTypeDefinition();
        var genericArg = type.GetGenericArguments()[0];

        if (genericDef == typeof(IList<>)) {
          var listType = Types.IsSimpleType(genericArg) ?
            typeof(SimpleList<>).MakeGenericType(genericArg) :
            typeof(ComplexList<>).MakeGenericType(genericArg);

          return () => Activator.CreateInstance(listType, context, key);
        }

        if (genericDef == typeof(ISet<>)) {
          var setType = Types.IsSimpleType(genericArg) ?
            typeof(SimpleSet<>).MakeGenericType(genericArg) :
            typeof(ComplexSet<>).MakeGenericType(genericArg);

          return () => Activator.CreateInstance(setType, context, key);
        }
      }

      // un-supported type
      if (type.IsInterface)
        return () => context
          .Proxies
          .CreateInterfaceProxyWithoutTarget(type, new HashInterceptor(context, key));

      return () => context
        .Proxies
        .CreateClassProxy(type, new HashInterceptor(context, key));
    }
  }
}
