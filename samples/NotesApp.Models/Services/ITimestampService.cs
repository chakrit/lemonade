
using System;

namespace NotesApp.Models
{
  public interface ITimestampService : IDataService
  {
    DateTime GetTimestamp();
  }
}
