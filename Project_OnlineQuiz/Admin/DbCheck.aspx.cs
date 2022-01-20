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
    public partial class DbCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            erer();
        }
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        public void erer()
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select myImg from question where Id = 15", con);
                try
                {
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            byte[] imgdata = (byte[])dr["myImg"];
                            string img = Convert.ToBase64String(imgdata, 0, imgdata.Length);
                            Image1.ImageUrl = "data:image/png:base64," + img;
                            //Text1.Text = "";

                        }
                    }
                }
                catch (Exception e) { }


            }

        }


    }
}