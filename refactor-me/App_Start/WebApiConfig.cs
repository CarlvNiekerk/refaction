using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using refactor_me.Repositories;

namespace refactor_me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var configuration = GlobalConfiguration.Configuration;

            // Register your Web API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ProductOptionsService>().AsImplementedInterfaces();
            builder.RegisterType<ProductsService>().AsImplementedInterfaces();

            // Set the dependancy resolver to be Autofac
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
