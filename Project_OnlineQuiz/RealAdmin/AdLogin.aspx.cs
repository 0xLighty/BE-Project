using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_OnlineQuiz.RealAdmin
{
    public partial class AdLogin : System.Web.UI.Page
    {
        DBHelper.Class1 obj = new DBHelper.Class1();
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                
                try
                {
                    DataTable dt = new DataTable();
                    dt = obj.sel("select pass from admintab");
                    string pass = dt.Rows[0]["pass"].ToString();
                    //if (dt.Rows.Count > 0)
                    if (txt_email.Text == "adminvgec" && txt_pass.Text == pass)
                    {
                       
                            Session["Ademail"] = txt_email.Text;
                        
                        Session["rca"] = "done";
                        Response.Redirect("RIndex.aspx");
                    }
                    else
                    {
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Use correct username and password</br>";
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