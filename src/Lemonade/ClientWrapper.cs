
using System;

namespace Lemonade
{
  public abstract class ClientWrapper : IDisposable
  {
    protected ObjectClient Client { get; private set; }
    protected string Key { get; private set; }

    protected ClientWrapper(ObjectClient client, string key)
    {
      Client = client;
    }
  }
}
