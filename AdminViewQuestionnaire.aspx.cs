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
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace CIS4396Solution
{
    public partial class AdminViewQuestionnaire : System.Web.UI.Page
    {
        int questionnaireId = 0, courseId = 0;
        Questionnaire NewQuestionnaire = new Questionnaire();
        Portfolio Portfolio = new Portfolio();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Portfolio = (Portfolio)Session["Portfolio"];
                courseId = (int)Session["CourseId"];
                Load_AreaQuestions(courseId);
                if (!IsPostBack)
                {
                    DataTable userData = ContactInfo(Portfolio.PortfolioId);
                    ddlQuestionnaire.DataSource = userData;
                    ddlQuestionnaire.DataValueField = "QuestionnaireId";
                    ddlQuestionnaire.DataTextField = "UserId";
                    ddlQuestionnaire.DataBind();
                    ddlQuestionnaire.Items.Insert(0, new ListItem("Select Questionnaire", "0"));
                }
                questionnaireId = (int)Session["QuestionnaireId"];
                if (questionnaireId != 0)
                {
                    FillInAnswers(Answers(QuestionnaireInfo(questionnaireId)));
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected DataSet QuestionnaireInfo(int questionnaireId)
        {
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetQuestionnaire_QuestionnaireId";

            SqlParameter inputParameter = new SqlParameter("@inQuestionnaireId", questionnaireId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 10;
            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return myDS;
        }

        protected Questionnaire Answers(DataSet QuestionnaireDS)
        {
            DataSet myDS = QuestionnaireDS;
            Byte[] byteArray = (Byte[])objDB.GetField("Answers", 0);

            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(byteArray);

            NewQuestionnaire = new Questionnaire();
            NewQuestionnaire = (Questionnaire)deSerializer.Deserialize(memStream);

            return NewQuestionnaire;
        }

        protected DataTable ContactInfo(int portfolioId)
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
            DataTable newDT = new DataTable();
            newDT.Columns.Add("QuestionnaireId");
            newDT.Columns.Add("UserId");

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                DataRow newDR = newDT.NewRow();
                newDR["QuestionnaireId"] = myDS.Tables[0].Rows[i].ItemArray[0].ToString();
                newDR["UserId"] = myDS.Tables[0].Rows[i].ItemArray[4].ToString() + " - " + myDS.Tables[0].Rows[i].ItemArray[2].ToString() + ": " + myDS.Tables[0].Rows[i].ItemArray[0].ToString();
                newDT.Rows.Add(newDR);
            }

            return newDT;
        }

        protected void ddlQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            questionnaireId = Int32.Parse(ddlQuestionnaire.SelectedValue);
            Session["QuestionnaireId"] = questionnaireId;
            Response.Redirect("AdminViewQuestionnaire.aspx");
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
            {radioYes1.Checked = true;}
            else { radioNo1.Checked = true; }

            if (NewQuestionnaire.Question16 == true)
            { radioYes2.Checked = true; }
            else { radioNo2.Checked = true; }

            if (NewQuestionnaire.Question17 == true)
            { radioYes3.Checked = true; }
            else { radioNo3.Checked = true; }

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
            { radioYes9.Checked = true; }
            else { radioNo9.Checked = true; }

            if (NewQuestionnaire.Question26 == true)
            { radioYes10.Checked = true; }
            else { radioNo10.Checked = true; }

            if (NewQuestionnaire.Question27 == true)
            { radioYes11.Checked = true; }
            else { radioNo11.Checked = true; }

            if (NewQuestionnaire.Question28 == true)
            { radioYes12.Checked = true; }
            else { radioNo12.Checked = true; }

            if (NewQuestionnaire.Question29 == true)
            { radioYes13.Checked = true; }
            else { radioNo13.Checked = true; }

            txtComments.Text = NewQuestionnaire.Question30;
            radioRecommendation.SelectedValue = NewQuestionnaire.Question31;
            txtFinalComments.Text = NewQuestionnaire.Question32;
        }

        protected string[] WriteAnswers(Questionnaire questionnaire)
        {
            string replacement = "";
            string[] Answers = new string[32];

            Answers[0] = questionnaire.Question1 + ",";
            Answers[1] = questionnaire.Question2 + ",";
            replacement = Regex.Replace(questionnaire.Question3, @"\t|\n|\r", " ");
            Answers[2] = replacement + ",";
            Answers[3] = questionnaire.Question4 + ",";
            Answers[4] = questionnaire.Question5 + ",";
            Answers[5] = questionnaire.Question6 + ",";
            replacement = Regex.Replace(questionnaire.Question7, @"\t|\n|\r", " ");
            Answers[6] = replacement + ",";
            replacement = Regex.Replace(questionnaire.Question8, @"\t|\n|\r", " ");
            Answers[7] = replacement + ",";
            Answers[8] = questionnaire.Question9 + ",";
            Answers[9] = questionnaire.Question10 + ",";
            replacement = Regex.Replace(questionnaire.Question11, @"\t|\n|\r", " ");
            Answers[10] = replacement + ",";
            Answers[11] = questionnaire.Question12 + ",";
            Answers[12] = questionnaire.Question13 + ",";
            replacement = Regex.Replace(questionnaire.Question14, @"\t|\n|\r", " ");
            Answers[13] = replacement + ",";

            if (questionnaire.Question15 == true)
            { Answers[14] = "Yes" + ","; }
            else { Answers[14] = "No" + ","; }

            if (questionnaire.Question16 == true)
            { Answers[15] = "Yes" + ","; }
            else { Answers[15] = "No" + ","; }

            if (questionnaire.Question17 == true)
            { Answers[16] = "Yes" + ","; }
            else { Answers[16] = "No" + ","; }

            replacement = Regex.Replace(questionnaire.Question18, @"\t|\n|\r", " ");
            Answers[17] = replacement + ",";

            if (questionnaire.Question19 == true)
            { Answers[18] = "Yes" + ","; }
            else { Answers[18] = "No" + ","; }

            if (questionnaire.Question20 == true)
            { Answers[19] = "Yes" + ","; }
            else { Answers[19] = "No" + ","; }

            if (questionnaire.Question21 == true)
            { Answers[20] = "Yes" + ","; }
            else { Answers[20] = "No" + ","; }

            replacement = Regex.Replace(questionnaire.Question22, @"\t|\n|\r", " ");
            Answers[21] = replacement + ",";

            if (questionnaire.Question23 == true)
            { Answers[22] = "Yes" + ","; }
            else { Answers[22] = "No" + ","; }

            if (questionnaire.Question24 == true)
            { Answers[23] = "Yes" + ","; }
            else { Answers[23] = "No" + ","; }

            if (questionnaire.Question25 == true)
            { Answers[24] = "Yes" + ","; }
            else { Answers[24] = "No" + ","; }

            if (questionnaire.Question26 == true)
            { Answers[25] = "Yes" + ","; }
            else { Answers[25] = "No" + ","; }

            if (questionnaire.Question27 == true)
            { Answers[26] = "Yes" + ","; }
            else { Answers[26] = "No" + ","; }

            if (questionnaire.Question28 == true)
            { Answers[27] = "Yes" + ","; }
            else { Answers[27] = "No" + ","; }

            if (questionnaire.Question29 == true)
            { Answers[28] = "Yes" + ","; }
            else { Answers[28] = "No" + ","; }

            replacement = Regex.Replace(questionnaire.Question30, @"\t|\n|\r", " ");
            Answers[29] = replacement + ",";
            Answers[30] = questionnaire.Question31 + ",";
            replacement = Regex.Replace(questionnaire.Question32, @"\t|\n|\r", " ");
            Answers[31] = replacement;

            return Answers;
        }

        protected void Export_Answers(int portfolioId)
        {
            List<Questionnaire> QuestionnaireList = new List<Questionnaire>();
            DataTable myDT = ContactInfo(portfolioId);

            for (int i = 0; i < myDT.Rows.Count; i++)
            {
                Byte[] byteArray = (Byte[])objDB.GetField("Answers", i);

                BinaryFormatter deSerializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream(byteArray);

                NewQuestionnaire = new Questionnaire();
                NewQuestionnaire = (Questionnaire)deSerializer.Deserialize(memStream);
                QuestionnaireList.Add(NewQuestionnaire);
            }

            Response.ContentType = "text/plain";

            Response.AddHeader("content-disposition", "attachment;filename=" + "C" + Portfolio.CourseId + "_P" + Portfolio.PortfolioId + string.Format("members-{0}.csv", string.Format("{0:ddMMyyyy}", DateTime.Today)));
            Response.Clear();

            foreach (Questionnaire Questionnaire in QuestionnaireList)
            {
                string[] answersArray = new string[32];
                answersArray = WriteAnswers(Questionnaire);
                StringBuilder answersString = new StringBuilder();

                for (int i = 0; i < answersArray.Length; i++)
                {
                    answersString.Append(answersArray[i]);
                }
                using (StreamWriter sw = new StreamWriter(Response.OutputStream, Encoding.UTF8))
                {
                    sw.WriteLine(answersString);
                }
            }
            Response.End();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Export_Answers(Portfolio.PortfolioId);
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