using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace CIS4396Solution
{
    public partial class AdminCreateCourse : System.Web.UI.Page
    {
        DBConnect objDb = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpression"] = "CourseTitle";
                ViewState["SortDirection"] = "ASC";
                gvCourseControl_Bind();
                DropDown_Bind();
            }

            if (Session["activation"] != null)
            {
                if (Session["activation"].ToString() == "Y")
                {
                    string message = "The course has been deactivated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string message = "The course has been activated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                Session["activation"] = null;
            }

        }

        protected void gvCourseControl_Bind()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getCourse";

            DataSet courseList = objDb.GetDataSetUsingCmdObj(objCommand);
            DataTable dt = courseList.Tables[0];
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvCourseControl.DataSource = dt;

            String[] courseId = new String[1];
            courseId[0] = "CourseId";
            gvCourseControl.DataKeyNames = courseId;
            gvCourseControl.DataBind();
            Session["CourseData"] = dt;
        }

        protected void DropDown_Bind()
        {
            DataSet collegeList = getColleges();
            ddlColleges.DataSource = collegeList;
            ddlColleges.DataValueField = "CollegeCode";
            ddlColleges.DataTextField = "CollegeName";
            ddlColleges.DataBind();

            ddlColleges2.DataSource = collegeList;
            ddlColleges2.DataValueField = "CollegeCode";
            ddlColleges2.DataTextField = "CollegeName";
            ddlColleges2.DataBind();

            DataSet courseAreasData = getCourseAreas();
            ddlCourseArea.DataSource = courseAreasData;
            ddlCourseArea.DataValueField = "AreaCd";
            ddlCourseArea.DataTextField = "AreaNm";
            ddlCourseArea.DataBind();

            ddlCourseArea2.DataSource = courseAreasData;
            ddlCourseArea2.DataValueField = "AreaCd";
            ddlCourseArea2.DataTextField = "AreaNm";
            ddlCourseArea2.DataBind();
        }

        private DataSet getColleges()
        {
            College[] collegeList = WebService.getAllColleges();

            DataSet ds = new DataSet();
            DataTable colleges = new DataTable();
            DataColumn dc = new DataColumn("CollegeName", typeof(System.String));
            colleges.Columns.Add(dc);
            dc = new DataColumn("CollegeCode", typeof(System.String));
            colleges.Columns.Add(dc);
            ds.Tables.Add(colleges);

            //String s = "";            

            foreach (College college in collegeList)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["CollegeName"] = college.collegeName;
                //s = s + " " + college.collegeName;
                dr["CollegeCode"] = college.collegeCode;
                //s = s + " " + college.collegeCode + " ";
                ds.Tables[0].Rows.Add(dr);
            }

            //lblMessage.Text = s;

            return ds;
        }

        private DataSet getCourseAreas()
        {
            SqlCommand objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "GetCourseArea";

            return objDb.GetDataSetUsingCmdObj(objCmd);
        }

        private DataSet getDepartments(string college)
        {
            String courseDepartment = ddlDepartment.DataValueField;

            SqlCommand objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "GetDept";

            String selectedCollege = college;

            objCmd.Parameters.AddWithValue("@inCollegeCd", selectedCollege);
            DataSet departments = objDb.GetDataSetUsingCmdObj(objCmd);

            return departments;
        }

        protected void ddlColleges_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet departments = getDepartments(ddlColleges.SelectedValue);
            ddlDepartment.DataSource = departments;
            ddlDepartment.DataTextField = "DeptNm";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
            string script = "function(){ $('#createModal').modal('show')";
            script += "'};";
            ClientScript.RegisterStartupScript(this.GetType(), "hwa", script, true);
        }

        protected void ddlColleges2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "hwa", "openCreateModal", true);
            DataSet departments = getDepartments(ddlColleges2.SelectedValue);
            ddlDepartment2.DataSource = departments;
            ddlDepartment2.DataTextField = "DeptNm";
            ddlDepartment2.DataValueField = "DeptId";
            ddlDepartment2.DataBind();
        }

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            String courseCollege = ddlColleges.SelectedValue; //college code
            String courseTitle = txtCourseTitle.Text; //string
            String courseNumber = txtCourseNumber.Text; // string
            String courseArea = ddlCourseArea.SelectedValue; // code
            int courseDepartment = 0;
            Int32.TryParse(ddlDepartment.SelectedValue, out courseDepartment); // integer
            String courseSubjectCode = txtSubjectCode.Text; // code

            SqlCommand objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "AddCourse";

            objCmd.Parameters.AddWithValue("@inCourseTitle", courseTitle);
            objCmd.Parameters.AddWithValue("@inCourseNum", courseNumber);
            objCmd.Parameters.AddWithValue("@inSubjectCd", courseSubjectCode);
            objCmd.Parameters.AddWithValue("@inAreaCd", courseArea);
            objCmd.Parameters.AddWithValue("@inDeptId", courseDepartment);

            objDb.DoUpdateUsingCmdObj(objCmd);

            string message = "The course has been created successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvCourseControl_Bind();
        }

        protected void gvCourseControl_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int courseId = Int32.Parse(gvCourseControl.DataKeys[rowIndex].Value.ToString());

                if (e.CommandName == "EditCourse")
                {
                    //int rowIndex = int.Parse(e.CommandArgument.ToString());
                    //int courseId = Int32.Parse(gvCourseControl.DataKeys[rowIndex].Value.ToString());

                    Session["requestedId"] = gvCourseControl.Rows[rowIndex].Cells[0].Text;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "getCourseInfo";

                    SqlParameter inputParameter = new SqlParameter("@inCourseId", gvCourseControl.Rows[rowIndex].Cells[0].Text);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet courseInfo = objDb.GetDataSetUsingCmdObj(objCommand);
                    txtCourseTitle2.Text = courseInfo.Tables[0].Rows[0][0].ToString();
                }

                if (e.CommandName == "ActivateCourse")
                {
                    //int rowIndex = int.Parse(e.CommandArgument.ToString());
                    //int courseId = Int32.Parse(gvCourseControl.DataKeys[rowIndex].Value.ToString());
                    //string requestedId = gvCourseControl.Rows[rowIndex].Cells[0].Text;

                    GridViewRow row = gvCourseControl.Rows[rowIndex];
                    string checkStatus = ((Button)(row.Cells[7].Controls[0])).Text;

                    txtCourseNumber.Text = checkStatus;

                    if (checkStatus == "Y")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateCourseStatus";

                        objCommand.Parameters.AddWithValue("@inCourseId", courseId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "N");

                        objDb.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "Y";
                        Response.Redirect("AdminCreateCourse.aspx");
                    }

                    else if (checkStatus == "N")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "updateCourseStatus";

                        objCommand.Parameters.AddWithValue("@inCourseId", courseId);
                        objCommand.Parameters.AddWithValue("@inActiveInd", "Y");

                        objDb.DoUpdateUsingCmdObj(objCommand);

                        Session["activation"] = "N";
                        Response.Redirect("AdminCreateCourse.aspx");
                    }
                }
            }
        }

        protected void btnEditCourse_Click(object sender, EventArgs e)
        {
            string requestedId = Session["requestedId"].ToString();

            String courseCollege = ddlColleges2.SelectedValue; //college code
            String courseTitle = txtCourseTitle2.Text; //string
            String courseNumber = txtCourseNumber2.Text; // string
            String courseArea = ddlCourseArea2.SelectedValue; // code
            int courseDepartment = 0;
            Int32.TryParse(ddlDepartment2.DataValueField, out courseDepartment); // integer
            String courseSubjectCode = txtSubjectCode2.Text; // code

            SqlCommand objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "editCourse";

            objCmd.Parameters.AddWithValue("@inCourseId", requestedId);
            objCmd.Parameters.AddWithValue("@inCourseTitle", courseTitle);
            objCmd.Parameters.AddWithValue("@inCourseNum", courseNumber);
            objCmd.Parameters.AddWithValue("@inSubjectCd", courseSubjectCode);
            objCmd.Parameters.AddWithValue("@inAreaCd", courseArea);
            objCmd.Parameters.AddWithValue("@inDeptId", courseDepartment);

            objDb.DoUpdateUsingCmdObj(objCmd);

            Session["requestedId"] = null;

            string message = "Your modification has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            gvCourseControl_Bind();
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string requestedId = Session["temp"].ToString();
        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "deleteCourse";

        //    SqlParameter inputParameter = new SqlParameter("@inCourseId", requestedId);
        //    inputParameter.Direction = ParameterDirection.Input;
        //    inputParameter.SqlDbType = SqlDbType.VarChar;
        //    objCommand.Parameters.Add(inputParameter);

        //    objDb.DoUpdateUsingCmdObj(objCommand);

        //    Session["temp"] = null;
        //    Response.Redirect("AdminCreateCourse.aspx");
        //}

        protected void gvCourseControl_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCourseControl.PageIndex = e.NewPageIndex;
            gvCourseControl_Bind();
        }

        protected void gvCourseControl_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["CourseData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvCourseControl.DataSource = Session["CourseData"];
                gvCourseControl.DataBind();
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

        protected void upCreateModal_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDown_Bind();
            }
            DataSet departments = getDepartments(ddlColleges.SelectedValue);
            ddlDepartment.DataSource = departments;
            ddlDepartment.DataTextField = "DeptNm";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
        }

        protected void upEditModal_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDown_Bind();
            }
            DataSet departments = getDepartments(ddlColleges2.SelectedValue);
            ddlDepartment2.DataSource = departments;
            ddlDepartment2.DataTextField = "DeptNm";
            ddlDepartment2.DataValueField = "DeptId";
            ddlDepartment2.DataBind();
        }
    }
}