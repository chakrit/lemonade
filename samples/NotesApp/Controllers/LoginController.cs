
using System.Windows.Forms;
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public class LoginController : ControllerBase<LoginView>
  {
    public override void Initialize()
    {
      View.FormClosed += (sender, e) => Application.Exit();
      View.LoginButton.Click += (sender, e) =>
        Login(View.UsernameBox.Text, View.PasswordBox.Text);
    }

    public void Login(string username, string password)
    {
      View.Close();
    }
  }
}
