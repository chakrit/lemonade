
using Autofac;
using NotesApp.Models;
using NotesApp.Models.Repositories;
using NotesApp.Models.Volatile;

namespace NotesApp
{
  public class ModelsModule : Module
  {
    protected override void Load(ContainerBuilder b)
    {
      // TODO: Replace with SiderDomainRoot
      b.RegisterType<VolatileDomainRoot>()
        .As<IDomainRoot>()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IRepository).Assembly)
        .AssignableTo<IRepository>()
        .AsSelf()
        .AsImplementedInterfaces()
        .PropertiesAutowired()
        .InstancePerDependency();

      b.RegisterAssemblyTypes(typeof(IFactory).Assembly)
        .AssignableTo<IFactory>()
        .AsImplementedInterfaces()
        .PropertiesAutowired()
        .SingleInstance();

      b.RegisterAssemblyTypes(typeof(IDataService).Assembly)
        .AssignableTo<IDataService>()
        .AsSelf()
        .AsImplementedInterfaces()
        .PropertiesAutowired()
        .SingleInstance();
    }
  }
}
