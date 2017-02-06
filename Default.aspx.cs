using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS4396Solution
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Setting the redirect to https will force your entire site to always be encrypted.
            //Default files are to be used to redirect your application on the server side, to the proper starting page for your application
            Response.Redirect("Login.aspx");
        }
    }
}