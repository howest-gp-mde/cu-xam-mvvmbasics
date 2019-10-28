using Autofac;

namespace XrnCourse.MvvmBasics.IoC
{
    public class IocRegistry
    {
        private static IContainer container;
        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    //create container if not existing
                    var builder = IoCBuilder.GetDefaultContainerBuilder();
                    container = builder.Build();
                }
                return container;
            }
        }
    }
}
