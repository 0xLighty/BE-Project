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
    public partial class addquestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rc"].ToString() == "done")
            {
                if (!IsPostBack)
                {
                    string eid = Request.QueryString["eid"];
                    if (eid == null)
                    {
                        Response.Redirect("~/admin/exam.aspx");
                    }
                }
            }
        }

        protected void btn_addquestion_Click(object sender, EventArgs e)
        {
            string eid = Request.QueryString["eid"];
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    SqlCommand cmd = new SqlCommand("insert into question values('"+txt_questionname.Text+"','"+txt_optionone.Text+"','"+txt_optiontwo.Text+"','"+txt_optionthree.Text+"','"+txt_optionfour.Text+"','"+rdo_correctanswer.SelectedValue+"',"+eid+")", con);
                    
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("~/admin/exam.aspx");
                        }
                        else
                        {
                            txt_questionname.Focus();
                            panel_addquestion_warning.Visible = true;
                            lbl_addquestionwarning.Text = "Try again. Subject is not added";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_questionname.Focus();
                        panel_addquestion_warning.Visible = true;
                        lbl_addquestionwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } 
            }
            else
            {
                txt_questionname.Focus();
                panel_addquestion_warning.Visible = true;
                lbl_addquestionwarning.Text = "You must fill all the requirements";
            }
        }
    }
}