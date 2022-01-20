using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project_OnlineQuiz
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Admin.DBHelperr obj = new Admin.DBHelperr();

        protected void Page_Load(object sender, EventArgs e)
        {
           // DataTable dt_date = obj.sel("select examdate from assign where exam_id='3' AND enroll='" + enroll + "'");
            //DateTime dt_day = Convert.ToDateTime(dt_date.Rows[0]["examdate"].ToString());
           // Label1.Text = dt_day.ToString("dd-MM-yyyy");
        }
    }
}