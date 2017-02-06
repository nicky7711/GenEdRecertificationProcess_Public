using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS4396Solution
{
    public partial class AdminEditPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Today;
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLandingPage.aspx");
            //Response.Write("<script>alert('Email Sent to Contacts.')</script>");
        }

        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            if (ddlDept.SelectedValue == "Art History")
            {
                fieldContact1.Visible = true;
            }
            if (ddlDept.SelectedValue == "Greek and Roman Classics")
            {
                fieldContact2.Visible = true;
            }
            if (ddlDept.SelectedValue == "Religion")
            {
                fieldContact3.Visible = true;
            }
        }
    }
}