
namespace NotesApp.Models
{
  public interface IPasswordService : IDataService
  {
    string HashPassword(string rawPassword);
  }
}
