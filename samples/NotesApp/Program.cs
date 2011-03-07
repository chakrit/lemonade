
using System;
using System.Windows.Forms;
using Autofac;
using NotesApp.Controllers;

namespace NotesApp
{
  public class Program
  {
    [STAThread]
    internal static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      new Program().Run();
    }


    public void Run()
    {
      var builder = new ContainerBuilder();
      builder.RegisterModule(new CoreModule());

      var container = builder.Build();

      var controller = container.Resolve<LoginController>();
      controller.Show();
      Application.Run();
    }

  }
}
