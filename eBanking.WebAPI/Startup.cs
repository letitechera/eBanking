using eBanking.WebAPI.App_Start;
using Owin;
using System.Web.Http;
using Unity.WebApi;

namespace eBanking.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            HttpConfiguration config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}