using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS4396Solution
{
    public partial class AdminCreateArea : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "AreaNm";
                ViewState["SortDirection"] = "ASC";
                gvAreaControl_Bind();
            }

            if (Session["activation"] != null)
            {
                if (Session["activation"].ToString() == "Y")
                {
                    string message = "The Area has been deactivated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string message = "The Area has been activated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                Session["activation"] = null;
            }
        }

        protected void gvAreaControl_Bind()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getAreaList";

            DataSet areaList = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = areaList.Tables[0];

            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvAreaControl.DataSource = dt;
            String[] typeId = new String[1];
            typeId[0] = "AreaCd";
            gvAreaControl.DataKeyNames = typeId;
            gvAreaControl.DataBind();
            Session["AreaData"] = dt;
        }

        protected void gvAreaControl_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "EditArea")
                {
                    Session["requestedAreaCode"] = gvAreaControl.Rows[rowIndex].Cells[0].Text;
                    string requestedAreaCode = Session["requestedAreaCode"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getAreaInfo";

                    SqlParameter inputParameter = new SqlParameter("@inAreaCd", requestedAreaCode);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet areaInfo = objDB.GetDataSetUsingCmdObj(objCommand);

                    txtAreaCode2.Text = areaInfo.Tables[0].Rows[0][0].ToString();
                    txtAreaName2.Text = areaInfo.Tables[0].Rows[0][1].ToString();
                }

                if (e.CommandName == "ActivateArea")
                {
                    string requestedAreaCode = gvAreaControl.Rows[rowIndex].Cells[0].Text;

                    GridViewRow row = gvAreaControl.Rows[rowIndex];
                    string checkStatus = ((Button)(row.Cells[3].Controls[0])).Text;

                    if (checkStatus == "Y")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateAreaStatus";

                        objCommand.Parameters.AddWithValue("@inAreaCd", requestedAreaCode);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "N");
                        objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "Y";
                        Response.Redirect("AdminCreateArea.aspx");
                    }

                    else if (checkStatus == "N")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateAreaStatus";

                        objCommand.Parameters.AddWithValue("@inAreaCd", requestedAreaCode);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "Y");
                        objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "N";
                        Response.Redirect("AdminCreateArea.aspx");
                    }
                    gvAreaControl_Bind();
                }
            }
        }

        protected void btnAddArea_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "insertArea";

            objCommand.Parameters.AddWithValue("@inAreaCd", txtAreaCode1.Text);
            objCommand.Parameters.AddWithValue("@inAreaNm", txtAreaName1.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            string message = "The Area has been created successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvAreaControl_Bind();
        }

        protected void btnSaveArea_Click(object sender, EventArgs e)
        {
            string requestedDeptId = Session["requestedAreaCode"].ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editArea";

            objCommand.Parameters.AddWithValue("@inAreaCd", txtAreaCode2.Text);
            objCommand.Parameters.AddWithValue("@inAreaNm", txtAreaName2.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["requestedAreaCode"] = null;

            string message = "Your modification has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvAreaControl_Bind();
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string requestedAreaCode = Session["temp"].ToString();
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "deleteArea";

        //    SqlParameter inputParameter = new SqlParameter("@inAreaCd", requestedAreaCode);
        //    inputParameter.Direction = ParameterDirection.Input;
        //    inputParameter.SqlDbType = SqlDbType.VarChar;
        //    objCommand.Parameters.Add(inputParameter);

        //    objDB.DoUpdateUsingCmdObj(objCommand);

        //    Session["temp"] = null;
        //    Response.Redirect("AdminCreateArea.aspx");
        //}

        protected void gvAreaControl_OnPageIndexChaning(object sender, GridViewPageEventArgs e)
        {
            gvAreaControl.PageIndex = e.NewPageIndex;
            gvAreaControl_Bind();
        }

        protected void gvAreaControl_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["AreaData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvAreaControl.DataSource = Session["AreaData"];
                gvAreaControl.DataBind();
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