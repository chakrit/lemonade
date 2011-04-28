
namespace Lemonade
{
  public interface IShimManager
  {
    // returns wether we should use a shim-based implementation
    // e.g. List<string> -> should just store string directly without shims
    //      List<MyClass> -> should use shims (list store only object IDs)
    //
    // maybe needs to integrate this into IImplSelector and provide
    // 2 impls for each collection type, one that use shim and one that's not.
    bool ShouldUseShim<T>();

    T GetRealValue<T>();
    T GetValueToStore();
  }
}
