
using System;
using Lemonade;

namespace HelloWorld
{
  public class Program
  {
    internal static void Main(string[] args) { new Program().Run(); }


    private Random _rand = new Random();


    public void Run()
    {
      var builder = new ContextBuilder();
      using (var ctx = builder.NewContext()) {
        var root = ctx.GetRoot<IDomainRoot>();

        initSampleData(root);
        foreach (var comp in root.Companies) {
          Console.WriteLine(" {0} employees ", comp.Name);
          Console.WriteLine(" ==== ");

          foreach (var emp in comp.Employees)
            Console.WriteLine("{0} ({1}), {2} years old.",
              emp.Name, emp.Email, emp.Age);

          Console.WriteLine("\n");
        }
      }

      Console.WriteLine("Done.");
      Console.ReadKey();
    }

    private void initSampleData(IDomainRoot root)
    {
      root.Companies.Add(getSampleCompany("Apple"));
      root.Companies.Add(getSampleCompany("Google"));
      root.Companies.Add(getSampleCompany("Microsoft"));

      foreach (var company in root.Companies)
        company.Employees.Add(getSampleEmployee(company.Name));
    }

    private Company getSampleCompany(string compName)
    {
      return new Company { Name = compName };
    }

    private Employee getSampleEmployee(string companyName)
    {
      var name = Guid.NewGuid().ToString();

      return new Employee {
        Name = name,
        Age = _rand.Next(15, 55),
        Email = name + "@" + companyName + ".com"
      };
    }
  }
}

