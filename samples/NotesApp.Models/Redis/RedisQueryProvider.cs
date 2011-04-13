
using System.Linq;

namespace NotesApp.Models.Redis
{
  public class RedisQueryProvider : IQueryProvider
  {
    public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
    {
      throw new System.NotImplementedException();
    }

    public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
    {
      throw new System.NotImplementedException();
    }

    public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
    {
      throw new System.NotImplementedException();
    }

    public object Execute(System.Linq.Expressions.Expression expression)
    {
      throw new System.NotImplementedException();
    }
  }
}
