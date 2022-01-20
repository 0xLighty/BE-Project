using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_OnlineQuiz
{
    public partial class usermaster : System.Web.UI.MasterPage
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie usercookie = Request.Cookies["user_cookies"];
                if (Session["Enrollment"] != null || usercookie != null)
                {
                    link_loginout.Text = "Log out";
                    nameLoad();
                }
                else
                {
                    link_loginout.Text = "Log in";
                }
            }
        }

        protected void link_facName_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SEditPro.aspx");
        }

        public void nameLoad()
        {

            String myEnroll = Session["Enrollment"].ToString();
            //panel1.Visible = true;
            DataTable dt1 = new DataTable();

            dt1 = obj.sel("select fName, lName from users where enroll = '" + myEnroll + "'");
            String fn = dt1.Rows[0]["fName"].ToString();
            String ln = dt1.Rows[0]["lName"].ToString();
            facName.Visible = true;
            facName.Text = fn + " " + ln;// +Session["facemail"].ToString();
        }
        //for clicking the log in out button
        protected void link_loginout_Click(object sender, EventArgs e)
        {
            if (link_loginout.Text == "Log out")
            {
                Response.Cookies["user_cookies"].Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Clear();
                Session.Remove("rc");
                Session.Remove("Enrollment");
                //Session.Clear();
                Response.Redirect("~/Login.aspx");
            }
            else if (link_loginout.Text == "Log in")
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}