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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["rc"] as string))
            {
                if (Session["rc"].ToString() == "done")
                {
                    Response.Redirect("index2.aspx");
                }
            }
            
        }
        
        protected void btn_login_Click(object sender, EventArgs e)
        {
            Page.Validate("validategroupname");
            if (!Page.IsValid)
            {
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    try
                    {
                        dt1 = obj.sel("select pass from users where enroll = '" + txt_email.Text + "'");
                        if (dt1.Rows.Count > 0)
                        {
                            DataRow row = dt1.Rows[0];
                            String password = row["pass"].ToString();
                            if (password == "")
                            {
                                pnl_warning.Visible = true;
                                //lbl_warning.Text = password;
                                lbl_warning.Text = "First Time LOgin password</br>";
                                if (txt_email.Text == txt_pass.Text) {
                                    if (chk_remember.Checked)
                                    {
                                        HttpCookie user = new HttpCookie("user_cookies");
                                        user["Enrollment"] = txt_email.Text;
                                        Session["Enrollment"] = txt_email.Text;
                                        user.Expires = DateTime.Now.AddYears(1);
                                        Response.Cookies.Add(user);
                                    }
                                    else
                                    {
                                        Session["Enrollment"] = txt_email.Text;
                                    }
                                    Session["rc"] = "done";
                                //DataTable dt2 = new DataTable();
                                //dt2 = obj.sel("select email from users where enroll='" + txt_email.Text + "'");
                                
                                    Response.Redirect("register.aspx");
                                }
                                else
                                {
                                    pnl_warning.Visible = true;
                                    lbl_warning.Text = "Enter Correct Password</br>";
                                }
                                
                            }
                            else {
                                pnl_warning.Visible = true;
                                lbl_warning.Text = "Old User</br>";
                                if (txt_pass.Text == password)
                                {
                                    if (chk_remember.Checked)
                                    {
                                        HttpCookie user = new HttpCookie("user_cookies");
                                        user["Enrollment"] = txt_email.Text;
                                        Session["Enrollment"] = txt_email.Text;
                                        user.Expires = DateTime.Now.AddYears(1);
                                        Response.Cookies.Add(user);
                                    }
                                    else
                                    {
                                        Session["Enrollment"] = txt_email.Text;
                                    }
                                    Session["rc"] = "done";
                                    Response.Redirect("index2.aspx");
                                }
                                else {
                                    pnl_warning.Visible = true;
                                    lbl_warning.Text = "Enter Correct Password</br>";
                                }
                            }
                        }
                        
                        //dt = obj.sel("select enroll from users where enroll='" + txt_email.Text + "' AND pass='" + txt_pass.Text + "'");
                    }
                    
                    catch (Exception ex)
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