
namespace NotesApp.Models.Repositories
{
  public abstract class RepositoryBase : IRepository
  {
    public IDomainRoot Root { get; set; }


    public virtual void Dispose()
    {
      // no-op
    }
  }
}
