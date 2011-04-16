
using System.Collections;
using System.Collections.Generic;
using Sider;

namespace Lemonade
{
  public class RedisList<T> : RedisClientWrapper<T>, IList<T>
  {
    public RedisList(IRedisClient<T> client, string key) :
      base(client, key)
    {
      // asserts?
    }


    public int IndexOf(T item)
    {
      return Client.LIndex(
    }

    public void Insert(int index, T item)
    {
      throw new System.NotImplementedException();
    }

    public void RemoveAt(int index)
    {
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
