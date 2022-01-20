using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Project_OnlineQuiz.Admin
{
    public partial class login : System.Web.UI.Page
    {
        DBHelperr obj = new DBHelperr();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["fac_cookies"] != null)
            {
                HttpCookie reqCookies = Request.Cookies["fac_cookies"];
                Session["facemail"] = reqCookies["facemail"].ToString();
                Session["rcf"] = "done";
                Response.Redirect("Index.aspx");
            }

        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                string q = "select * from faculty where email='" + txt_email.Text + "' AND pass='" + txt_pass.Text + "'";

                    try
                    {

                    DataTable dt = new DataTable();
                    dt = obj.sel(q);
                        if (dt.Rows.Count>0)
                        {
                            if (chk_remember.Checked)
                            {
                                HttpCookie user = new HttpCookie("fac_cookies"); //creating cookie object where user_cookies is cookie name``
                                user["facemail"] = txt_email.Text; // cookie content
                                Session["facemail"] = txt_email.Text;
                                user.Expires = DateTime.Now.AddYears(1); // give the time/duration of cookie
                                Response.Cookies.Add(user); // it gives the response in browser
                            }
                            else
                            {
                                Session["facemail"] = txt_email.Text;
                            }
                            Session["rcf"] = "done";
                            Response.Redirect("Index.aspx");
                        }
                        else
                        {
                            pnl_warning.Visible = true;
                            lbl_warning.Text = "Use correct email and password</br>";
                        }

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