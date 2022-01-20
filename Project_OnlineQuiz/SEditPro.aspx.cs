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

namespace Project_OnlineQuiz
{
    public partial class SEditPro : System.Web.UI.Page
    {
        public static String examId;
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie usercookie = Request.Cookies["user_cookies"];
            if (Session["Enrollment"] != null || usercookie != null)
            {
               
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            if (string.IsNullOrEmpty(Session["Enrollment"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
            try
            {
                if (Session["rc"].ToString() == "done")
                {

                    if (!IsPostBack)
                    {

                        panel_profile.Visible = true;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        panel_password.Visible = false;
                        btn_panelProfile.BackColor = ColorTranslator.FromHtml("#343A40");
                        btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
                        getProfile();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                panel2.Visible = true;
                Label2.Visible = true;
                Label2.Text = "Something went wrong.</br>" + ex.Message;
            }
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
                    Label2.Focus();
                    Label2.Visible = true;
                    Label2.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_yeardrp()
        {
            //using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                //MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {

                    //ListItem li = new ListItem("Select branch", "-1");
                    for (int i = 0; i <= 5; i++)
                    {
                        DateTime datee = DateTime.Now.AddYears(i);
                        string myYear = datee.Year.ToString();
                        drp_year.Items.Insert(i, myYear);
                    }
                }
                catch (Exception ex)
                {
                    Label2.Visible = true;
                    Label2.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
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
                    Label2.Focus();
                    Label2.Visible = true;
                    Label2.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        protected void getProfile()
        {
            get_branchdrp();
            get_semdrp();
            get_yeardrp();
            MySqlConnection con1 = new MySqlConnection(connectionString);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            String myEmail = Session["Enrollment"].ToString();
            MySqlCommand myCommand = new MySqlCommand("select * from users where enroll = " + myEmail + "", con1);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                txt_facId.Text = (myReader["enroll"].ToString());
                txt_fName.Text = (myReader["fName"].ToString());
                txt_lName.Text = (myReader["lName"].ToString());

                txt_email.Text = (myReader["email"].ToString());
                txt_mobile.Text = (myReader["mobile"].ToString());
                drp_branch.SelectedValue = (myReader["branch"].ToString());
                drp_sem.SelectedValue = (myReader["sem"].ToString());
                drp_year.SelectedValue = (myReader["passOutYear"].ToString());
            }
            con1.Close();
        }


        protected void btn_panelProfile_Click(object sender, EventArgs e)
        {
            panel_profile.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel_password.Visible = false;
            btn_panelProfile.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            getProfile();
        }


        protected void btn_passEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_NewPassword.Text.CompareTo(txt_RePassword.Text) != 0)
                {
                    panel3.Visible = true;
                    Label1.Visible = true;
                    Label1.Text = "Password not matched!";
                    txt_NewPassword.Text = "";
                    txt_RePassword.Text = "";
                }
                else
                {
                    panel3.Visible = true;
                    DBHelper.Class1 obj = new DBHelper.Class1();
                    obj.ins_upd_del("update users set pass = '" + txt_NewPassword.Text + "' where enroll = " + txt_facId.Text + "");
                    Label1.Text = "Password Change Successfully!!";
                    Response.Redirect("index2.aspx");
                }
            }
            catch (Exception ex)
            {
                panel3.Visible = true;
                Label1.Text = ex.Message;
            }


        }

        protected void btn_panelPassword_Click(object sender, EventArgs e)
        {
            panel_profile.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel_password.Visible = true;
            btn_panelProfile.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#343A40");

        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.Class1 obj = new DBHelper.Class1();
                obj.ins_upd_del("update users set fName = '" + txt_fName.Text + "', lName = '" + txt_lName.Text + "', branch = '" + drp_branch.Text + "', sem = '" + drp_sem.Text + "', passOutYear = '" + drp_year.Text + "',mobile = '" + txt_mobile.Text + "', email = '" + txt_email.Text + "' where enroll = " + txt_facId.Text + "");
                Label2.Visible = true;
                Label2.Text = "Profile updated successfully!";
                Response.Redirect("index2.aspx");
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                Label2.Visible = true;
            }
        }

    }
}