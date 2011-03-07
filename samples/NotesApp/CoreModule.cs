
using Autofac;
using NotesApp.Controllers;
using NotesApp.Models;
using NotesApp.Views;

namespace NotesApp
{
  public class CoreModule : Module
  {
    protected override void Load(ContainerBuilder b)
    {
      b.RegisterAssemblyTypes(typeof(IDomainRoot).Assembly)
        .AssignableTo<IDomainRoot>()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IView).Assembly)
        .AssignableTo<IView>()
        .AsSelf()
        .AsImplementedInterfaces()
        .PropertiesAutowired()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IController).Assembly)
        .AssignableTo<IController>()
        .AsSelf()
        .AsImplementedInterfaces()
        .OnActivated(a => ((IController)a.Instance).Initialize())
        .PropertiesAutowired()
        .InstancePerDependency();
    }
  }
}
