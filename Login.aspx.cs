using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CIS4396Solution
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            loginError.Visible = false;
            invalidUser.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool success = WebService.AuthenticateUser(txtAccessNetUsername.Text, txtPassword.Text);

            if (success == true)
            {
                try
                {
                    LDAPuser loginUser = new LDAPuser();
                    loginUser = WebService.getLDAPEntryByAccessnet(txtAccessNetUsername.Text);
                    string accessNetID = txtAccessNetUsername.Text;

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getLoginCredentials";

                    SqlParameter inputParameter = new SqlParameter("@inAccessNetId", accessNetID);
                    objCommand.Parameters.Add(inputParameter);
                    string roleID = objDB.GetDataSetUsingCmdObj(objCommand).Tables[0].Rows[0]["roleID"].ToString();
                    Session["ContactId"] = txtAccessNetUsername.Text;

                    if (roleID.Equals("1"))
                    {
                        Session["adminValid"] = true;
                        Response.Redirect("AdminHome.aspx");
                    }
                    else if (roleID.Equals("2") || roleID.Equals("3"))
                    {
                        Session["reviewerValid"] = true;
                        Response.Redirect("ReviewerHome.aspx");
                    }
                    else if (roleID.Equals("4"))
                    {
                        Session["CurrentPortfolioId"] = 0;
                        Session["coordinatorValid"] = true;
                        Response.Redirect("CourseCoordinatorHome.aspx");
                    }
                }

                catch (Exception ex)
                {
                    invalidUser.Visible = true;
                    //not valid user. error message
                }
            }
            else
            {
                loginError.Visible = true;
                //wrong ID or password
            }
        }
    }
}