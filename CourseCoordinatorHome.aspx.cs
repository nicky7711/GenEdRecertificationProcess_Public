using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;

namespace CIS4396Solution
{
    public partial class CourseCoordinatorHome : System.Web.UI.Page
    {
        int portfolioId;
        string contactId;
        CoordinatorFile File = new CoordinatorFile();
        Portfolio Portfolio = new Portfolio();
        Questionnaire NewQuestionnaire = new Questionnaire();
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                contactId = (string)Session["ContactId"];
                if ((int)Session["CurrentPortfolioId"] != 0)
                {
                    portfolioId = (int)Session["CurrentPortfolioId"];
                    DataSet CurrentPortfolioDS = CurrentPortfolioInfo(portfolioId);
                    Portfolio = AssignPortfolioInfo(CurrentPortfolioDS);
                    ViewState["SortExpression"] = "ItemType";
                    ViewState["SortDirection"] = "ASC";
                    Bind();
                    ShowRevBtn();
                    if (!IsPostBack)
                    {
                        DropDownBind(contactId);
                    }
                }
                if (!IsPostBack && (int)Session["CurrentPortfolioId"] == 0)
                {
                    DataSet PortfolioDS = PortfolioInfo(contactId);
                    Portfolio = AssignPortfolioInfo(PortfolioDS);
                    Session["CurrentPortfolioId"] = Portfolio.PortfolioId;
                    ViewState["SortExpression"] = "ItemType";
                    ViewState["SortDirection"] = "ASC";
                    Bind();
                    DropDownBind(contactId);
                    ShowRevBtn();
                }

                DataSet CourseDS = CourseInfo(Portfolio.CourseId);
                Course = AssignCourseInfo(CourseDS);
                lblCourse.Text = Course.CourseTitle + " - " + Course.CourseSubjectNumber;
                
