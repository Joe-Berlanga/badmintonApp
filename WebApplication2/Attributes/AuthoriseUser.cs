namespace WebApplication2.Attributes
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using WebApplication2.Models.Enum;
    using WebApplication2.Models.Session;

    public class AuthoriseUser : AuthorizeAttribute
    {
        private PriviledgeEnum AccessLevel;

        internal AuthoriseUser(PriviledgeEnum AccessLevel)
        {
            this.AccessLevel = AccessLevel;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (UserSession.Current.User?.Priviledges != null)
            {
                foreach (var priviledge in UserSession.Current.User.Priviledges)
                {
                    if (priviledge.PriviledgeId == AccessLevel)
                    {
                        return true;
                    }
                }
            }
            
            return false;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Error",
                                action = "Unauthorised",

                            })
                        );
        }
    }
}