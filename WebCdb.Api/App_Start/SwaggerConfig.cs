using System.Web.Http;
using WebActivatorEx;
using WebCdb;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebCdb
{
    public class SwaggerConfig
    {
        protected SwaggerConfig() { }

        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebCdb");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocExpansion(DocExpansion.List);
                    });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\WebCdbSwagger.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
