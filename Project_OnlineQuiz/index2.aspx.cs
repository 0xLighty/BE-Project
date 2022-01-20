using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace Project_OnlineQuiz
{
    public partial class index2 : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["rc"] as string))
            {
                Response.Redirect("Home.aspx");

            }
            else
            {
                if (Session["rc"].ToString() == "done")
                {
                    categorylistmethod();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        
        public void categorylistmethod()
        {

            String enrollment = Session["Enrollment"].ToString();
                DataTable dt = new DataTable();
                
                try
                {
                string query = "select exam_id from assign where enroll="+enrollment+"";
                dt = obj.sel(query);
                string q = "select exam_id,exam_name,exam_description,exam_date,exam_duration,exam_marks,exam_negativemarks,exam_totalquestions,exam_pass from exam where ";
                int count = dt.Rows.Count;
                    if (dt.Rows.Count>0)
                    {
                        //gridview_categorylist.DataSource = dt;
                        
                        //gridview_categorylist.DataBind();
                        foreach(DataRow row in dt.Rows)
                        {
                            string temp = row["exam_id"].ToString();
                            
                            if (row == dt.Rows[count - 1])
                            {
                                q += "exam_id=" + temp + "";
                            }
                            else
                            {
                                q += "exam_id=" + temp + " OR ";
                            }
                            
                        }
                    DataTable dt1 = new DataTable();
                    dt1 = obj.sel(q);
                    gridview_categorylist.DataSource = dt1;
                    gridview_categorylist.DataBind();
                    }
                    else
                    {
                        panel_categoryshow_warning.Visible = true;
                        lbl_categoryshowwarning.Text = "Sorry! There is no exam assigned to you, contact respective faculty";
                    }

                }
                catch (Exception ex)
                {
                    panel_categoryshow_warning.Visible = true;
                    lbl_categoryshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem " + ex.Message;
                }
            }


        
    }

    }
