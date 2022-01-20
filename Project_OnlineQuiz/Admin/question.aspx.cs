using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace Project_OnlineQuiz.Admin
{
    public partial class question : System.Web.UI.Page
    {
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        DBHelperr obj = new DBHelperr();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }

            if (!IsPostBack) {
                get_categoryyedrp();
            }
            if (Session["rcf"].ToString() == "done")
            {
                
                //getallquestion();
            }
        }

        protected void btn_q_Click(object sender, EventArgs e)
        {
            getallquestion();

        }

        protected void gridview_examquestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview_examquestion.PageIndex = e.NewPageIndex;
            getallquestion();
        }
        //string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //method for getting question 
        public void getallquestion()
        {
            DataTable dt = new DataTable();
                try
                {
                    dt = obj.sel("select question.id,exam_name,question_name,exam.exam_id,question.exam_id,question_id from exam,question where exam.exam_id=question.exam_id AND question.exam_id='"+drp_EId.SelectedValue.ToString()+"'");
                    gridview_examquestion.DataSource = dt;
                    gridview_examquestion.DataBind();
                        
                    
                }
                catch (Exception ex)
                {
                    panel_examquestion_warning.Visible = true;
                    lbl_examquestionwarning.Text = "Something went wrong. Pleas contact your provider </br>" + ex.Message;
                }

            
        }

        public void get_categoryyedrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct exam_id from exam", con);
                try
                {
                    con.Open();
                    drp_EId.DataSource = cmd.ExecuteReader();
                    drp_EId.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select exam_id", "-1");
                    drp_EId.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    drp_EId.Focus();

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
                string eid = drp_EId.SelectedValue.ToString();
                MySqlCommand cmd = new MySqlCommand("delete from question where question_id = "+id+" AND exam_id='"+eid+"'", con);
                //cmd.Parameters.AddWithValue("@questionid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("~/admin/question.aspx");
                        Response.Write("Delete Succesfully");
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


        protected void gridview_examquestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletequestion")
            {
                deletequestion(Convert.ToInt32(e.CommandArgument));
            }
        }
    }
}