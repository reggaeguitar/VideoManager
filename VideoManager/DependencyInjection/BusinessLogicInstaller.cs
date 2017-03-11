using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace VideoManager.DependencyInjection
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(x => !x.Name.EndsWith("Controller"))
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
