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
    public partial class CourseCoordinatorRubricQuestionnaire : System.Web.UI.Page
    {
        Questionnaire CurrentQuestionnaire = new Questionnaire();
        Portfolio Portfolio = new Portfolio();
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Portfolio = (Portfolio)Session["Portfolio"];
                if (!IsPostBack)
                {
                    Questionnaire NewQuestionnaire = Portfolio.Questionnaire;
                    txtFaculty.Text = NewQuestionnaire.Question1;
                    txtFewer.Text = NewQuestionnaire.Question2;
                    txtTA.Text = NewQuestionnaire.Question3;
                    txtIndividual.Text = NewQuestionnaire.Question4;
                    Course = (Course)Session["Course"];

                    lblCourse.Text = Course.CourseTitle + " - " + Course.CourseSubjectNumber;
                    ViewState["SortExpression"] = "ItemType";
                    ViewState["SortDirection"] = "ASC";
                    Bind();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Bind()
        {
            gvFiles.DataSource = Files(Portfolio.PortfolioId);
            String[] fileId = new String[1];
            fileId[0] = "FileId";
            gvFiles.DataKeyNames = fileId;
            gvFiles.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = "";

            if (txtFaculty.Text == "" || txtFewer.Text == "" || txtIndividual.Text == "" || txtTA.Text == "")
            {
                message = "Please answer all questions before submitting.";
            }
            else
            {
                message = "Thank you for submitting your Portfolio.";
                SubmitPortfolio(CurrentQuestionnaire);
            }
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "Message", script, true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SubmitPortfolio(CurrentQuestionnaire);
            string message = "Your questionnaire has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void SubmitPortfolio(Questionnaire questionnaire)
        {
            questionnaire.Question1 = txtFaculty.Text;
            questionnaire.Question2 = txtFewer.Text;
            questionnaire.Question3 = txtTA.Text;
            questionnaire.Question4 = txtIndividual.Text;

            //Create the memory stream and stream writer, then write the PortfolioComments object
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytes;
            serializer.Serialize(memStream, questionnaire);
            bytes = memStream.ToArray();

            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SubmitPortfolio";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", Portfolio.PortfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inAnswers", bytes);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarBinary;
            inputParameter.Size = bytes.Length;
            objCommand.Parameters.Add(inputParameter);


            objDB.DoUpdateUsingCmdObj(objCommand);
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

    }
}