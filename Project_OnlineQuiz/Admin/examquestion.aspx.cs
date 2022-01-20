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
    public partial class examquestion : System.Web.UI.Page
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
                    Response.Redirect("~/admin/exam.aspx");
                }
                getexamquestion(eid);
            }
        }


        protected void gridview_examquestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteexamquestion")
            {
                deletequestion(Convert.ToInt32(e.CommandArgument));
            }
        }
        //for paging
        protected void gridview_examquestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string eid = Request.QueryString["eid"];
            gridview_examquestion.PageIndex = e.NewPageIndex;
            getexamquestion(eid);
        }
        //string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //method for getting question for the exam id
        public void getexamquestion(string id)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question.id,question.exam_id,question_id,exam_name,question_name from exam,question where exam.exam_id=" + id+" AND question.exam_id='"+id +"'", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@examfid", id);
                try
                {
                    con.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            gridview_examquestion.DataSource = tb;
                            gridview_examquestion.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel_examquestion_warning.Visible = true;
                    lbl_examquestionwarning.Text = "Something went wrong. Pleas contact your provider </br>" + ex.Message;
                }

            }
        }

        //method for deleting question for the question id 
        public void deletequestion(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {

                MySqlCommand cmd = new MySqlCommand("delete from question where question_id = @questionid", con);
                cmd.Parameters.AddWithValue("@questionid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        id--;
                        DBHelperr obj = new DBHelperr();
                        string eid = Request.QueryString["eid"];
                        int temp=obj.ins_up_del("update exam set exam_marks='" + id + "',exam_totalquestions='" + id + "' where exam_id='"+eid+"'");
                        if (temp == 1)
                        {
                            Response.Redirect("~/admin/exam.aspx");
                            Response.Write("Delete Succesfully");
                        }
                        else
                        {
                            panel_examquestion_warning.Visible = true;
                            lbl_examquestionwarning.Text = "Something went wrong. Can't update exam table";
                        }
                    }
                    else
                    {
                        panel_examquestion_warning.Visible = true;
                        lbl_examquestionwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_examquestion_warning.Visible = true;
                    lbl_examquestionwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }
    }
}