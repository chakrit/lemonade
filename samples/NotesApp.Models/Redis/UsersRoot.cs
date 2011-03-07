
namespace NotesApp.Models.Redis
{
  public class UsersRoot : IUsersRoot
  {
    public User Add(string username, string passwordHash)
    {
      throw new System.NotImplementedException();
    }

    public string HashPassword(string rawPassword)
    {
      throw new System.NotImplementedException();
    }
  }
}
