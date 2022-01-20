﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
 

namespace Project_OnlineQuiz
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnl_warning.Visible = false;
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.Class1 obj = new DBHelper.Class1();
                string email, first, last, passw, namee;
                //DataTable dt = new DataTable();
                DataTable dtt = new DataTable();
                //dt.Clear();
                dtt.Clear();
                //dt = obj.sel("select email,pass,fName,lName from users where enroll = '" + txt_email.Text + "'");

                dtt = obj.sel("select email,pass,fName,lName from users where enroll = '" + txt_email.Text + "'");
                //DataRow row = dtt.Rows[0];
               // DataRow row1 = dt.Rows[0];
                String password = dtt.Rows[0]["pass"].ToString(); //row["pass"].ToString();
                //String ema = row1["email"].ToString();
                if (dtt.Rows.Count != 0 && password != "")
                {
                    email = dtt.Rows[0]["email"].ToString();
                    first = dtt.Rows[0]["fName"].ToString();
                    last = dtt.Rows[0]["lName"].ToString();
                    namee = first +" "+ last;
                    passw = dtt.Rows[0]["pass"].ToString();

                    MailMessage msg = new MailMessage();
                    DataTable dta = new DataTable();
                    dta.Clear();
                    dta = obj.sel("select * from recoverytable");
                    String mailfrom = dtt.Rows[0]["email"].ToString();
                    String mailPass = dtt.Rows[0]["pass"].ToString();
                    msg.From = new MailAddress(mailfrom);
                    msg.To.Add(email);
                    msg.Subject = " Recover your Password - VGEC_Online_Quiz";

                    msg.Body = ("Hello <b>" + namee + "</b>,<br/><br/>Your Enrollment number is: <b>" + txt_email.Text + "</b> <br/><br/>" + "Your Password is: <b>" + passw + "</b><br/><br/>Thankyou");
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
                    lbl_warning.Text = "Username and Password Sent Successfully";
                    lbl_warning.ForeColor = System.Drawing.Color.ForestGreen;
                }

                else
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Visible = true;
                    lbl_warning.Text = "Please meet your faculty..They will guide you";
                    lbl_warning.ForeColor = System.Drawing.Color.Red;
                }
                //if (!string.IsNullOrEmpty(password))


            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong.."+ex.Message;
                lbl_warning.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}