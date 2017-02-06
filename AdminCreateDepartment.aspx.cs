using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CIS4396
{
    public partial class AdminCreateDepartment : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "DeptNm";
                ViewState["SortDirection"] = "ASC";
                gvDepartment_Bind();
            }

            if (Session["activation"] != null)
            {
                if (Session["activation"].ToString() == "Y")
                {
                    string message = "The Department has been deactivated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string message = "The Department has been activated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                Session["activation"] = null;
            }
        }

        protected void gvDepartment_Bind()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getDepartmentList";

            DataSet deptList = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = deptList.Tables[0];
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvDepartmentControl.DataSource = dt;

            String[] deptId = new String[1];
            deptId[0] = "DeptId";
            gvDepartmentControl.DataKeyNames = deptId;
            gvDepartmentControl.DataBind();
            Session["DeptData"] = dt;
        }

        protected void gvDepartmentControl_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int deptId = Int32.Parse(gvDepartmentControl.DataKeys[rowIndex].Value.ToString());

                if (e.CommandName == "EditDepartment")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getDepartmentInfo";

                    SqlParameter inputParameter = new SqlParameter("@inDeptId", deptId);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet departmentInfo = objDB.GetDataSetUsingCmdObj(objCommand);

                    txtCollegeCode2.Text = departmentInfo.Tables[0].Rows[0][2].ToString();
                    txtDepartmentName2.Text = departmentInfo.Tables[0].Rows[0][3].ToString();
                    txtSubjectCode2.Text = departmentInfo.Tables[0].Rows[0][4].ToString();

                    Session["requestedDeptId"] = deptId;
                }

                if (e.CommandName == "ActivateDepartment")
                {
                    GridViewRow row = gvDepartmentControl.Rows[rowIndex];
                    string checkStatus = ((Button)(row.Cells[5].Controls[0])).Text;

                    if (checkStatus == "Y")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateDepartmentStatus";

                        objCommand.Parameters.AddWithValue("@inDeptId", deptId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "N");
                        objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "Y";
                        Response.Redirect("AdminCreateDepartment.aspx");
                    }

                    else if (checkStatus == "N")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateDepartmentStatus";

                        objCommand.Parameters.AddWithValue("@inDeptId", deptId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "Y");
                        objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "N";
                        Response.Redirect("AdminCreateDepartment.aspx");
                    }
                    gvDepartment_Bind();
                }
            }
        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "insertDepartment";

            //Need to implement College ID
            objCommand.Parameters.AddWithValue("@inCollegeId", "0");
            objCommand.Parameters.AddWithValue("@inCollegeCd", txtCollegeCode1.Text);
            objCommand.Parameters.AddWithValue("@inDeptNm", txtDepartmentName1.Text);
            objCommand.Parameters.AddWithValue("@inSubjectCd", txtSubjectCode1.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            string message = "The Department has been created successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvDepartment_Bind();
        }

        protected void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            string requestedDeptId = Session["requestedDeptId"].ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editDepartment";

            //Need to implement College ID
            objCommand.Parameters.AddWithValue("@inDeptId", requestedDeptId);
            objCommand.Parameters.AddWithValue("@inCollegeId", "0");
            objCommand.Parameters.AddWithValue("@inCollegeCd", txtCollegeCode2.Text);
            objCommand.Parameters.AddWithValue("@inDeptNm", txtDepartmentName2.Text);
            objCommand.Parameters.AddWithValue("@inSubjectCd", txtSubjectCode2.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["requestedDeptId"] = null;

            string message = "Your modification has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvDepartment_Bind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string requestedDeptId = Session["temp"].ToString();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "deleteDepartment";

            SqlParameter inputParameter = new SqlParameter("@inDeptId", requestedDeptId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["temp"] = null;
            gvDepartment_Bind();
        }

        protected void gvDepartmentControl_OnPageIndexChaning(object sender, GridViewPageEventArgs e)
        {
            gvDepartmentControl.PageIndex = e.NewPageIndex;
            gvDepartment_Bind();
        }

        protected void gvDepartmentControl_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["DeptData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvDepartmentControl.DataSource = Session["DeptData"];
                gvDepartmentControl.DataBind();
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