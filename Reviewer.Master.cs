using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GenEdRecertification_v2._0
{
    public partial class Reviewer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reviewerValid"] != null)
            {
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}