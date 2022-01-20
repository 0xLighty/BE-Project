using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Project_OnlineQuiz
{
    public partial class myresult : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie usercookie = Request.Cookies["user_cookies"];
            if (Session["Enrollment"] != null || usercookie != null)
            {
                if (Session["Enrollment"] == null)
                {
                    getemail.Text = usercookie["Enrollment"];
                }
                else
                {
                    getemail.Text = Session["Enrollment"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                getmyresults(getemail.Text);
            }
        }

        protected void gridmyresult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        
        public void getmyresults(string email)
        {
            string enrollment = Session["Enrollment"].ToString();
            DataTable dt = new DataTable();
            
            if (Request.QueryString["eid"]==null)
                dt = obj.sel("select result.user_enroll,exam.exam_name,exam.exam_date,exam.exam_totalquestions,result.status,exam.exam_marks,result.score from result left join exam on result.exam_fid = exam.exam_id where result.user_enroll='"+enrollment+"'");
            else{
                string eid1 = Request.QueryString["eid"];
                dt = obj.sel("select result.user_enroll,exam.exam_name,exam.exam_date,exam.exam_totalquestions,result.status,exam.exam_marks,result.score from result left join exam on result.exam_fid = exam.exam_id where result.user_enroll='" + enrollment + "' and result.exam_fid = '"+eid1+"'");
            }
            try
            {
                if (dt.Rows.Count > 0)
                {
                    gridmyresult.DataSource = dt;
                    gridmyresult.DataBind();
                }
                else
                {
                    panel_myresultshow_warning.Visible = true;
                    lbl_myresultshowwarning.Text = "Sorry! There is no result of any exam";
                }
            } catch (Exception ex)
                {
                    panel_myresultshow_warning.Visible = true;
                    lbl_myresultshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        

        protected void gridmyresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridmyresult.PageIndex = e.NewPageIndex;
            getmyresults(getemail.Text);
        }
    }
}