
using System.Collections.Generic;

namespace Lemonade.Implementations
{
  public class SimpleList<T> : ContextWrapper, IList<T>
  {
    public T this[int index]
    {
      get { throw new System.NotImplementedException(); }
      set { throw new System.NotImplementedException(); }
    }


    public SimpleList(IContext context, string key) :
      base(context, key)
    {
    }

    public int IndexOf(T item)
    {
      throw new System.NotImplementedException();
    }

    public void Insert(int index, T item)
    {
      throw new System.NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new System.NotImplementedException();
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

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
