
using System;
using Castle.Core.Interceptor;

namespace Lemonade
{
  internal class RedisHashInterceptor : ContextWrapper, IInterceptor
  {
    public RedisHashInterceptor(IContext context, string key) : base(context, key) { }


    void IInterceptor.Intercept(IInvocation invocation)
    {
      if (!isSetter(invocation) && !isGetter(invocation))
        throw new NotSupportedException(
          "Only getters and setters are supported, for now.");


      if (invocation.Method.ReturnType == typeof(string)) {
        if (isSetter(invocation))
          Client.Set(Key, invocation.Arguments[0]);
        else if (isGetter(invocation))
          invocation.ReturnValue = Client.Get(Key);
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
  }
}
