
using System;

namespace NotesApp.Models
{
  public interface IDomainRoot
  {
    IUsersRoot Users { get; }

    DateTime GetTimestamp();
  }
}
