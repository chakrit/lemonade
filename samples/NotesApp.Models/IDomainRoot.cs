
using System.Collections.Generic;

namespace NotesApp.Models
{
  public interface IDomainRoot
  {
    // TODO: Should be both IQueryable (linqified) and ICollection (modifiable)
    ICollection<User> Users { get; }

    void Save();
  }
}
