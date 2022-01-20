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
using MySql.Data.MySqlClient;

namespace Project_OnlineQuiz.Admin
{
    public partial class Index : System.Web.UI.Page
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
                nameLoad();
                gettotalexam();
                gettotalquestion();
                gettotalstudents();
            
            
        }

        public void nameLoad() {
            int nom;
            String myEmail = Session["facemail"].ToString();
            panel1.Visible = true;
            DataTable dt1 = new DataTable();
            dt1 = obj.sel("select fName, lName from faculty where email = '" + myEmail + "'");
            if (dt1.Rows.Count > 0)
            {
                String fn = dt1.Rows[0]["fName"].ToString();
                String ln = dt1.Rows[0]["lName"].ToString();
                Label1.Visible = true;
                Label1.Text = "Welcome " + fn + " " + ln;// +Session["facemail"].ToString();
            }
            else { }

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct count(exam_id) from exam where setter = '" + myEmail + "'", con);
                try
                {
                    con.Open();
                    nom = Convert.ToInt32(cmd.ExecuteScalar());
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label3.Text = "No. of exams you've created: ";
                    Label4.ForeColor = System.Drawing.Color.Red;
                    Label4.Text = ""+nom;
                    //lbltotalexam.Text = i.ToString();

                }
                catch (Exception ex) {
                    panel_index_warning.Visible = true;
                    lbl_indexwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                
                }
            }

            DataTable dt12 = new DataTable();
            dt12 = obj.sel("select distinct count(exam_id) from exam where setter = '" + myEmail + "'");
        }

        public void gettotalexam()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString)) 
            {
                MySqlCommand cmd = new MySqlCommand("select distinct count(exam_id) from question", con);
                try
                {
                    con.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    //lbltotalexam.Text = i.ToString();

                }
                catch (Exception ex)
                {
                    panel_index_warning.Visible = true;
                    lbl_indexwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }

        //method for getting all the question 
        public void gettotalquestion()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select count(question_id) from question", con);
                try
                {
                    con.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    //lbltotalquestion.Text = i.ToString();

                }
                catch (Exception ex)
                {
                    panel_index_warning.Visible = true;
                    lbl_indexwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }

        //method for getting all the students 
        public void gettotalstudents()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(enroll) FROM users", con);
                try
                {
                    con.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    //lbltotalstudents.Text = i.ToString();

                }
                catch (Exception ex)
                {
                    panel_index_warning.Visible = true;
                    lbl_indexwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }
    }
}