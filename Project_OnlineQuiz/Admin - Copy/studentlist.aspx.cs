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
    public partial class studentlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rc"].ToString() == "done")
            {


                if (!IsPostBack)
                {

                    getallstudents();
                }
            }

        }
        //string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //method for get all result
        public void getallstudents()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bjay2\source\repos\Project_OnlineQuiz\Project_OnlineQuiz\App_Data\OnlineQuiz_Data.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand("select * from users", con);
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
                                gridallstudents.DataSource = tb;
                                gridallstudents.DataBind();
                            }
                            else
                            {
                                panel_studentlistshow_warning.Visible = true;
                                lbl_studentlistshowwarning.Text = "There is no result right now in this application";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_studentlistshow_warning.Visible = true;
                    lbl_studentlistshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }

        //for paging
        protected void gridallstudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridallstudents.PageIndex = e.NewPageIndex;
            getallstudents();
        }
    }
}