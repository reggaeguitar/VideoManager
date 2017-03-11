using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace VideoManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();            

            var cors = new EnableCorsAttribute("http://www.localhost:8080", "*", "*");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
