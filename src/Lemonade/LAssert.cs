
using System;

namespace Lemonade
{
  public static class LAssert
  {
    public static void OperationSuccess(bool check,
      Func<Exception> exceptionIfFalse)
    {
      if (!check)
        throw exceptionIfFalse();
    }
  }
}
