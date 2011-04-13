
using System.Collections.Generic;
using System.Linq;

namespace NotesApp.Models.Volatile
{
  public class VolatileDomainRoot : IDomainRoot
  {
    private static ICollection<User> _users = new List<User>();

    public ICollection<User> Users { get { return _users; } }


    public void Save()
    {
      // volatile, hence nothing to save.
    }

  }
}
