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

namespace CIS4396Solution
{
    public partial class AdminCompletedReviews : System.Web.UI.Page
    {
        int courseId = 0;
        Portfolio Portfolio = new Portfolio();
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Portfolio = (Portfolio)Session["Portfolio"];
                courseId = (int)Session["CourseId"];

                gvQuestionnaire.DataSource = QuestionnaireInfo(Portfolio.PortfolioId);
                String[] questionnaireId = new String[1];
                questionnaireId[0] = "QuestionnaireId";
                gvQuestionnaire.DataKeyNames = questionnaireId;
                gvQuestionnaire.DataBind();
            }
            catch (Exception ex)
            {
            }
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

        protected void gvQuestionnaire_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int questionnaireId = Int32.Parse(gvQuestionnaire.DataKeys[rowIndex].Value.ToString());

            if (e.CommandName == "ViewQuestionnaire")
            {
                Session["QuestionnaireId"] = questionnaireId;
                Response.Redirect("AdminViewQuestionnaire.aspx");
            }
        }
    }
}