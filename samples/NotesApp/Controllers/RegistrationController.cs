
using NotesApp.Models;
using NotesApp.Models.Repositories;
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public class RegistrationController : ControllerBase<RegistrationView, User>
  {
    public IUserRegistrar Registrar { get; set; }
    public IUserRepository Users { get; set; }

    public override void Initialize()
    {
      Result = null;
      View.CancelLink.Click += (sender, e) => Close();

      View.RegisterButton.Click += (sender, e) => DomainChecked(() =>
      {
        if (View.PasswordBox.Text != View.PasswordConfirmBox.Text) {
          Notifier.NotifyError("Passwords don't match, please try again.");
          retryPasswordEnter();
          return;
        }

        Users.AddUser(Result = Registrar.RegisterNewUser(
          View.UsernameBox.Text,
          View.PasswordBox.Text));

        Close();

      }, onCatch: retryPasswordEnter);
    }


    private void retryPasswordEnter()
    {
      View.PasswordBox.Text = View.PasswordConfirmBox.Text = "";
      View.PasswordBox.Focus();
    }
  }
}
