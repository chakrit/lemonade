
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


    public T BuildImplementationFor<T>(IContext context, string key)
      where T : class
    {
      var type = typeof(T);
      if (isSimpleType(type))
        throw new ArgumentException("Cannot build implementation for simple types.");

      if (type == typeof(ICounter))
        return (T)(object)new Counter(context, key);

      if (type.IsGenericTypeDefinition) {
        var genericType = type.GetGenericTypeDefinition();
        var genericArg = genericType.GetGenericArguments()[0];

        if (genericType == typeof(IList<>)) {
          var listType = isSimpleType(genericArg) ?
            typeof(SimpleList<>).MakeGenericType(genericArg) :
            typeof(ComplexList<>).MakeGenericType(genericArg);

          return (T)Activator.CreateInstance(listType, context, key);
        }

        if (genericType == typeof(ISet<>)) {
          var setType = isSimpleType(genericArg) ?
            typeof(SimpleSet<>).MakeGenericType(genericArg) :
            typeof(ComplexSet<>).MakeGenericType(genericArg);

          return (T)Activator.CreateInstance(setType, context, key);
        }
      }

      // interface types, build an interceptor
      if (type.IsInterface) {
        return (T)context.Proxies.CreateInterfaceProxyWithoutTarget(
          type, new HashInterceptor(context, key));

      }
      else { // poco?
        // TODO: Proxiability check.
        return (T)context.Proxies.CreateClassProxy(type,
          new HashInterceptor(context, key));
      }


      //throw new NotSupportedException(string.Format(
      //  "There is no supporting implementation for type {0}.",
      //  typeof(T).FullName));
    }


    private bool isSimpleType(Type t)
    {
      if (t == typeof(string) ||
        t == typeof(byte) ||
        t == typeof(sbyte) ||
        t == typeof(int) ||
        t == typeof(uint) ||
        t == typeof(short) ||
        t == typeof(ushort) ||
        t == typeof(long) ||
        t == typeof(ulong) ||
        t == typeof(float) ||
        t == typeof(double) ||
        t == typeof(decimal) ||
        t == typeof(char) ||
        t == typeof(bool))
        return true;

      return false;
    }
  }
}
