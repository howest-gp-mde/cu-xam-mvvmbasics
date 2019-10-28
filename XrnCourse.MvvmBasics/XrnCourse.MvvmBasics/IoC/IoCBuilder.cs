using Autofac;
using XrnCourse.MvvmBasics.Domain.Services;
using XrnCourse.MvvmBasics.ViewModels;

namespace XrnCourse.MvvmBasics.IoC
{

    public static class IoCBuilder
    {
        public static ContainerBuilder GetDefaultContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();

            //registering these types enable dependency injection for their ctors
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ClassmateViewModel>();

            //always use a JsonClassmateRepository when a IClassmatRepository is needed
            containerBuilder.RegisterType<JsonClassmateRepository>().As<IClassmateRepository>();

            //always use a SeedDataStoreService when a ISeederService is needed
            containerBuilder.RegisterType<SeedDataStoreService>().As<ISeederService>();

            return containerBuilder;
        }
    }

}
