
using System.Linq;

namespace NotesApp.Models.Repositories
{
  public class UserRepositoryImpl : RepositoryBase, IUserRepository
  {
    public IPasswordService Passwords { get; set; }


    public User GetByCredentials(string username, string password)
    {
      var pwdHash = Passwords.HashPassword(password);

      return Root.Users.FirstOrDefault(u => u.Username == username &&
        u.PasswordHash == pwdHash);
    }

    public void AddUser(User u)
    {
      Root.Users.Add(u);
    }
  }
}
