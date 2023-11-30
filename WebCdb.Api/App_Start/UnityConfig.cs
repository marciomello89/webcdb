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

            container.RegisterSingleton<ICalculationService, CalculationService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}