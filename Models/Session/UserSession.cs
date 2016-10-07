namespace WebApplication2.Models.Session
{
    using System;
    using System.Web;
    using User;

    [Serializable]
    public class UserSession
    {

        public static UserSession Current
        {
            get
            {
                UserSession session = (UserSession)HttpContext.Current.Session["User"];

                if (session == null)
                {
                    session = new UserSession();
                    HttpContext.Current.Session["User"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        public UserInfo User { get; set; }

    }
}