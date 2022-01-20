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
    public partial class addadmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rc"].ToString() == "done")
            {
                
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void btn_addadmin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    SqlCommand cmd = new SqlCommand("insert into admin_data values('"+txt_adminame.Text+"','"+txt_admiemail.Text+"','"+txt_adminpass.Text+"')", con);
                    
                    try
                    {
                        con.Open();
                        
                        int value=cmd.ExecuteNonQuery();
                        
                        if (value > 1)
                        {
                            Response.Redirect("~/admin/Index.aspx");
                        }
                        else
                        {
                            txt_adminame.Focus();
                            panel_addamin_warning.Visible = true;
                            lbl_addaminwarning.Text = "Email is already in use";
                        }

                    }
                    catch (Exception ex)
                    {
                        txt_admiemail.Focus();
                        panel_addamin_warning.Visible = true;
                        lbl_addaminwarning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                    }
                }
            }
            else
            {
                txt_admiemail.Focus();
                panel_addamin_warning.Visible = true;
                lbl_addaminwarning.Text = "Please fill all the requirements";
            }
        }
    }
}