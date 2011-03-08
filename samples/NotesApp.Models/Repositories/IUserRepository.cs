
namespace NotesApp.Models.Repositories
{
  public interface IUserRepository : IRepository
  {
    User GetByCredentials(string username, string password);
    void AddUser(User u);
  }
}
