
using System.Windows.Forms;

namespace NotesApp.Services
{
  public class MessageBoxNotificationService : INotificationService
  {
    public void NotifySuccess(string successMessage)
    {
      MessageBox.Show(successMessage, "Success",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void NotifyError(string errorMessage)
    {
      MessageBox.Show(errorMessage, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
