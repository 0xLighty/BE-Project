using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Project_OnlineQuiz.RealAdmin
{
    public partial class forgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.Class1 obj = new DBHelper.Class1();
                string passw, namee;
                
                DataTable dtt = new DataTable();
                
                dtt.Clear();
                

                dtt = obj.sel("select pass from admintab");
                
                //String password = dtt.Rows[0]["pass"].ToString(); //row["pass"].ToString();
                //String ema = row1["email"].ToString();
                if (dtt.Rows.Count != 0)
                {
                    namee = "Admin";
                    passw = dtt.Rows[0]["pass"].ToString();

                    MailMessage msg = new MailMessage();
                    DataTable dta = new DataTable();
                    dta.Clear();
                    dta = obj.sel("select * from recoverytable");
                    String mailfrom = dtt.Rows[0]["email"].ToString();
                    String mailPass = dtt.Rows[0]["pass"].ToString();
                    msg.From = new MailAddress(mailfrom);
                    msg.To.Add(mailfrom);
                    msg.Subject = " Recover your Password - VGEC_Online_Quiz";

                    msg.Body = ("Hello <b>" + namee + "</b>,<br/><br/>Your Password is: <b>" + passw + "</b><br/><br/>Thankyou");
                    msg.IsBodyHtml = true;

                    SmtpClient smt = new SmtpClient();
                    smt.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential ntwd = new NetworkCredential();
                    ntwd.UserName = mailfrom; //Your Email ID  
                    ntwd.Password = mailPass; // Your Password  
                    smt.UseDefaultCredentials = true;
                    smt.Credentials = ntwd;
                    smt.Port = 587;
                    smt.EnableSsl = true;
                    smt.Send(msg);
                    pnl_warning.Visible = true;
                    lbl_warning.Visible = true;
                    lbl_warning.Text = "Password Sent Successfully";
                    lbl_warning.ForeColor = System.Drawing.Color.ForestGreen;
                }

                else
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Visible = true;
                    lbl_warning.Text = "Ohh Ohh contact developers..They will guide you";
                    lbl_warning.ForeColor = System.Drawing.Color.Red;
                }
                //if (!string.IsNullOrEmpty(password))


            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong.." + ex.Message;
                lbl_warning.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}