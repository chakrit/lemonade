
using Autofac;
using NotesApp.Controllers;
using NotesApp.Services;
using NotesApp.Views;

namespace NotesApp
{
  public class CoreModule : Module
  {
    protected override void Load(ContainerBuilder b)
    {
      b.RegisterAssemblyTypes(typeof(IView).Assembly)
        .AssignableTo<IView>()
        .AsSelf()
        .PropertiesAutowired()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IController).Assembly)
        .AssignableTo<IController>()
        .AsSelf()
        .OnActivated(a => ((IController)a.Instance).Initialize())
        .PropertiesAutowired()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IClientService).Assembly)
        .AssignableTo<IClientService>()
        .AsSelf()
        .AsImplementedInterfaces()
        .PropertiesAutowired()
        .SingleInstance();
    }
  }
}
