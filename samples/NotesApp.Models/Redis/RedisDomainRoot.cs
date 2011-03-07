
namespace NotesApp.Models
{
  public class SiderDomainRoot : IDomainRoot
  {
    public IUsersRoot Users
    {
      get { throw new System.NotImplementedException(); }
    }

    public System.DateTime GetTimestamp()
    {
      throw new System.NotImplementedException();
    }
  }
}
