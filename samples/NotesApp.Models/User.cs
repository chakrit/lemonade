
using System;

namespace NotesApp.Models
{
  public abstract class User
  {
    public abstract string Username { get; }
    public abstract string PasswordHash { get; set; }

    public DateTime Timestamp { get; set; }


    public User(string username, string passwordHash)
    {
    }
  }
}
