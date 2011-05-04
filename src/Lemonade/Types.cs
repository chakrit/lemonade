
using System;

namespace Lemonade
{
  internal static class Types
  {
    public static bool IsSimpleType(Type t)
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
