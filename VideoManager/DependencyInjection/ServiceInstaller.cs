using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VideoServices;

namespace VideoManager.DependencyInjection
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IVideoRepository>()
                .InNamespace("VideoServices", includeSubnamespaces: true)
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
