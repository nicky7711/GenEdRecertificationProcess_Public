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

namespace GenEdRecertification_v2._0
{
    public partial class AdminCreateCoursePackage : System.Web.UI.Page
    {
        Course Course = new Course();
        SqlCommand objCommand = new SqlCommand();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}