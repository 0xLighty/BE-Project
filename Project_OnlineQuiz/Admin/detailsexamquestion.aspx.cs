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

namespace Project_OnlineQuiz.Admin
{
    public partial class detailsexamquestion : System.Web.UI.Page
    {
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
            string eid = Request.QueryString["eid"];
            if (!IsPostBack)
            {

                if (eid == null)
                {
                    Response.Redirect("~/admin/question.aspx");
                }
                getexamquestiondetails(Convert.ToInt32(eid));
            }

             
        }
        public void getexamquestiondetails(int id)
        {
            
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question.marks,question.id,exam_description,question_name,opt_one,opt_two,opt_three,opt_four,question_answer,question.popt_one,question.popt_two,question.popt_three,question.popt_four,question.myImg from exam,question where question.id='" + id+"'", con);
                
                try
                {
                    con.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            gridview_examdetails.DataSource = tb;
                            gridview_examdetails.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel_examdetails_warning.Visible = true;
                    lbl_examdetailswarning.Text = "Something went wrong. Pleas contact your provider </br>" + ex.Message;
                }

            }
        }

        protected void gridview_examdetails_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
}