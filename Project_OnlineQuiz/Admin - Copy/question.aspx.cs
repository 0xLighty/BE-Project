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

namespace Project_OnlineQuiz.Admin
{
    public partial class question : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rc"].ToString() == "done")
            {
                getallquestion();
            }
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
                dt = obj.sel("select exam_name,question_name,exam_id,question_id from exam,question where exam_id=exam_fid");
                    gridview_examquestion.DataSource = dt;
                    gridview_examquestion.DataBind();
                        
                    
                }
                catch (Exception ex)
                {
                    panel_examquestion_warning.Visible = true;
                    lbl_examquestionwarning.Text = "Something went wrong. Pleas contact your provider </br>" + ex.Message;
                }

            
        }

        //method for deleting question for the question id 
        public void deletequestion(int id)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("delete question where question_id = "+id+"", con);
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