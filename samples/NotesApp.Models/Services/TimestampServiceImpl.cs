
using System;

namespace NotesApp.Models
{
  public class TimestampServiceImpl : ITimestampService
  {
    public DateTime GetTimestamp()
    {
      return DateTime.Now;
    }
  }
}
