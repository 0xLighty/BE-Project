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
    public partial class FileUploadtemp : System.Web.UI.Page
    {
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void upload_Click(object sender, EventArgs e) {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                
                try
                {
                    con.Open();
                    //MySqlDataReader dr = cmd.ExecuteReader();
                    if (FileUpload1.HasFile)
                    {
                        Label1.Text = "in if";
                        /*while (dr.Read())
                        {
                            byte[] imgdata = (byte[])dr["myImg"];
                            string img = Convert.ToBase64String(imgdata, 0, imgdata.Length);
                            Image1.ImageUrl = "data:image/png:base64," + img;
                            //Text1.Text = "";

                        }*/
                    }
                    else {

                        int length = FileUpload1.PostedFile.ContentLength;
                        byte[] pic = new byte[length];
                        FileUpload1.PostedFile.InputStream.Read(pic, 0, length);
                        MySqlCommand cmd = new MySqlCommand("insert into question (myImg) values (@myImg)", con);
                        cmd.Parameters.AddWithValue("@myImg", pic);
                        cmd.ExecuteNonQuery();
                        Label1.Text = "Uploaded";
                    }
                }
                catch (Exception ex) {
                    Label1.Text = ""+ex;
                }


            }
        }
    }


}