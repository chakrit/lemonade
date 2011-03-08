
using System.Collections.Generic;

namespace NotesApp.Models
{
  public interface IDomainRoot
  {
    ICollection<User> Users { get; }

    void Save();
  }
}
