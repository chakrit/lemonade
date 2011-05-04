
using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace Lemonade.Implementations
{
  // TODO: Cache built implementations
  internal class HashInterceptor : ContextWrapper, IInterceptor
  {
    private IDictionary<string, object> _implCache;

    public HashInterceptor(IContext context, string key) :
      base(context, key)
    {
      _implCache = _implCache ?? new Dictionary<string, object>();
    }


    void IInterceptor.Intercept(IInvocation invocation)
    {
      var returnType = invocation.Method.ReturnType;
      var memberName = getName(invocation);

      // if already implemented this once, return the cached implementation
      object output;
      if (_implCache.TryGetValue(memberName, out output)) {
        invocation.ReturnValue = output;
        return;
      }


      // else check wether it's a simple value or an implementation should be built
      if (!isSetter(invocation) && !isGetter(invocation))
        return;

      // if supported type (e.g. IList or ISet) build an implementation for the type
      var objKey = Keys.GetChildKey(returnType, Key, memberName);
      var activator = Implementations.GetActivatorFor(returnType, Context, objKey);

      if (isGetter(invocation) && activator != null) {
        invocation.ReturnValue = _implCache[memberName] = activator.Invoke();
        Client.HSet(Key, memberName, objKey);
        return;
      }

      // unsupported type, just store it directly without extra translation layer
      // store values directly for simple types
      if (Types.IsSimpleType(returnType)) {
        if (isSetter(invocation)) {
          Client.HSet(Key, memberName, invocation.Arguments[0]);
          invocation.ReturnValue = invocation.Arguments[0];
        }
        else if (isGetter(invocation)) {
          invocation.ReturnValue = Client.HGet(Key, memberName);
        }

        return;
      }

      // complex types, use another key for storing it
      if (isSetter(invocation)) {
        var value = invocation.Arguments[0];
        objKey = Keys.GetObjectKey(value);
        Client.Pipeline(c =>
        {
          c.Set(objKey, value);
          c.HSet(Key, memberName, objKey);
        });
      }
      else if (isGetter(invocation)) {
        objKey = (string)Client.HGet(Key, memberName);
        invocation.ReturnValue = Client.Get(objKey);
      }

    }


    private bool isSetter(IInvocation invocation)
    {
      return invocation.Method.IsSpecialName &&
        invocation.Method.Name.StartsWith("set_");
    }

    private bool isGetter(IInvocation invocation)
    {
      return invocation.Method.IsSpecialName &&
        invocation.Method.Name.StartsWith("get_");
    }

    private string getName(IInvocation invocation)
    {
      // remove the get_ and set_ prefix
      return invocation.Method.Name.Substring("set_".Length);
    }
  }
}
