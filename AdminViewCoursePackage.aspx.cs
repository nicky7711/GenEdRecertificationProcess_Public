﻿using System;
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
using System.Runtime.Serialization.Formatters.Binary;  

namespace CIS4396Solution
{
    public partial class AdminViewCoursePackage : System.Web.UI.Page
    {
        int packageId = 0;
        CoordinatorFile File = new CoordinatorFile();
        Portfolio Portfolio = new Portfolio();
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ViewState["SortExpression"] = "AreaCd";
                    ViewState["SortDirection"] = "ASC";
                    gvPortfolios_Bind();
                }
                packageId = (int)Session["PackageId"];
                DataSet CourseDS = CourseInfo(packageId);
                //Need session holding CourseId from AdminHome to show proper course when page loads, should come from package
                Course = AssignCourseInfo(CourseDS);
                lblCourse.Text = Course.CourseTitle;
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvPortfolios_Bind()
        {
            packageId = (int)Session["PackageId"];
            DataSet packageList = PortfolioInfo(packageId);
            DataTable dt = packageList.Tables[0];
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvPortfolios.DataSource = dt;

            String[] portfolioId = new String[1];
            portfolioId[0] = "PortfolioId";
            gvPortfolios.DataKeyNames = portfolioId;
            gvPortfolios.DataBind();
            Session["PortfolioId"] = dt;
        }

