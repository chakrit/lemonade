
using System;
using System.Collections.Generic;

namespace HelloWorld
{
  [Serializable]
  public class Company
  {
    public virtual string Name { get; set; }

    public IList<Employee> Employees { get; set; }
  }
}
