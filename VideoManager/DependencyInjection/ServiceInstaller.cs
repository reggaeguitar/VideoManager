using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VideoManager.EntityFramework;
using VideoServices;

namespace VideoManager.DependencyInjection
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // VideoServices
            container.Register(Classes.FromAssemblyContaining<IVideoRepository>()
                .InNamespace("VideoServices", includeSubnamespaces: true)
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());

            // VideoServices
            container.Register(Classes.FromAssemblyContaining<IVideoManagerContextFactory>()
                .InNamespace("VideoManager.EntityFramework", includeSubnamespaces: true)
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
