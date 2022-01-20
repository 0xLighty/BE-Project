using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace Project_OnlineQuiz
{
    
    public partial class register : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();

        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                string enrollment = Session["Enrollment"].ToString();
                DataTable dt = new DataTable();
                dt = obj.sel("select fName,lName from users where enroll='" + enrollment + "'");
                string fname = dt.Rows[0][0].ToString();
                string lname = dt.Rows[0][1].ToString();
                //string year = dt.Rows[0][2].ToString();
                txt_enroll.Text = enrollment;
                txt_fname.Text = fname;
                txt_lname.Text = lname;
                //drp_year.Text = year;
                get_categoryydrp();
                get_branchdrp();
                get_yeardrp();
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
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
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
                    for (int i = 0; i <=5 ; i++ )
                    {
                        DateTime datee = DateTime.Now.AddYears(i);
                        string myYear = datee.Year.ToString();
                        drp_year.Items.Insert(i , myYear);
                    }
                }
                catch (Exception ex)
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }


        public void get_categoryydrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
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
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }
        protected void btn_register_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                string enrollment = Session["Enrollment"].ToString();
                string q = "update users set email='" + txt_email.Text + "',pass='" + txt_pass.Text + "',mobile='" + txt_mobile.Text + "',sem='" + drp_sem.SelectedValue + "',branch='" + drp_branch.SelectedValue + "',passOutYear='" + drp_year.SelectedValue + "' where enroll='" + enrollment + "'";
                string query = "insert into users(enroll,fName,lName,email,pass) values('" + txt_enroll.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_email.Text + "','" + txt_pass.Text + "')";
                int value = obj.ins_upd_del(q);
                try{
                   if (value == 1){
                        Response.Redirect("~/index2.aspx?register=successfull");
                        }
                   else{
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Email is already in use";
                   }
                }catch (Exception ex)
                    {
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                    }
                
            }
            else
            {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Please fill all the requirements";
            }

        }
    }
}