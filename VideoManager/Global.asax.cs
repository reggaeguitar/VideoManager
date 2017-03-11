using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using VideoManager.DependencyInjection;

namespace VideoManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            _container = new WindsorContainer();
            // Below calls install methods in BusinessLogicInstaller.cs, ServiceInstaller.cs, and ControllersInstaller.cs
            _container.Install(FromAssembly.This());

            // The next few lines replace the ASP.NET controller factory with the WindsorControllerFactory which uses
            // Castle.Windsor
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            GlobalConfiguration.Configuration.Services.Replace(
                 typeof(IHttpControllerActivator),
                 new WindsorCompositionRoot(_container));
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _container.Dispose();
        }
    }
}
