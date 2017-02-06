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
    public partial class AdminCreateUser : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "AccessNetId";
                ViewState["SortDirection"] = "ASC";
                gvUser_Bind();
            }

            if (Session["activation"] != null)
            {
                if (Session["activation"].ToString() == "Y")
                {
                    string message = "The user has been deactivated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Session["activation"] = null;
                }
                else
                {
                    string message = "The user has been activated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Session["activation"] = null;
                }
            }
        }

        protected void gvUser_Bind()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getUserList";

            DataSet userList = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = userList.Tables[0];
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvUserControl.DataSource = dt;
            String[] userId = new String[1];
            userId[0] = "AccessNetId";
            gvUserControl.DataKeyNames = userId;
            gvUserControl.DataBind();
            Session["UserData"] = dt;
        }

        protected void gvUserControl_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort"  && e.CommandName != "Page")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int RoleId = 0;

                if (e.CommandName == "EditUser")
                {
                    if (gvUserControl.Rows[rowIndex].Cells[1].Text == "Administrator")
                    {
                        RoleId = 1;
                    }
                    else if (gvUserControl.Rows[rowIndex].Cells[1].Text == "GEEC")
                    {
                        RoleId = 2;
                    }
                    else if (gvUserControl.Rows[rowIndex].Cells[1].Text == "GAC")
                    {
                        RoleId = 3;
                    }
                    else if (gvUserControl.Rows[rowIndex].Cells[1].Text == "Department Contact")
                    {
                        RoleId = 4;
                    }
                    Session["OldRoleId"] = RoleId;
                    string requestedAccessNetID = gvUserControl.Rows[rowIndex].Cells[0].Text;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getUserInfo";

                    SqlParameter inputParameter = new SqlParameter("@inAccessNetID", requestedAccessNetID);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@inRoleId", RoleId);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.Int;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet userInfo = objDB.GetDataSetUsingCmdObj(objCommand);

                    txtAccessNetID.Text = userInfo.Tables[0].Rows[0][0].ToString();
                    ddlRole.Text = userInfo.Tables[0].Rows[0][1].ToString();
                    txtFullName.Text = userInfo.Tables[0].Rows[0][2].ToString();
                    txtEmail.Text = userInfo.Tables[0].Rows[0][3].ToString();
                }

                if (e.CommandName == "ActivateUser")
                {
                    string requestedAccessNetID = gvUserControl.Rows[rowIndex].Cells[0].Text;

                    GridViewRow row = gvUserControl.Rows[rowIndex];
                    string checkStatus = ((Button)(row.Cells[5].Controls[0])).Text;

                    if (checkStatus == "Y")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateUserStatus";

                        objCommand.Parameters.AddWithValue("@inAccessNetId", requestedAccessNetID);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "N");
                        objCommand.Parameters.AddWithValue("@inLastModUser", (string)Session["ContactId"]);
                        objCommand.Parameters.AddWithValue("@inRoleId", RoleId);

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "Y";
                        ((Button)(row.Cells[5].Controls[0])).Text = "N";
                        Response.Redirect("AdminCreateUser.aspx");
                    }

                    else if (checkStatus == "N")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateUserStatus";

                        objCommand.Parameters.AddWithValue("@inAccessNetId", requestedAccessNetID);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "Y");
                        objCommand.Parameters.AddWithValue("@inLastModUser", (string)Session["ContactId"]);
                        objCommand.Parameters.AddWithValue("@inRoleId", RoleId);

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "N";
                        ((Button)(row.Cells[5].Controls[0])).Text = "Y";
                        Response.Redirect("AdminCreateUser.aspx");
                    }
                }
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "insertUser";

            objCommand.Parameters.AddWithValue("@inAccessNetId", txtAccessNetIDForCreate.Text);
            objCommand.Parameters.AddWithValue("@inRoleId", ddlRoleForCreate.SelectedItem.Value);
            objCommand.Parameters.AddWithValue("@indFullNm", txtFullNameForCreate.Text);
            objCommand.Parameters.AddWithValue("@indEmail", txtEmailForCreate.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", (string)Session["ContactId"]);

            objDB.DoUpdateUsingCmdObj(objCommand);

            string message = "The user has been created successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvUser_Bind();
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editUser";

            objCommand.Parameters.AddWithValue("@inAccessNetId", txtAccessNetID.Text);
            objCommand.Parameters.AddWithValue("@inRoleId", ddlRole.SelectedItem.Value);
            objCommand.Parameters.AddWithValue("@indFullNm", txtFullName.Text);
            objCommand.Parameters.AddWithValue("@indEmail", txtEmail.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", (string)Session["ContactId"]);
            objCommand.Parameters.AddWithValue("@inOldRoleId", (int)Session["OldRoleId"]);

            objDB.DoUpdateUsingCmdObj(objCommand);

            string message = "Your modification has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvUser_Bind();
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string requestedAccessNetID = Session["temp"].ToString();
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "deleteUser";

        //    SqlParameter inputParameter = new SqlParameter("@inputAccessNetID", requestedAccessNetID);
        //    inputParameter.Direction = ParameterDirection.Input;
        //    inputParameter.SqlDbType = SqlDbType.VarChar;
        //    objCommand.Parameters.Add(inputParameter);

        //    objDB.DoUpdateUsingCmdObj(objCommand);

        //    Session["temp"] = null;
        //    Response.Redirect("AdminCreateUser.aspx");
        //}

        protected void gvUserControl_OnPageIndexChaning(object sender, GridViewPageEventArgs e)
        {
            gvUserControl.PageIndex = e.NewPageIndex;
            gvUser_Bind();
            Session["pageIndex"] = e.NewPageIndex;
        }

        protected void gvUserControl_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["UserData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvUserControl.DataSource = Session["UserData"];
                gvUserControl.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
    }
}