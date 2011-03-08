
namespace NotesApp.Models
{
  public interface IUserRegistrar : IFactory
  {
    User RegisterNewUser(string username, string password);
  }
}
