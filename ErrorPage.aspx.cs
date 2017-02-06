using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS4396Solution
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["adminValid"] = false;
            Session["reviewerValid"] = false;
            Session["coordinatorValid"] = false;
        }
    }
}