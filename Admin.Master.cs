using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS4396Solution
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminValid"] != null)
            {
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}