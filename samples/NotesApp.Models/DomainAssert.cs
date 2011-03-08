
using System.Diagnostics;

namespace NotesApp.Models
{
  internal static class DomainAssert
  {
    [DebuggerStepThrough]
    [DebuggerHidden]
    [Conditional("DEBUG")]
    public static void NotNullOrEmpty(string str, string rationale)
    {
      if (string.IsNullOrEmpty(str))
        throw new DomainException(rationale);
    }
  }
}
