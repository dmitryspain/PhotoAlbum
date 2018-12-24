using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PhotoAlbum.WebApi.Providers;
using PhotoAlbum.WebApi.Models;
using System.Web.Configuration;
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
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true,
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
