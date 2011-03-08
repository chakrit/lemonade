
using System;

namespace NotesApp.Models
{
  public class User
  {
    public virtual string Username { get; protected set; }
    public virtual string PasswordHash { get; protected set; }

    public DateTime Timestamp { get; protected set; }


    internal User(string username, string passwordHash, DateTime timestamp)
    {
      Username = username;
      PasswordHash = passwordHash;
      Timestamp = timestamp;
    }
  }
}
