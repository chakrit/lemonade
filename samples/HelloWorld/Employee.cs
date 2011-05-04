
namespace HelloWorld
{
  public class Employee
  {
    public virtual string Name { get; set; }
    public virtual int Age { get; set; }
    public virtual string Email { get; set; }


    public override bool Equals(object obj)
    {
      if (obj == null) return false;

      var another = obj as Employee;
      if (another == null)
        return false;

      return another.Name == this.Name &&
        another.Age == this.Age &&
        another.Email == this.Email;
    }

    public override int GetHashCode()
    {
      return Name.GetHashCode() ^ Age.GetHashCode() ^ Email.GetHashCode();
    }
  }
}
