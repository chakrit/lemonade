
using System.Collections.Generic;

namespace NotesApp.Models.Redis
{
  public class RedisDomainRoot : IDomainRoot
  {
    public ICollection<User> Users
    {
      get { throw new System.NotImplementedException(); }
    }

    public void Save()
    {
      // nothing to do
    }
  }
}