                DataSet deadLineCheck = CheckDeadLine(Portfolio.PortfolioId);
                string deadLine = Convert.ToString(deadLineCheck.Tables[0].Rows[0]["DeadLine"]);
                //if (deadLine == "LogOut")
                //{
                //    Response.Redirect("Login.aspx");
                //}
                if (deadLine == "PastDue")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeadlineModal();", true);
                    btnUpload.Enabled = false;
                    uploadMaterials.Enabled = false;
                    btnFinalReview.Enabled = false;
                    gvFiles.Enabled = false;
                    lblDeadline.Visible = true;
                    lblDeadline.Text = "SUBMISSION DEADLINE HAS PASSED.";
                }

            }
            catch (Exception ex)
            {
            }
        }


        void DropDownBind(string contactId)
        {
            DataTable courseData = DocumentInfo();
            ddlChooseItem.DataSource = courseData;
            ddlChooseItem.DataValueField = "DocumentTypeId";
            ddlChooseItem.DataTextField = "DocumentName";
            ddlChooseItem.DataBind();
            ddlChooseItem.Items.Insert(0, new ListItem("Select Document Type", "0"));

            DataTable portfoliosData = PortfoliosInfo(contactId);
            ddlPortfolios.DataSource = portfoliosData;
            ddlPortfolios.DataValueField = "PortfolioId";
            ddlPortfolios.DataTextField = "CourseTitle";
            ddlPortfolios.DataBind();
            ddlPortfolios.Items.Insert(0, new ListItem("Portfolio", "0"));
        }

        void Bind()
        {
            DataSet filesList = Files(Portfolio.PortfolioId);
            DataTable dt = filesList.Tables[0];
            if (dt.Rows.Count == 0)
            {
                lblFiles.Text = "No Files Uploaded";
                lblFiles.Visible = true;
            }
            else
            {
                lblFiles.Visible = false;
                dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
                gvFiles.DataSource = dt;

                String[] fileId = new String[1];
                fileId[0] = "FileId";
                gvFiles.DataKeyNames = fileId;
                gvFiles.DataBind();
                Session["FilesData"] = dt;
            }
        }

        protected DataTable DocumentInfo()
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "getDocumentTypeList";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("DocumentTypeId");
            newDT.Columns.Add("DocumentName");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["DocumentTypeId"] = myDS.Tables[0].Rows[i].ItemArray[0];
                newDR["DocumentName"] = myDS.Tables[0].Rows[i].ItemArray[1].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
        }

        protected DataTable PortfoliosInfo(string contactId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "Get_Portfolios";

            SqlParameter inputParameter = new SqlParameter("@inDeptContactId", contactId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable newDT = new DataTable();
            newDT.Columns.Add("PortfolioId");
            newDT.Columns.Add("CourseTitle");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["PortfolioId"] = myDS.Tables[0].Rows[i].ItemArray[0];
                newDR["CourseTitle"] = myDS.Tables[0].Rows[i].ItemArray[2].ToString() + " - " + myDS.Tables[0].Rows[i].ItemArray[3].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
        }

        protected DataSet CheckDeadLine(int portfolioID)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeadLineCheck";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        protected DataSet PortfolioInfo(string contactId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPortfolio_Contact";

            SqlParameter inputParameter = new SqlParameter("@inContactId", contactId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected DataSet CurrentPortfolioInfo(int portfoloId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetPortfolio_PortfolioId";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfoloId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected void ShowRevBtn()
        {
            string reviewer = Session["switchButton"].ToString();
                //bool.Parse(Session["reviewerValid"].ToString());
            if (reviewer == "true")
            {
                btnSwitchType.Visible = true;
            }
            else
                btnSwitchType.Visible = false;
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

        protected DataSet CourseInfo(int courseId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCourse_Portfolio";

            SqlParameter inputParameter = new SqlParameter("@CourseId", courseId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected Portfolio AssignPortfolioInfo(DataSet portfolioDS)
        {
            DataSet myDS = portfolioDS;
            Portfolio.PortfolioId = (int)objDB.GetField("PortfolioId", 0);
            Portfolio.PackageId = (int)objDB.GetField("PackageId", 0);
            Portfolio.CourseId = (int)objDB.GetField("CourseId", 0);
            Portfolio.ContactId = (string)objDB.GetField("DeptContactId", 0);
            if (objDB.GetField("PortfolioComments", 0).ToString() != "")
            {
                Byte[] byteArray = (Byte[])objDB.GetField("PortfolioComments", 0);
                BinaryFormatter deSerializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream(byteArray);
                Portfolio.Questionnaire = (Questionnaire)deSerializer.Deserialize(memStream);
            }

            return Portfolio;
        }

        protected Questionnaire Answers(DataSet QuestionnaireDS)
        {
            DataSet myDS = QuestionnaireDS;
            Byte[] byteArray = (Byte[])objDB.GetField("PortfolioComments", 0);

            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(byteArray);

            NewQuestionnaire = new Questionnaire();
            NewQuestionnaire = (Questionnaire)deSerializer.Deserialize(memStream);

            return NewQuestionnaire;
        }

        protected Course AssignCourseInfo(DataSet courseDS)
        {
            DataSet myDS = courseDS;
            Course.CourseId = (int)objDB.GetField("CourseId", 0);
            Course.CourseTitle = (string)objDB.GetField("CourseTitle", 0);
            Course.CourseNumber = (string)objDB.GetField("CourseNum", 0);
            Course.SubjectCode = (string)objDB.GetField("SubjectCd", 0);
            Course.CourseSubjectNumber = (string)objDB.GetField("CourseSubjectNum", 0);
            Course.AreaCode = (string)objDB.GetField("AreaCd", 0);
            Course.DeptId = (int)objDB.GetField("DeptId", 0);

            return Course;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            string path = uploadMaterials.PostedFile.FileName;

            if (uploadMaterials.HasFile && ddlChooseItem.SelectedValue != "0")
            {
                String fileExtension = System.IO.Path.GetExtension(uploadMaterials.FileName).ToLower();
                String[] allowedExtensions = { ".pdf" };

                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        SaveFile_Procedure(Portfolio.PortfolioId);
                    }
                    catch (Exception ex)
                    {
                        lblDisplay.Text = "File could not be uploaded.";
                    }
                }
                else
                {
                    lblDisplay.Text = "Cannot accept files of this type, please convert to a .pdf file.";
                }
            }
            else
            {
                lblDisplay.Text = "Please select a Document Type (Assignment Prompt, Example of Student Work, Narrative, or Syllabi) and a File before Uploading";
            }
        }

        protected void SaveFile_Procedure(int portfolioId)
        {

            string fileName = uploadMaterials.FileName.ToString();
            string contentType = uploadMaterials.PostedFile.ContentType;
            string itemType = ddlChooseItem.SelectedItem.Text;

            using (Stream fileStream = uploadMaterials.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fileStream))
                {
                    byte[] bytes = br.ReadBytes((Int32)fileStream.Length);

                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "InsertFiles";

                    SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.Int;
                    inputParameter.Size = 10;
                    objCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@inFileName", fileName);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 100;
                    objCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@inFileType", contentType);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;
                    objCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@inFileData", bytes);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarBinary;
                    inputParameter.Size = bytes.Length;
                    objCommand.Parameters.Add(inputParameter);

                    inputParameter = new SqlParameter("@inItemType", itemType);
                    inputParameter.Direction = ParameterDirection.Input;
                    inputParameter.SqlDbType = SqlDbType.VarChar;
                    inputParameter.Size = 50;
                    objCommand.Parameters.Add(inputParameter);

                    objDB.DoUpdateUsingCmdObj(objCommand);
                }
            }
            Response.Redirect("CourseCoordinatorHome.aspx");
        }

        public void DeleteFile(int fileId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteFile";

            SqlParameter inputParameter = new SqlParameter("@inFileId", fileId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void btnFinalReview_Click(object sender, EventArgs e)
        {
            Session.Remove("Portfolio");
            Session["Portfolio"] = Portfolio;
            Session.Remove("Course");
            Session["Course"] = Course;
            Response.Redirect("CourseCoordinatorRubricQuestionnaire.aspx");
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int fileID = Int32.Parse(gvFiles.DataKeys[rowIndex].Value.ToString());

                if (e.CommandName == "RemoveFile")
                {
                    DeleteFile(fileID);
                    Bind();
                }
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
            gvFiles.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void btnSwitchType_Click(object sender, EventArgs e)
        {
            Session["reviewerValid"] = true;
            Response.Redirect("ReviewerHome.aspx");
        }

        protected void ddlPortfolios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int portfolioId = Int32.Parse(ddlPortfolios.SelectedValue);
            Session["CurrentPortfolioId"] = portfolioId;
            Response.Redirect("CourseCoordinatorHome.aspx");
        }

        }
    }