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
// MUST BE DELETED

namespace PhotoAlbum.WebApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        private IUserService _userService;

        [Inject]
        public IUserService UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }

        public Startup()
        {
            var kernel = new StandardKernel(new BLL.Infrastructure.Bindings("PhotoAlbum"));
            kernel.Inject(this);
        }
    

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            //_userService = userService;
            //// Configure the db context and user manager to use a single instance per request
            //// todo: SERVICE DB CONTEXT
            //app.CreatePerOwinContext(PhotoAlbumContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            //// Enable the application to use a cookie to store information for the signed in user
            //// and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(UserService),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true,
            };


            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
