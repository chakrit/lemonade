
using System;
using System.Security.Cryptography;
using System.Text;

namespace NotesApp.Models
{
  public class PasswordServiceImpl : IPasswordService
  {
    public string HashPassword(string rawPassword)
    {
      var sha1 = SHA1.Create();
      var bytes = Encoding.UTF8.GetBytes(rawPassword);

      return Convert.ToBase64String(sha1.ComputeHash(bytes));
    }
  }
}
