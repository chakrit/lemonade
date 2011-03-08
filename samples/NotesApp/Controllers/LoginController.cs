
using System;
using System.Windows.Forms;
using NotesApp.Models.Repositories;
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public class LoginController : ControllerBase<LoginView>
  {
    private IUserRepository _users;
    private Lazy<RegistrationController> _registration;

    public LoginController(IUserRepository users, Lazy<RegistrationController> registration)
    {
      _users = users;
      _registration = registration;
    }


    public override void Initialize()
    {
      View.Closing += (sender, e) => Application.Exit();

      View.RegistrationLink.Click += (sender, e) =>
      {
        View.Hide();

        var registration = _registration.Value;
        registration.ShowModal();
        View.Show();

        var user = registration.Result;
        if (user != null) {
          View.UsernameBox.Text = user.Username;
          focusEnterNewPassword();
        }

      };

      View.LoginButton.Click += (sender, e) =>
        login(View.UsernameBox.Text, View.PasswordBox.Text);
    }


    private void login(string username, string password)
    {
      DomainChecked(() =>
      {
        var user = _users.GetByCredentials(username, password);
        if (user == null) {
          Notifier.NotifyError("Unrecognized username/password combination.");
          focusEnterNewPassword();
          return;
        }

        Notifier.NotifySuccess("Login successful!");
        Close();
        // TODO: Hide this and show the main edit controller
      });
    }


    private void focusEnterNewPassword()
    {
      View.PasswordBox.Text = "";
      View.PasswordBox.Focus();
    }
  }
}
