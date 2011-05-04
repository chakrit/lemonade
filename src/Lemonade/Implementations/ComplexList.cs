
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lemonade.Implementations
{
  internal class ComplexList<T> : ContextWrapper, IList<T>
  {
    public bool IsReadOnly { get { return false; } }

    public int Count { get { return Client.LLen(Key); } }

    public T this[int index]
    {
      get { return (T)Client.Get((string)Client.LIndex(Key, index)); }
      set
      {
        var objKey = Keys.GetObjectKey(value);
        Client.Pipeline(c =>
        {
          c.Set(objKey, value);
          c.LSet(Key, index, objKey);
        });
      }
    }


    public ComplexList(IContext context, string listKey) :
      base(context, listKey) { }


    public int IndexOf(T item)
    {
      // no natively supported command,
      // may needs a proper indexing system first
      throw new NotSupportedException();
    }

    public void Insert(int index, T item)
    {
      // not sure if repeating this until
      // the transaction succeeds is really a good idea
      UntilTrue(() =>
      {
        Client.Watch(Key);
        var before = Client.LIndex(Key, index);

        Client.Multi();
        Client.LInsert(Key, before, item, afterPivot: false);
        return Client.Exec().Any();
      });
    }

    public void RemoveAt(int index)
    {
      UntilTrue(() =>
      {
        Client.Watch(Key);
        var item = Client.LIndex(Key, index);

        Client.Multi();
        Client.LRem(Key, 1, item);
        return Client.Exec().Any();
      });
    }

    public void Add(T item)
    {
      var objKey = Keys.GetObjectKey(item);
      Client.Pipeline(c =>
      {
        c.Set(objKey, item);
        c.RPush(Key, objKey);
      });
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
        .Cast<string>()
        .Select(itemKey => Implementations.GetActivatorFor(typeof(T), Context, itemKey))
        .Select(act => act())
        .Cast<T>()
        .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
