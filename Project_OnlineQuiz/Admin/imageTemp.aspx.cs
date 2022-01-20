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
    public partial class imageTemp : System.Web.UI.Page
    {
        public string query, constr;
        public MySqlConnection con;
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        public void connection()
        {
            con = new MySqlConnection(connectionString);
            con.Open();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            if (!IsPostBack)
            {
                imagebindGrid();

            }
        }


        protected void upload(object sender, EventArgs e)
        {
            Imageupload();
        }


        private void Imageupload()
        {
            if (FileUpload1.HasFile)
            {
                int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelenth];
                //byte[] vats = ImageToStreamm(imagefilelenth);
                /*Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] b = br.ReadBytes((Int32)fs.Length);
                */
                HttpPostedFile image = FileUpload1.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelenth);
                connection();
                query = "Insert into  ImageToDB (ImageName,Image) values ('"+TextBox1.Text+"',@Image)";
                MySqlCommand com = new MySqlCommand(query, con);
                com.Parameters.Add(new MySqlParameter("@Image", imgarray));
                //com.Parameters.AddWithValue("@Image", MySqlDbType.).Value = imgarray;

                com.ExecuteNonQuery();
                Label1.Visible = true;
                Label1.Text = "Image Is Uploaded successfully";

                imagebindGrid();

            }

        }

        

        public void imagebindGrid()
        {
            connection();
            query = "Select id, ImageName,Image from ImageToDB";
            MySqlCommand com = new MySqlCommand(query, con);
            MySqlDataReader dr = com.ExecuteReader();
            Gridview1.DataSource = dr;
            Gridview1.DataBind();

        }


     }
}
