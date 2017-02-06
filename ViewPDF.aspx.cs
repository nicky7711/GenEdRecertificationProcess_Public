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
    public partial class ViewPDF : System.Web.UI.Page
    {
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int fileId = (int)Session["FileId"];
                ProcessRequest(Context, fileId);
            }
            catch (Exception ex)
            {
            }
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
            context.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);     // to open file prompt Box open or Save file 
            context.Response.ContentType = "application/pdf";
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
        }
    }
}