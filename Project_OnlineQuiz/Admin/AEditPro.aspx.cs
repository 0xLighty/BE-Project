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
    public partial class AEditPro : System.Web.UI.Page
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
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
            try
            {
                if (Session["rcf"].ToString() == "done")
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

        protected void getProfile()
        {
            get_branchdrp();
            MySqlConnection con1 = new MySqlConnection(connectionString);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            String myEmail = Session["facemail"].ToString();
            MySqlCommand myCommand = new MySqlCommand("select * from faculty where email = '" + myEmail + "'", con1);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                txt_facId.Text = (myReader["Id"].ToString());
                txt_fName.Text = (myReader["fName"].ToString());
                txt_lName.Text = (myReader["lName"].ToString());
                txt_email.Text = (myReader["email"].ToString());
                txt_mobile.Text = (myReader["mobile"].ToString());
                drp_branch.SelectedValue = (myReader["branch"].ToString());
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


        protected void btn_passEdit_Click(object sender, EventArgs e) {
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
                    DBHelperr obj = new DBHelperr();
                    obj.ins_up_del("update faculty set pass = '" + txt_NewPassword.Text + "' where Id = '" + txt_facId.Text + "'");
                    Label1.Text = "Password Change Successfully!!";
                    Response.Redirect("Index.aspx");
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

        protected void btn_edit_Click(object sender, EventArgs e) {
            try
            {
                DBHelperr obj = new DBHelperr();
                obj.ins_up_del("update faculty set fName = '" + txt_fName.Text + "', lName = '" + txt_lName.Text + "', branch = '" + drp_branch.Text + "',mobile = '" + txt_mobile.Text + "', email = '" + txt_email.Text + "' where Id = '" + txt_facId.Text + "'");
                Label2.Visible = true;
                Label2.Text = "Profile updated successfully!";
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                Label2.Visible = true;
            }
        }

    }
}