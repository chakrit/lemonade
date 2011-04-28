
using System;
namespace Lemonade
{
  public abstract class ContextWrapper
  {
    private IContext _context;
    private string _key;

    protected string Key { get { return _key; } }

    protected ObjectClient Client { get { return _context.Client; } }
    protected IKeyManager Keys { get { return _context.Keys; } }

    protected ContextWrapper(IContext context, string key)
    {
      _context = context;
      _key = key;
    }


    protected void UntilTrue(Func<bool> work)
    {
      // save from having to repeat `bool success = false; do while (success) { }`
      // splatterred everywhere and so we can put in a better transaction
      // control in the future
      while (!work()) ;
    }
  }
}
