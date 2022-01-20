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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                gettotalexam();
                gettotalquestion();
                gettotalstudents();
            
            
        }
       
        public void gettotalexam()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\DOT NET\Project\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\Database1.mdf;Integrated Security=True")) 
            {
                SqlCommand cmd = new SqlCommand("select count(exam_id) from exam", con);
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\DOT NET\Project\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\Database1.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select count(question_id) from question", con);
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\DOT NET\Project\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\Database1.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(user_id) FROM users", con);
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