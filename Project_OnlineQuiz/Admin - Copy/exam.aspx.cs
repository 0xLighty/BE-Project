using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace Project_OnlineQuiz.Admin
{
    public partial class exam : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rc"].ToString() == "done")
            {

                if (!IsPostBack)
                {

                    panel_examlist.Visible = true;
                    panel_addexam.Visible = false;
                    btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
                    btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");
                    getexamList();
                }
            }
        }
        protected void btn_panelexamlist_Click(object sender, EventArgs e)
        {
            panel_examlist.Visible = true;
            panel_addexam.Visible = false;
            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");
            getexamList();
        }
        protected void btn_paneladdexam_Click(object sender, EventArgs e)
        {
            panel_examlist.Visible = false;
            panel_addexam.Visible = true;
            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#343A40");
            get_categorydrp();
            get_subjectdrp();

        }

        
        protected void btn_addexam_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    SqlCommand cmd = new SqlCommand("insert into exam values('"+txt_examname.Text+ "','"+txt_examdis.Text+ "','"+txt_examdate.Text+ "','"+txt_examduration.Text+ "','" + txt_exammatotalmarks.Text + "','','"+ txt_exammatotalmarks.Text + "','" + drp_categoryexam.SelectedValue + "','" + drp_subjectexam.SelectedValue+ "','" + txt_exampassmarks.Text + "')", con);
                    
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
                            txt_examname.Focus();
                            panel_addexam_warning.Visible = true;
                            lbl_examaddwarning.Text = "Try again. Subject is not added";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } 
            }
            else
            {
                txt_examname.Focus();
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "You must fill all the requirements";
            }

        }

        protected void grdview_examlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteexam")
            {
                deleteexam(Convert.ToInt32(e.CommandArgument));
                getexamList();
            }
        }
        
        protected void grdview_examlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview_examlist.PageIndex = e.NewPageIndex;
            getexamList();
        }



   
        public void get_categorydrp()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select * from category", con);
                try
                {
                    con.Open();
                    drp_categoryexam.DataSource = cmd.ExecuteReader();
                    drp_categoryexam.DataBind();
                    ListItem li = new ListItem("Select category", "-1");
                    drp_categoryexam.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        //method for subject dropdown
        public void get_subjectdrp()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select subject_id, subject_name from subject", con);
                try
                {
                    con.Open();
                    drp_subjectexam.DataSource = cmd.ExecuteReader();
                    drp_subjectexam.DataBind();
                    ListItem li = new ListItem("Select subject", "-1");
                    drp_subjectexam.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }
        //method for examlist 
        public void getexamList()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select exam_id,category_name,subject_name,exam_name,exam_date from exam,subject,category where exam.category_fid=category.category_id AND exam.subject_fid=subject.subject_id", con);
                
                try
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            da.Fill(dtatble);
                            grdview_examlist.DataSource = dtatble;
                            grdview_examlist.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel_examlist_warning.Visible = true;
                    lbl_examlistwarning.Text = "Something went wrong </br>" + ex.Message;
                }
            }
        }
        
        public void deleteexam(int id)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("delete exam where exam_id = "+id+"", con);
                
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("~/admin/exam.aspx");
                        Response.Write("Delete Succesfully");
                    }
                    else
                    {
                        panel_examlist_warning.Visible = true;
                        lbl_examlistwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_examlist_warning.Visible = true;
                    lbl_examlistwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }
    }
}