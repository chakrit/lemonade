
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lemonade.Implementations
{
  public class SimpleList<T> : ContextWrapper, IList<T>
  {
    public bool IsReadOnly { get { return false; } }

    public int Count { get { return Client.LLen(Key); } }

    public T this[int index]
    {
      get { return (T)Client.LIndex(Key, index); }
      set { Client.LSet(Key, index, value); }
    }


    public SimpleList(IContext context, string key) :
      base(context, key) { }


    public int IndexOf(T item)
    {
      throw new System.NotSupportedException();
    }

    public void Insert(int index, T item)
    {
      UntilTrue(() =>
      {
        Client.Watch(Key);
        var pivot = Client.LIndex(Key, index);

        Client.Multi();
        Client.LInsert(Key, pivot, item);
        return Client.Exec().Any();
      });
    }

    public void RemoveAt(int index)
    {
      UntilTrue(() =>
      {
        Client.Watch(Key);
        var pivot = Client.LIndex(Key, index);

        Client.Multi();
        Client.LRem(Key, 1, pivot);
        return Client.Exec().Cast<int>().SingleOrDefault() == 1;
      });
    }

    public void Add(T item)
    {
      Client.RPush(Key, item);
    }

    public void Clear()
    {
      Client.Del(Key);
    }

    public bool Contains(T item)
    {
      throw new System.NotSupportedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      // TODO: Optimize
      var src = this.ToArray();
      for (var i = 0; i < src.Length; i++, arrayIndex++)
        array[arrayIndex] = src[i];
    }

    public bool Remove(T item)
    {
      return Client.LRem(Key, 1, item) == 1;
    }


    public IEnumerator<T> GetEnumerator()
    {
      return Client
        .LRange(Key, 0, -1)
        .Cast<T>()
        .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