        protected DataSet PortfolioInfo(int packageId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPortfolio_PackageId";

            SqlParameter inputParameter = new SqlParameter("@inPackageId", packageId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet Files(int portfolioId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetFiles_Portfolio";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet SpecificFile(int fileId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetFile_FileId";

            SqlParameter inputParameter = new SqlParameter("@inFileId", fileId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet SpecificPortfolioInfo(int portfolioId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPortfolio_PortfolioId";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet CourseInfo(int packageId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPackage_PackageId";

            SqlParameter inputParameter = new SqlParameter("@inPackageId", packageId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet QuestionnaireInfo(int portfolioId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetQuestionnaire_Portfolio";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected Course AssignCourseInfo(DataSet courseDS)
        {
            DataSet myDS = courseDS;
            Course.CourseId = (int)objDB.GetField("CourseId", 0);
            Course.CourseTitle = (string)objDB.GetField("CourseTitle", 0);
            Course.CourseSubjectNumber = (string)objDB.GetField("CourseSubjectNum", 0);
            Course.AreaCode = (string)objDB.GetField("AreaCd", 0);

            return Course;
        }

        protected Portfolio AssignPortfolioInfo(DataSet portfolioDS)
        {
            DataSet myDS = portfolioDS;
            Portfolio.PortfolioId = (int)objDB.GetField("PortfolioId", 0);
            Portfolio.PackageId = (int)objDB.GetField("PackageId", 0);
            Portfolio.CourseId = (int)objDB.GetField("CourseId", 0);

            if (objDB.GetField("PortfolioComments", 0).ToString() != "")
            {
                Byte[] byteArray = (Byte[])objDB.GetField("PortfolioComments", 0);
                BinaryFormatter deSerializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream(byteArray);
                Portfolio.Questionnaire = (Questionnaire)deSerializer.Deserialize(memStream);
            }
            else 
            {
                Portfolio.Questionnaire = new Questionnaire();
            }

            Portfolio.ContactId = (string)objDB.GetField("DeptContactId", 0);

            return Portfolio;
        }

        protected void gvPortfolios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int portfolioId = Int32.Parse(gvPortfolios.DataKeys[rowIndex].Value.ToString());

                Session.Add("PortfolioID", portfolioId);
                Portfolio = AssignPortfolioInfo(SpecificPortfolioInfo(portfolioId));
                Session.Remove("Portfolio");
                Session["Portfolio"] = Portfolio;
                Session.Remove("CourseId");
                Session["CourseId"] = Course.CourseId;

                if (e.CommandName == "ViewPortfolio")
                {
                    DataSet myDS = Files(portfolioId);
                    if (myDS.Tables[0].Rows.Count == 0)
                    {
                        divFile1.Visible = true;
                        lblFiles.Text = "No Files Uploaded";
                        lblFiles.Visible = true;
                    }
                    else
                    {
                        lblFiles.Visible = false;
                        gvFiles.DataSource = myDS;
                        String[] fileId = new String[1];
                        fileId[0] = "FileId";
                        gvFiles.DataKeyNames = fileId;
                        gvFiles.DataBind();
                        gvFiles.Visible = true;
                        divFile1.Visible = true;
                        Session["FilesData"] = Files(portfolioId).Tables[0];
                        ViewState["SortExpression"] = "ItemType";
                        ViewState["SortDirection"] = "ASC";
                    }
                }
                if (e.CommandName == "ReviewPortfolio")
                {
                    Response.Redirect("AdminRubricQuestionnaire.aspx");
                }
                if (e.CommandName == "ViewQuestionnaire")
                {
                    Session["QuestionnaireId"] = 0;
                    Response.Redirect("AdminViewQuestionnaire.aspx");
                }
                if (e.CommandName == "EditPackage")
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

                    ddlCoordinator.DataSource = newDT;
                    ddlCoordinator.DataValueField = "AccessNetId";
                    ddlCoordinator.DataTextField = "ContactInfo";
                    ddlCoordinator.DataBind();

                    Session["temp"] = portfolioId;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);
                }
                if (e.CommandName == "Comments")
                {
                    lblComments1.Text = "1. Faculty who taught this course: <br/>" + Portfolio.Questionnaire.Question1;
                    lblComments2.Text = "2. If syllabi from fewer than two thirds of faculty are represented: <br/>" + Portfolio.Questionnaire.Question2;
                    lblComments3.Text = "3. The sections that were assigned a teaching assistant: <br/>" + Portfolio.Questionnaire.Question3;
                    lblComments4.Text = "4. Individuals who took part in coordinating & compiling: <br/>" + Portfolio.Questionnaire.Question4;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Open Modal", "openCommentModal();", true);
                }
            }
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int fileId = Int32.Parse(gvFiles.DataKeys[rowIndex].Value.ToString());

                if (e.CommandName == "ViewFile")
                {
                    Session["FileId"] = fileId;
                    Response.Redirect("ViewPDF.aspx");
                    //Page.ClientScript.RegisterStartupScript(
                    //this.GetType(), "OpenWindow", "window.open('ViewPDF.aspx','_newtab');", true);
                }
            }
        }

        public void ProcessRequest(HttpContext context, int fileId)
        {
            byte[] bytes;
            string fileName, contentType;

            DataSet File = SpecificFile(fileId);
            fileName = (string)objDB.GetField("FileNm", 0);
            contentType = (string)objDB.GetField("FileType", 0);
            bytes = (byte[])objDB.GetField("UploadFile", 0);

            context.Response.Buffer = true;
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }

        private DataSet getFiltering(string ItemType,int PortfolioId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "AdminFile_Filter";
            

            objCommand.Parameters.AddWithValue("@inItemType", ItemType);
            objCommand.Parameters.AddWithValue("@inPortfolioId", PortfolioId);

            DataSet filter = objDB.GetDataSetUsingCmdObj(objCommand);

            return filter;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string portfolioId = Session["temp"].ToString();
            string coordinator = ddlCoordinator.SelectedValue;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "editPortfolioContact";

            objCommand.Parameters.AddWithValue("@inPortfolioId", portfolioId);
            objCommand.Parameters.AddWithValue("@inDeptContactId", coordinator);
            objCommand.Parameters.AddWithValue("@inLastModUser", "Session");

            objDB.DoUpdateUsingCmdObj(objCommand);

            Session["temp"] = null;

            Response.Redirect("AdminViewCoursePackage.aspx");
        }

        protected void gvPortfolios_Sorting(object sender, GridViewSortEventArgs e)
        {

            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["PortfolioData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvPortfolios.DataSource = Session["PortfolioData"];
                gvPortfolios.DataBind();
            }

        }

        protected void gvFiles_Sorting(object sender, GridViewSortEventArgs e)
        {

            //Retrieve the table from the session object.
            DataTable dt = (DataTable)Session["FilesData"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvFiles.DataSource = Session["FilesData"];
                gvFiles.DataBind();
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

        protected void gvFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = (DataTable)Session["FilesData"];
            gvFiles.PageIndex = e.NewPageIndex;
            dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            gvFiles.DataSource = Session["FilesData"];
            gvFiles.DataBind();
        }
    }
}