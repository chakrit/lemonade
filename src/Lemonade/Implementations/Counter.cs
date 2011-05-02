
namespace Lemonade.Implementations
{
  internal class Counter : ContextWrapper, ICounter, ICounter64
  {
    public Counter(IContext context, string key) :
      base(context, key) { }


    public int GetValue() { return (int)Client.IncrBy(Key, 0); }

    public int Increment() { return (int)Client.Incr(Key); }
    public int Decrement() { return (int)Client.Decr(Key); }


    long ICounter64.GetValue() { return Client.IncrBy(Key, 0); }

    long ICounter64.Increment() { return Client.Incr(Key); }
    long ICounter64.Decrement() { return Client.Decr(Key); }
  }
}
