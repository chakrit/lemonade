
namespace NotesApp.Models
{
  public class UserRegistrarImpl : IUserRegistrar
  {
    private IPasswordService _pwd;
    private ITimestampService _timestamper;

    public UserRegistrarImpl(IPasswordService pwd, ITimestampService timestamper)
    {
      _pwd = pwd;
      _timestamper = timestamper;
    }


    public User RegisterNewUser(string username, string password)
    {
      DomainAssert.NotNullOrEmpty(username, "Username cannot be empty.");
      DomainAssert.NotNullOrEmpty(password, "Password cannot be empty.");

      var pwdHash = _pwd.HashPassword(password);
      return new User(username, pwdHash, _timestamper.GetTimestamp());
    }
  }
}
