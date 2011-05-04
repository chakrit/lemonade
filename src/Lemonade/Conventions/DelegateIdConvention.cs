
using System;

namespace Lemonade.Conventions
{
  public class DelegateIdConvention : IIdConvention
  {
    private Func<object, string> _func;

    public DelegateIdConvention(Func<object, string> idFunc)
    {
      _func = idFunc;
    }


    public string GetObjectId<T>(T obj)
    {
      return _func(obj);
    }
  }
}
