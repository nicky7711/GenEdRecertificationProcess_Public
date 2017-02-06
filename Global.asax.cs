using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CIS4396Solution
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // This code will make sure your site remains encrypted using https
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
                    + HttpContext.Current.Request.RawUrl);
            }

            //This is here for security reasons, and if not present at the time of security reviews, will need to be added back in again.
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Pragma", "no-store");
            Response.AddHeader("cache-control", "no-cache");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}