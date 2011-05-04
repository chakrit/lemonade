
using System.Reflection;

namespace Lemonade.Conventions
{
  public interface IIgnoreConvention : IConvention
  {
    bool ShouldIgnore(MemberInfo member);
  }
}
