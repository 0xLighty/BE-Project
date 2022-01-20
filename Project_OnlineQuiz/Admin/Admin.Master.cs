using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_OnlineQuiz.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie admincookie = Request.Cookies["fac_cookies"];
            if (Session["facemail"] != null || admincookie != null)
            {
                nameLoad();
                link_loginout.Text = "Log out";
            }
            else
            {
                link_loginout.Text = "Log in";
                Response.Redirect("~/admin/login.aspx");
            }
        }
        public void nameLoad()
        {
            DBHelperr obj = new DBHelperr();
            String myEmail = Session["facemail"].ToString();
            //panel1.Visible = true;
            DataTable dt1 = new DataTable();
            dt1 = obj.sel("select fName, lName from faculty where email = '" + myEmail + "'");
            String fn = dt1.Rows[0]["fName"].ToString();
            String ln = dt1.Rows[0]["lName"].ToString();
            facName.Visible = true;
            facName.Text =  fn + " " + ln;// +Session["facemail"].ToString();
        }

        protected void link_facName_Click(object sender, EventArgs e) {
            Response.Redirect("~/admin/AEditPro.aspx");
        }

        protected void link_loginout_Click(object sender, EventArgs e)
        {
            if (link_loginout.Text == "Log out")
            {
                Response.Cookies["fac_cookies"].Expires = DateTime.Now.AddYears(-1);
                Session.Clear();
                Response.Redirect("~/admin/Login.aspx");
            }
            else
            {
                link_loginout.Text = "Log in";
            }
        }
    }
}