using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_OnlineQuiz.Admin
{
    public partial class detailsexamquestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select exam_description,question_name,option_one,option_two,option_three,option_four,question_answer from exam,question where " + id + "=exam_fid", con);
                
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
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
    }
}