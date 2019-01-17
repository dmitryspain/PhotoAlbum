using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PhotoAlbum.WebApi.Providers;
using PhotoAlbum.BLL.Interfaces;
using Ninject;
using PhotoAlbum.WebApi.App_Start;
// MUST BE DELETED

namespace PhotoAlbum.WebApi
{
    public partial class Startup
    {
        [Inject]
        public IUserService UserService { get; set; }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public Startup()
        {
            var kernel = NinjectWebCommon.Kernel;
            kernel.Inject(this);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(UserService),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
