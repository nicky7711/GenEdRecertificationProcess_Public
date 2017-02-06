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
    public partial class AdminCreatePortfolioDocument : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "DocumentName";
                ViewState["SortDirection"] = "ASC";
                gvType_Bind();
            }

            if (Session["activation"] != null)
            {
                if (Session["activation"].ToString() == "Y")
                {
                    string message = "The document type has been deactivated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string message = "The document type has been activated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                Session["activation"] = null;
            }
        }

        protected void gvType_Bind()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getDocumentTypeList";

            DataSet typeList = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = typeList.Tables[0];

            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvControl.DataSource = dt;
            String[] typeId = new String[1];
            typeId[0] = "DocumentTypeId";
            gvControl.DataKeyNames = typeId;
            gvControl.DataBind();
            Session["TypeData"] = dt;
        }

        protected void gvControl_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "EditDocsType")
                {
                    Session["requestedId"] = gvControl.Rows[rowIndex].Cells[0].Text;
                    string requestedId = Session["requestedId"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getDocsInfo";

                    SqlParameter inputParameter = new SqlParameter("@inDocsId", requestedId);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet DocsInfo = objDB.GetDataSetUsingCmdObj(objCommand);
                }

                if (e.CommandName == "ActivateDocsType")
                {
                    string requestedId = gvControl.Rows[rowIndex].Cells[0].Text;

                    GridViewRow row = gvControl.Rows[rowIndex];
                    string checkStatus = ((Button)(row.Cells[3].Controls[0])).Text;

                    if (checkStatus == "Y")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateDocsTypeStatus";

                        objCommand.Parameters.AddWithValue("@inDocsId", requestedId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "N");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "Y";
                        Response.Redirect("AdminCreatePortfolioDocument.aspx");
                    }

                    else if (checkStatus == "N")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateDocsTypeStatus";

                        objCommand.Parameters.AddWithValue("@inDocsId", requestedId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "Y");

                        objDB.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "N";
                        Response.Redirect("AdminCreatePortfolioDocument.aspx");
                    }
                    gvType_Bind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "insertDocumentType";

            objCommand.Parameters.AddWithValue("@inDocsName", txtDocumentNameForCreate.Text);

            objDB.DoUpdateUsingCmdObj(objCommand);

            string message = "The document type has been added successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvType_Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string requestedId = Session["requestedId"].ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editDocumentType";

            objCommand.Parameters.AddWithValue("@inDocsId", requestedId);
            objCommand.Parameters.AddWithValue("@inDocsName", txtDocumentName.Text);

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["requestedId"] = null;

            string message = "Your modification has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvType_Bind();
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string requestedId = Session["temp"].ToString();
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "deleteDocumentType";

        //    SqlParameter inputParameter = new SqlParameter("@inDocsId", requestedId);
        //    inputParameter.Direction = ParameterDirection.Input;
        //    inputParameter.SqlDbType = SqlDbType.VarChar;
        //    objCommand.Parameters.Add(inputParameter);

        //    objDB.DoUpdateUsingCmdObj(objCommand);

        //    Session["temp"] = null;
        //    Response.Redirect("AdminCreatePortfolioDocument.aspx");
        //}

        protected void gvControl_OnPageIndexChaning(object sender, GridViewPageEventArgs e)
        {
            gvControl.PageIndex = e.NewPageIndex;
            gvType_Bind();
        }

        protected void gvControl_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["TypeData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvControl.DataSource = Session["TypeData"];
                gvControl.DataBind();
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
