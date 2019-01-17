using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PhotoAlbum.WebApi.App_Start;

namespace PhotoAlbum.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            NinjectWebCommon.RegisterNinject(GlobalConfiguration.Configuration);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
