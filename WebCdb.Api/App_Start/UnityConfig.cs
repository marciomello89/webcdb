using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebCdb.Domain.IServices;
using WebCdb.Services;

namespace WebCdb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterSingleton<ICalculationService, CalculationService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}