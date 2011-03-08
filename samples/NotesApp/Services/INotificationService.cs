
namespace NotesApp.Services
{
  public interface INotificationService : IClientService
  {
    void NotifySuccess(string successMessage);
    void NotifyError(string errorMessage);
  }
}
