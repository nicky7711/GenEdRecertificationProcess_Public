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
    public partial class AdminCreateCoursePackage : System.Web.UI.Page
    {
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownBind();
                Session["newPackageId"] = 0;
                Session.Remove("courseTitle");
            }
        }

        void DropDownBind()
        {
            DataTable courseData = CourseInfo();
            ddlCourses.DataSource = courseData;
            ddlCourses.DataValueField = "CourseId";
            ddlCourses.DataTextField = "CourseTitle";
            ddlCourses.DataBind();
            ddlCourses.Items.Insert(0, new ListItem("Course", "0"));

            DataTable userData = UserInfo();
            ddlCoordinator.DataSource = userData;
            ddlCoordinator.DataValueField = "AccessNetId";
            ddlCoordinator.DataTextField = "ContactInfo";
            ddlCoordinator.DataBind();
            ddlCoordinator.Items.Insert(0, new ListItem("Course Coordinator", "0"));

            DataTable yearData = YearInfo();
            ddlAcademicYear.DataSource = yearData;
            ddlAcademicYear.DataValueField = "AcademicYrCd";
            ddlAcademicYear.DataTextField = "AcademicYrDesc";
            ddlAcademicYear.DataBind();
            ddlAcademicYear.Items.Insert(0, new ListItem("Academic Year", "0"));
        }

        void DropDownReBind(string courseTitle)
        {
            DataTable courseData = CourseInfo_CourseTitle(courseTitle);
            ddlCourses.DataSource = courseData;
            ddlCourses.DataValueField = "CourseId";
            ddlCourses.DataTextField = "CourseTitle";
            ddlCourses.DataBind();
            ddlCourses.Items.Insert(0, new ListItem("Course", "0"));
        }

        protected DataTable UserInfo()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUsers_Coordinator";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("AccessNetId");
            newDT.Columns.Add("ContactInfo");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["AccessNetId"] = myDS.Tables[0].Rows[i].ItemArray[0].ToString();
                newDR["ContactInfo"] = myDS.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + myDS.Tables[0].Rows[i].ItemArray[1].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
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

        protected DataTable CourseInfo_CourseTitle(string courseTitle)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Get_Courses_CourseTitle";

            SqlParameter inputParameter = new SqlParameter("@inCourseTitle", courseTitle);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

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

        protected DataTable YearInfo()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Get_AcademicYear";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("AcademicYrCd");
            newDT.Columns.Add("AcademicYrDesc");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["AcademicYrCd"] = myDS.Tables[0].Rows[i].ItemArray[0];
                newDR["AcademicYrDesc"] = myDS.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + myDS.Tables[0].Rows[i].ItemArray[1].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
        }

        protected void btnCreateCoursePackage_Click(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedValue != "0")
            {
                int courseId = 0, deptId = 0, packageId = 0;

                string deptContactId = ddlCoordinator.SelectedValue;
                string deadline = txtDeadline.Text;

                char[] delimiterSpace = { ' ' };
                string[] courseInfo = ddlCourses.SelectedValue.Split(delimiterSpace);

                char[] delimiterDash = { '-' };
                string[] courseNumInfo = ddlCourses.SelectedItem.ToString().Split(delimiterDash);
                string courseTitle = courseNumInfo[0];
                Session["courseTitle"] = courseTitle;

                string probationStatus = "N";
                if (chkProbation.Checked == true)
                {
                    probationStatus = "Y";
                }

                courseId = Int32.Parse(courseInfo[0]);
                if (courseInfo[1] != "")
                {
                    deptId = Int32.Parse(courseInfo[1]);
                }

                if ((int)Session["newPackageId"] == 0)
                {
                    packageId = InsertPackage(ddlAcademicYear.SelectedValue, deadline, courseId, probationStatus);
                    Session["newPackageId"] = packageId;
                }
                else
                {
                    packageId = (int)Session["newPackageId"];
                }
                InsertPortfolio(packageId, deptContactId, courseId, deptId, deadline);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Open Modal", "openCommentModal();", true);
            }
            else
            {
                Response.Write("<script>alert('You must select a Course')</script>");
            }
        }

        protected int InsertPackage(string academicYrCd, string deadline, int courseId, string probationStatus)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Insert_NewPackage";

            SqlParameter inputParameter = new SqlParameter("@inAcademicYrCd", academicYrCd);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inDeadline", deadline);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inCourseId", courseId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inAreaCd", "GG");
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inOnProbation", probationStatus);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter();
            inputParameter.ParameterName = "@outPackageId";
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);

            int newPackageID = int.Parse(objCommand.Parameters["@outPackageId"].Value.ToString());
            return newPackageID;
        }

        protected void InsertPortfolio(int packageId, string deptContactId, int courseId, int deptId, string deadline)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertPortfolio";

            SqlParameter inputParameter = new SqlParameter("@inPackageId", packageId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inDeptContactId", deptContactId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inCourseId", courseId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inDeptId", deptId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inDeadline", deadline);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);
            
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ddlAcademicYear.Enabled = false;
            txtDeadline.Enabled = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Close Modal", "closeCommentModal();", true);
            string courseTitle = (string)Session["courseTitle"];
            DropDownReBind(courseTitle);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Session["newPackageId"] = 0;
            Session.Remove("courseTitle");
            Session.Remove("PackageCheck");
            Response.Redirect("AdminHome.aspx");
        }
    }
}