using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS4396Solution
{
    public partial class AdminHome : System.Web.UI.Page
    {
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["packageId"] = 0;

            if (!IsPostBack)
            {
                if (Session["adminValid"] != null)
                {
                    ViewState["SortExpression"] = "CourseTitle";
                    ViewState["SortDirection"] = "ASC";
                    gvPackages_Bind();
                    DropDownBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void gvPackages_Bind()
        {
            DataSet dsYr = AcademicYr();
            string academicYr = dsYr.Tables[0].Rows[0][0].ToString(); ;
            DataSet packageList = PackageInfo(academicYr);
            DataTable dt = packageList.Tables[0];
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvPackages.DataSource = dt;

            String[] packageId = new String[1];
            packageId[0] = "PackageId";
            gvPackages.DataKeyNames = packageId;
            gvPackages.DataBind();
            Session["PackageData"] = dt;
        }

        void DropDownBind()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Get_AcademicYear";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);


            // DataTable courseData = CourseInfo();
            ddlAcademicYear.DataSource = myDS;
            ddlAcademicYear.DataValueField = "AcademicYrCd";
            ddlAcademicYear.DataTextField = "AcademicYrCd";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Academic Year", "0"));

        }

        protected DataTable CourseInfo()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Get_Courses";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("CourseId");
            newDT.Columns.Add("CourseTitle");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["CourseId"] = myDS.Tables[0].Rows[i].ItemArray[0] + " " + myDS.Tables[0].Rows[i].ItemArray[3].ToString();
                newDR["CourseTitle"] = myDS.Tables[0].Rows[i].ItemArray[1].ToString() + " - " + myDS.Tables[0].Rows[i].ItemArray[2].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
        }

        protected DataSet PackageInfo(string academicYrCd)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPackage_ByAcademicYear";

            SqlParameter inputParameter = new SqlParameter("@inAcademicYrCd", academicYrCd);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }
        protected DataSet AcademicYr()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AcademicYr_AdminPageLoad";
            
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }
        protected void gvPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int packageId = Int32.Parse(gvPackages.DataKeys[rowIndex].Value.ToString());

                if (e.CommandName == "ViewPackage")
                {
                    Session.Remove("PackageId");
                    Session["PackageId"] = packageId;
                    Response.Redirect("AdminViewCoursePackage.aspx");
                }
                if (e.CommandName == "EditPackage")
                {
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "GetPackage_PackageId";

                    SqlParameter inputParameter = new SqlParameter("@inPackageId", packageId);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 10;
                    objCommand.Parameters.Add(inputParameter);

                    DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);

                    txtCourseName.Text = myDS.Tables[0].Rows[0][3].ToString();
                    txtCourseNumber.Text = myDS.Tables[0].Rows[0][2].ToString();

                    Session["temp"] = packageId;
                }
            }
        }

        protected void viewCoursePackage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewCoursePackage.aspx");
        }

        //protected void btnClear_Click(object sender, EventArgs e)
        //{
        //    txtNumberSearch.Text = null;
        //    txtTitleSearch.Text = null;
        //    txtCourseArea.Text = null;
        //    ddlAcademicYear.SelectedIndex = 0;

        //    gvPackages.DataSource = PackageInfo("2016-2017");
        //    //Add code to dynamically grab the AcademicYearCode
        //    String[] packageId = new String[1];
        //    packageId[0] = "PackageId";
        //    gvPackages.DataKeyNames = packageId;
        //    gvPackages.DataBind();


        //}

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string AcademicYr = ddlAcademicYear.SelectedValue.ToString();
            string courseNm = txtTitleSearch.Text;
            string CourseNum = txtNumberSearch.Text;
            //string SubjCd = txtSubjectCodeSearch.Text;
            string Area = txtCourseArea.Text;


            gvPackages.DataSource = getFiltering(AcademicYr, courseNm, CourseNum, Area);
            gvPackages.DataBind();
            String[] packageId = new String[1];
            packageId[0] = "PackageId";
            gvPackages.DataKeyNames = packageId;



        }

        private DataSet getFiltering(string aYr, string cNm, string cNum, string area)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AdminHome_Filter";

            //SqlParameter paramAcademicYr = new SqlParameter("@inAcademicYrCd", "2016-2017");
            //SqlParameter paramTitle = new SqlParameter("@inCourseNm", txtTitleSearch);
            //SqlParameter paramNum = new SqlParameter("@inCourseNum", txtNumberSearch);
            //SqlParameter paramSubjCd = new SqlParameter("@inSubjectCd", txtSubjectCodeSearch);
            //SqlParameter paramArea = new SqlParameter("@inArea", txtCourseArea);
            //status parameter


            objCommand.Parameters.AddWithValue("@inAcademicYr", aYr);
            objCommand.Parameters.AddWithValue("@inCourseNm", cNm);
            objCommand.Parameters.AddWithValue("@inCourseNum", cNum);
            objCommand.Parameters.AddWithValue("@inArea", area);
            objCommand.Parameters.AddWithValue("@inSubjectCd", "");

            DataSet filter = objDB.GetDataSetUsingCmdObj(objCommand);

            return filter;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string requestedPackageId = Session["temp"].ToString();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editPackage";

            objCommand.Parameters.AddWithValue("@inPackageId", requestedPackageId);
            objCommand.Parameters.AddWithValue("@inDeadline", txtDeadline.Text);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["temp"] = null;
            Response.Redirect("AdminHome.aspx");
            gvPackages_Bind();
        }

        protected void gvPackages_OnPageIndexChaning(object sender, GridViewPageEventArgs e)
        {
            gvPackages.PageIndex = e.NewPageIndex;
            gvPackages_Bind();
        }

        protected void gvPackages_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["PackageData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvPackages.DataSource = Session["PackageData"];
                gvPackages.DataBind();
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

        protected void btnCreatePackage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCreateCoursePackage.aspx");
        }

    }
}