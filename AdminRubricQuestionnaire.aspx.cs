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
    public partial class AdminRubricQuestionnaire : System.Web.UI.Page
    {
        string userId = "";
        int courseId = 0, QuestionnaireId = 0;
        bool Exists = false, Check = false;
        Portfolio Portfolio = new Portfolio();
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();
        Questionnaire Questionnaire = new Questionnaire();
        Questionnaire NewQuestionnaire = new Questionnaire();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Portfolio = (Portfolio)Session["Portfolio"];
                courseId = (int)Session["CourseId"];
                userId = (string)Session["ContactId"];
                Load_AreaQuestions(courseId);
                QuestionnaireExists(Portfolio.PortfolioId, userId);
                if (!IsPostBack)
                {
                    FillInAnswers(Deserialize(QuestionnaireInfo(Portfolio.PortfolioId, userId)));
                }

                //lblCourse.Text = Course.CourseTitle + " - " + Course.CourseSubjectNumber;
            }
            catch (Exception ex)
            {
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewerLandingPage.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Answers();
            if (Exists == false)
            {
                SaveQuestionnaire(Questionnaire, userId, Portfolio.PortfolioId);
            }
            else
            {
                UpdateQuestionnaire(Questionnaire, userId, Portfolio.PortfolioId, QuestionnaireId);
            }
            string message = "Your questionnaire has been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = "";
            string script = "window.onload = function(){ alert('";
            Answers();

            if (Check == false)
            {
                if (Exists == false)
                {
                    SaveQuestionnaire(Questionnaire, userId, Portfolio.PortfolioId);
                }
                else
                {
                    UpdateQuestionnaire(Questionnaire, userId, Portfolio.PortfolioId, QuestionnaireId);
                }
                message = "Your questionnaire has been submitted successfully.";
            }
            else
            {
                message = "Please answers all questions before submitting your questionnaire.";
            }
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void QuestionnaireExists(int portfolioId, string userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetQuestionnaire_User/Portfolio";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inUserId", userId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            if ((int)objDB.GetField("QuestionnaireId", 0) != null)
            {
                Exists = true;
                QuestionnaireId = (int)objDB.GetField("QuestionnaireId", 0);
            }
        }

        protected DataSet QuestionnaireInfo(int portfolioId, string userId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetQuestionnaire_User/Portfolio";

            SqlParameter inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inUserId", userId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected void SaveQuestionnaire(Questionnaire questionnaire, string userId, int portfolioId)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytes;
            serializer.Serialize(memStream, questionnaire);
            bytes = memStream.ToArray();

            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertQuestionnaireAnswer";

            SqlParameter inputParameter = new SqlParameter("@inAnswers", bytes);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarBinary;
            inputParameter.Size = 8000;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inUserId", userId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void UpdateQuestionnaire(Questionnaire questionnaire, string userId, int portfolioId, int questionnaireId)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] bytes;
            serializer.Serialize(memStream, questionnaire);
            bytes = memStream.ToArray();

            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateQuestionnaireAnswer";

            SqlParameter inputParameter = new SqlParameter("@inAnswers", bytes);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarBinary;
            inputParameter.Size = 8000;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inUserId", userId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inPortfolioId", portfolioId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@inQuestionnaireId", questionnaireId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        protected void Answers()
        {
            if (radioFidelity1.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question1 = radioFidelity1.SelectedValue;

            if (chkVariance.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question2 = chkVariance.SelectedValue;

            if (txtDiscrepancy.Text == "")
                Check = true;
            else
                Questionnaire.Question3 = txtDiscrepancy.Text;

            if (radioPortfolios.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question4 = radioPortfolios.SelectedValue;

            if (radioConsistency1.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question5 = radioConsistency1.SelectedValue;

            if (chkInconsistency.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question6 = chkInconsistency.SelectedValue;

            if (txtProblematic.Text == "")
                Check = true;
            else
                Questionnaire.Question7 = txtProblematic.Text;

            if (txtOutline.Text == "")
                Check = true;
            else
                Questionnaire.Question8 = txtOutline.Text;

            if (radioFidelity2.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question9 = radioFidelity2.SelectedValue;

            if (radioFidelity3.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question10 = radioFidelity3.SelectedValue;

            if (txtFidelity.Text == "")
                Check = true;
            else
                Questionnaire.Question11 = txtFidelity.Text;

            if (radioConsistency2.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question12 = radioConsistency2.SelectedValue;

            if (radioConsistency3.SelectedValue == "")
                Check = true;
            else
                Questionnaire.Question13 = radioConsistency3.SelectedValue;

            if (txtConsistency.Text == "")
                Check = true;
            else
                Questionnaire.Question14 = txtConsistency.Text;

            if (chkYes1.Checked == true)
                Questionnaire.Question15 = true;
            if (chkYes2.Checked == true)
                Questionnaire.Question16 = true;
            if (chkYes3.Checked == true)
                Questionnaire.Question17 = true;

            if (txtAnswerNo1.Text == "")
                Check = true;
            else
                Questionnaire.Question18 = txtAnswerNo1.Text;

            if (chkYes4.Checked == true)
                Questionnaire.Question19 = true;
            if (chkYes5.Checked == true)
                Questionnaire.Question20 = true;
            if (chkYes6.Checked == true)
                Questionnaire.Question21 = true;

            if (txtAnswerNo2.Text == "")
                Check = true;
            else
                Questionnaire.Question22 = txtAnswerNo2.Text;

            if (chkYes7.Checked == true)
                Questionnaire.Question23 = true;
            if (chkYes8.Checked == true)
                Questionnaire.Question24 = true;
            if (chkYes9.Checked == true)
                Questionnaire.Question25 = true;
            if (chkYes9.Checked == true)
                Questionnaire.Question26 = true;
            if (chkYes9.Checked == true)
                Questionnaire.Question27 = true;
            if (chkYes9.Checked == true)
                Questionnaire.Question28 = true;
            if (chkYes9.Checked == true)
                Questionnaire.Question29 = true;

            if (txtComments.Text == "")
                Check = true;
            else
                Questionnaire.Question30 = txtComments.Text;

            if (radioRecommendation.SelectedValue == "")
                Check = true;
            else
            Questionnaire.Question31 = radioRecommendation.SelectedValue;

            if (txtFinalComments.Text == "")
                Check = true;
            else
            Questionnaire.Question32 = txtFinalComments.Text;
        }

        protected void FillInAnswers(Questionnaire questionnaire)
        {
            radioFidelity1.SelectedValue = NewQuestionnaire.Question1;
            chkVariance.SelectedValue = NewQuestionnaire.Question2;
            txtDiscrepancy.Text = NewQuestionnaire.Question3;
            radioPortfolios.SelectedValue = NewQuestionnaire.Question4;
            radioConsistency1.SelectedValue = NewQuestionnaire.Question5;
            chkInconsistency.SelectedValue = NewQuestionnaire.Question6;
            txtProblematic.Text = NewQuestionnaire.Question7;
            txtOutline.Text = NewQuestionnaire.Question8;
            radioFidelity2.SelectedValue = NewQuestionnaire.Question9;
            radioFidelity3.SelectedValue = NewQuestionnaire.Question10;
            txtFidelity.Text = NewQuestionnaire.Question11;
            radioConsistency2.SelectedValue = NewQuestionnaire.Question12;
            radioConsistency3.SelectedValue = NewQuestionnaire.Question13;
            txtConsistency.Text = NewQuestionnaire.Question14;

            if (NewQuestionnaire.Question15 == true)
            { chkYes1.Checked = true; }
            else { chkNo1.Checked = true; }

            if (NewQuestionnaire.Question16 == true)
            { chkYes2.Checked = true; }
            else { chkNo2.Checked = true; }

            if (NewQuestionnaire.Question17 == true)
            { chkYes3.Checked = true; }
            else { chkNo3.Checked = true; }

            txtAnswerNo1.Text = NewQuestionnaire.Question18;

            if (NewQuestionnaire.Question19 == true)
            { chkYes4.Checked = true; }
            else { chkNo4.Checked = true; }

            if (NewQuestionnaire.Question20 == true)
            { chkYes5.Checked = true; }
            else { chkNo5.Checked = true; }

            if (NewQuestionnaire.Question21 == true)
            { chkYes6.Checked = true; }
            else { chkNo6.Checked = true; }

            txtAnswerNo2.Text = NewQuestionnaire.Question22;

            if (NewQuestionnaire.Question23 == true)
            { chkYes7.Checked = true; }
            else { chkNo7.Checked = true; }

            if (NewQuestionnaire.Question24 == true)
            { chkYes8.Checked = true; }
            else { chkNo8.Checked = true; }

            if (NewQuestionnaire.Question25 == true)
            { chkYes9.Checked = true; }
            else { chkNo9.Checked = true; }

            if (NewQuestionnaire.Question26 == true)
            { chkYes10.Checked = true; }
            else { chkNo10.Checked = true; }

            if (NewQuestionnaire.Question27 == true)
            { chkYes11.Checked = true; }
            else { chkNo11.Checked = true; }

            if (NewQuestionnaire.Question28 == true)
            { chkYes12.Checked = true; }
            else { chkNo12.Checked = true; }

            if (NewQuestionnaire.Question29 == true)
            { chkYes13.Checked = true; }
            else { chkNo13.Checked = true; }

            txtComments.Text = NewQuestionnaire.Question30;
            radioRecommendation.SelectedValue = NewQuestionnaire.Question31;
            txtFinalComments.Text = NewQuestionnaire.Question32;
        }

        protected Questionnaire Deserialize(DataSet QuestionnaireDS)
        {
            DataSet myDS = QuestionnaireDS;
            Byte[] byteArray = (Byte[])objDB.GetField("Answers", 0);

            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(byteArray);

            NewQuestionnaire = new Questionnaire();
            NewQuestionnaire = (Questionnaire)deSerializer.Deserialize(memStream);

            return NewQuestionnaire;
        }

        protected void Load_AreaQuestions(int courseId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAreaQuestions_CourseId";

            SqlParameter inputParameter = new SqlParameter("@inCourseId", courseId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            lblQuestion1.Text = myDS.Tables[0].Rows[0].ItemArray[0].ToString();
            lblQuestion2.Text = myDS.Tables[0].Rows[1].ItemArray[0].ToString();
            lblQuestion3.Text = myDS.Tables[0].Rows[2].ItemArray[0].ToString();
            lblQuestion4.Text = myDS.Tables[0].Rows[3].ItemArray[0].ToString();
            lblQuestion5.Text = myDS.Tables[0].Rows[4].ItemArray[0].ToString();
        }
    }
}