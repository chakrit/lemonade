
namespace NotesApp.Models
{
  public interface IUsersRoot
  {
    User Add(string username, string passwordHash);

    string HashPassword(string rawPassword);
  }
}
