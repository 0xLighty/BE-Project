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
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Project_OnlineQuiz.Admin
{
    public partial class studentlist : System.Web.UI.Page
    {
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
                if (!IsPostBack)
                {
                    panel_showStudents.Visible = true;
                    
                    btn_panelresult.BackColor = ColorTranslator.FromHtml("#343A40");
                    
                    //getallstudents();
                    get_branchdrp();
                    get_semdrp();
                    get_yeardrp();
                }
            

        }
        protected void btn_panelShow_Click(object sender, EventArgs e) {
            panel_showStudents.Visible = true;
            
            btn_panelresult.BackColor = ColorTranslator.FromHtml("#343A40");
            
            get_branchdrp();
            get_semdrp();
            get_yeardrp();
            //getallstudents();
        }
        

        protected void btn_q_Click(object sender, EventArgs e) {

            getallstudents();

        }

        public void get_branchdrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {
                    con.Open();
                    drp_branch.DataSource = cmd.ExecuteReader();
                    drp_branch.DataBind();
                    ListItem li = new ListItem("Select branch", "-1");
                    drp_branch.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    //Label2.Focus();
                    //Label2.Visible = true;
                    //Label2.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_semdrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct category_name from semesters", con);
                try
                {
                    con.Open();
                    drp_sem.DataSource = cmd.ExecuteReader();
                    drp_sem.DataBind();
                    ListItem li = new ListItem("Select semester", "-1");
                    drp_sem.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    //Label2.Focus();
                    //Label2.Visible = true;
                    //Label2.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_yeardrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct passOutYear from users where passOutYear is not null ORDER BY passOutYear ASC", con);
                try
                {
                    con.Open();
                    drp_year.DataSource = cmd.ExecuteReader();
                    drp_year.DataBind();
                    ListItem li = new ListItem("Select year", "-1");
                    drp_year.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    //Label2.Focus();
                    //Label2.Visible = true;
                    //Label2.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }


        //string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //method for get all result
        public void getallstudents()
        {
            
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from users where branch = '" + drp_branch.SelectedValue.ToString() + "' and sem= " + drp_sem.SelectedValue + " and passOutYear = " + drp_year.SelectedValue + "", con);
                try
                {
                    con.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridallstudents.DataSource = tb;
                                gridallstudents.DataBind();
                                panel_studentlistshow_warning.Visible = false;
                            }
                            else
                            {
                                gridallstudents.DataSource = null;
                                gridallstudents.DataBind();
                                panel_studentlistshow_warning.Visible = true;
                                lbl_studentlistshowwarning.Text = "Something went wrong";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_studentlistshow_warning.Visible = true;
                    gridallstudents.DataSource = null;
                    gridallstudents.DataBind();
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