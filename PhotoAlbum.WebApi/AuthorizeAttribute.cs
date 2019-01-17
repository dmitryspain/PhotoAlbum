using System.Web;

namespace PhotoAlbum.WebApi
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public AuthorizeAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}