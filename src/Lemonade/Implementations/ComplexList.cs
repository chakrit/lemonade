
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lemonade.Implementations
{
  internal class ComplexList<T> : ContextWrapper, IList<T>
  {
    private IContext _context;
    private string _listKey;

    public ComplexList(IContext context, string listKey) :
      base(context, listKey)
    {
      _context = context;
      _listKey = listKey;
    }


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
        return Client.Exec().Single<int>() != -1;
      });
    }

    public void RemoveAt(int index)
    {
      Client.LRem(
      throw new System.NotImplementedException();
    }

    public T this[int index]
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
        throw new System.NotImplementedException();
      }
    }

    public void Add(T item)
    {
      throw new System.NotImplementedException();
    }

    public void Clear()
    {
      throw new System.NotImplementedException();
    }

    public bool Contains(T item)
    {
      throw new System.NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      throw new System.NotImplementedException();
    }

    public int Count
    {
      get { throw new System.NotImplementedException(); }
    }

    public bool IsReadOnly
    {
      get { throw new System.NotImplementedException(); }
    }

    public bool Remove(T item)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
