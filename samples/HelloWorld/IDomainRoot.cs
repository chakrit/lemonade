
using System;
using System.Collections.Generic;

namespace HelloWorld
{
  public interface IDomainRoot
  {
    IList<Company> Companies { get; }
    DateTime DateLastUpdated { get; }
  }
}
