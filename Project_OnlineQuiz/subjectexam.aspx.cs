using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_OnlineQuiz
{
    public partial class subjectexam : System.Web.UI.Page
    {
        
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sid = Request.QueryString["sid"];
            if (sid == null)
            {
                Response.Redirect("category.aspx");
            }
            examlistmethod(Convert.ToInt32(sid));
            subjectnamemethod(Convert.ToInt32(sid));

            HyperLink d = new HyperLink();
            

        }
        

        //string s = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        //method for examlist
        public void examlistmethod(int id)
        {
            
            string q = "select exam_name,exam_description,exampass_marks,exam_marks,exam_id from exam where subject_fid=1";
            DataTable dt = new DataTable();
            
                try
                {
                dt = obj.sel(q);
                if (dt.Rows.Count>0)
                    {
                        gridview_sujectexam.DataSource = dt;
                        gridview_sujectexam.DataBind();
                    }
                    else
                    {
                        panel_examshow_warning.Visible = true;
                        lbl_examshowwarning.Text = "Sorry! There is no exam in this subject";
                    }
                }
                catch (Exception ex)
                {
                    panel_examshow_warning.Visible = true;
                    lbl_examshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        
        //method for sujectlist
        public void subjectnamemethod(int id)
        {
           
                string q = "select subject_name from subject where subject_id = " + id + "";
                DataTable dt = new DataTable();
                try
                {
                    dt = obj.sel(q);
                   
                    lbl_subjectexam.Text = dt.Rows[0][0].ToString();
                       
                    
                }
                catch (Exception ex)
                {
                    panel_examshow_warning.Visible = true;
                    lbl_examshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem " + ex.Message;
                }
            }

        protected void gridview_sujectexam_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
    }

