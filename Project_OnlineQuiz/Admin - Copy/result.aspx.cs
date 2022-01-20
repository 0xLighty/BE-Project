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
    public partial class result : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string uemail = Request.QueryString["uid"];
            if (!IsPostBack)
            {
                if (uemail != null)
                {
                    getspecificresults(uemail);
                    gridviewspecific.Visible = true;
                    gridresult.Visible = false;
                }
                else
                {
                    getallresults();
                    gridviewspecific.Visible = false;
                    gridresult.Visible = true;
                }

            }
        }




        public void getallresults()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select * from result left join exam on result.exam_fid = exam.exam_id", con);
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridresult.DataSource = tb;
                                gridresult.DataBind();
                            }
                            else
                            {
                                panel_resultshow_warning.Visible = true;
                                lbl_resultshowwarning.Text = "There is no result right now in this application";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_resultshow_warning.Visible = true;
                    lbl_resultshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }



        public void getspecificresults(string email)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select * from result,exam where user_email='"+email+"' AND exam_fid=exam_id;", con);

                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridviewspecific.DataSource = tb;
                                gridviewspecific.DataBind();
                            }
                            else
                            {
                                panel_resultshow_warning.Visible = true;
                                lbl_resultshowwarning.Text = "There is no result right now in this application";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_resultshow_warning.Visible = true;
                    lbl_resultshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }

        protected void gridresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridresult.PageIndex = e.NewPageIndex;
            getallresults();
            gridviewspecific.Visible = false;
            gridresult.Visible = true;
        }


        protected void gridviewspecific_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string uemail = Request.QueryString["uid"];
            gridviewspecific.PageIndex = e.NewPageIndex;
            getspecificresults(uemail);
            gridviewspecific.Visible = true;
            gridresult.Visible = false;
        }



    }
}