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
    public partial class categoryitem : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string cid = Request.QueryString["cid"];
            if (cid == null)
            {
                Response.Redirect("index2.aspx");
            }
            subjectlistmethod(Convert.ToInt32(cid));
            categorynamemethod(Convert.ToInt32(cid));
            DataTable dt = new DataTable();

        }


        public void subjectlistmethod(int id)
        {
            string q = "select * from subject where category_fid = " + id + "";
            try
            {
                DataTable dt = new DataTable();
                dt = obj.sel(q);
                if (dt.Rows.Count > 0)
                {
                    gridview_categoryitem.DataSource = dt;
                    gridview_categoryitem.DataBind();
                }
                else
                {
                    panel_subjectshow_warning.Visible = true;
                    lbl_subjectshowwarning.Text = "Sorry! There is no subject in this category";
                }
            }
            catch (Exception ex)
            {
                panel_subjectshow_warning.Visible = true;
                lbl_subjectshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            }
        }
        
        
        public void categorynamemethod(int id)
        {
            DataTable dt = new DataTable();
            
            string q = "select category_name from category where category_id=" + id + "";
                try
                {
                
                dt = obj.sel(q);
                    
                        lbl_categorysubject.Text = dt.Rows[0][0].ToString();
                    
                }
                catch (Exception ex)
                {
                    panel_subjectshow_warning.Visible = true;
                    lbl_subjectshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem " + ex.Message;
                }
            }
        }
    }

