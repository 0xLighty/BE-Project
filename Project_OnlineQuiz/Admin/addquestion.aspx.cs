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
using System.Collections;

namespace Project_OnlineQuiz.Admin
{
    public partial class addquestion : System.Web.UI.Page
    {
        public static int qid;
        public static int que=1;
        DBHelperr obj = new DBHelperr();
        //static String server = "063LATITUDE5420/SQLEXPRESS";
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        //static String uid = "Jay";
        static String uid = "Jay";
        //static String password = "BJay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        public string query, constr;
        public MySqlConnection con;
        public void connection()
        {
            con = new MySqlConnection(connectionString);
            con.Open();

        }
        private void checkImageupload() {
            if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == false) {
                //string myFileName = ((System.Web.UI.WebControls.FileUpload)objFile).FileName;
                //private void uploadDoc(HttpPostedFile httpPostedFile, int filesize, string saveLocation, System.Web.UI.WebControls.FileUpload FileUpload1)
                Imageupload1(FileUpload2.PostedFile, 1);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload1(FileUpload3.PostedFile,  2);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload1(FileUpload4.PostedFile,  3);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload1(FileUpload5.PostedFile,  4);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload1(FileUpload1.PostedFile, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload1.PostedFile,FileUpload2.PostedFile, 1, 2);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload1.PostedFile, FileUpload3.PostedFile, 1, 3);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload1.PostedFile, FileUpload4.PostedFile, 1, 4);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload2(FileUpload1.PostedFile, FileUpload5.PostedFile, 1, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload2.PostedFile, FileUpload3.PostedFile, 2, 3);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload2.PostedFile, FileUpload4.PostedFile, 2, 4);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload2(FileUpload2.PostedFile, FileUpload5.PostedFile, 2, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload2(FileUpload3.PostedFile, FileUpload4.PostedFile, 3, 4);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload2(FileUpload3.PostedFile, FileUpload5.PostedFile, 3, 5);
            }//
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == false)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload3.PostedFile, 1,2, 3);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload4.PostedFile, 1, 2, 4);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload5.PostedFile, 1, 2, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, 1, 3, 4);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload3.PostedFile, FileUpload5.PostedFile, 1, 3, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload3(FileUpload1.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 1, 4, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload3(FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, 2, 3, 4);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {//Vatsal
                Imageupload3(FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload5.PostedFile, 2, 3, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload3(FileUpload2.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 2, 4, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload3(FileUpload3.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 3, 4, 5);
            }//
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == false)
            {
                Imageupload4(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, 1, 2, 3, 4);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == false && FileUpload5.HasFile == true)
            {
                Imageupload4(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload5.PostedFile, 1, 2, 3, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == false && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload4(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 1, 2, 4, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == false && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload4(FileUpload1.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 1, 3, 4, 5);
            }
            else if (FileUpload1.HasFile == false && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload4(FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile, 2, 3, 4, 5);
            }
            else if (FileUpload1.HasFile == true && FileUpload2.HasFile == true && FileUpload3.HasFile == true && FileUpload4.HasFile == true && FileUpload5.HasFile == true)
            {
                Imageupload5(FileUpload1.PostedFile, FileUpload2.PostedFile, FileUpload3.PostedFile, FileUpload4.PostedFile, FileUpload5.PostedFile);
            }
            else { }
            //if (que == 1) ;
                //Imageupload();
        }

        //, System.Web.UI.WebControls.FileUpload FileUpload1
        private void Imageupload1(HttpPostedFile httpPostedFile, int a)
        {          
                int imagefilelenth = httpPostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelenth];
                HttpPostedFile image = httpPostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelenth);
                connection();
                string eid = Request.QueryString["eid"];
                if(a==1)
                    query = "update question set popt_one=@Image where exam_id='"+eid+"' and question_id = "+qid+"";
                else if(a==2)
                    query = "update question set popt_two=@Image where exam_id='" + eid + "' and question_id = " + qid + "";
                else if(a==3)
                    query = "update question set popt_three=@Image where exam_id='" + eid + "' and question_id = " + qid + "";
                else if (a == 4)
                    query = "update question set popt_four=@Image where exam_id='" + eid + "' and question_id = " + qid + "";
                else if (a == 5)
                    query = "update question set myImg=@Image where exam_id='" + eid + "' and question_id = " + qid + "";
                else { }
                MySqlCommand com = new MySqlCommand(query, con);
            //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;
            com.Parameters.Add(new MySqlParameter("@Image", imgarray));
            //com.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgarray;
                com.ExecuteNonQuery();
                lbl_addquestionwarning.Visible = true;
                lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

                //imagebindGrid();
        }

        private void Imageupload2(HttpPostedFile httpPostedFile1,HttpPostedFile httpPostedFile2, int a, int b)
        {


            int imagefilelenth1 = httpPostedFile1.ContentLength;
            byte[] imgarray1 = new byte[imagefilelenth1];
            HttpPostedFile image1 = httpPostedFile1;
            image1.InputStream.Read(imgarray1, 0, imagefilelenth1);
            int imagefilelenth2 = httpPostedFile2.ContentLength;
            byte[] imgarray2 = new byte[imagefilelenth2];
            HttpPostedFile image2 = httpPostedFile2;
            image2.InputStream.Read(imgarray2, 0, imagefilelenth2);
            connection();
            string eid = Request.QueryString["eid"];
            if (a == 1 && b == 2)
                query = "update question set myImg=@Image1, popt_one=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 3)
                query = "update question set myImg=@Image1, popt_two=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 4)
                query = "update question set myImg=@Image1, popt_three=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 5)
                query = "update question set myImg=@Image1, popt_four=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 3)
                query = "update question set popt_one=@Image1, popt_two=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 4)
                query = "update question set popt_one=@Image1, popt_three=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 5)
                query = "update question set popt_one=@Image1, popt_four=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 3 && b == 4)
                query = "update question set popt_two=@Image1, popt_three=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 3 && b == 5)
                query = "update question set popt_two=@Image1, popt_four=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 4 && b == 5)
                query = "update question set popt_three=@Image1, popt_four=@Image2 where exam_id='" + eid + "' and question_id = " + qid + "";
            else { }
            MySqlCommand com = new MySqlCommand(query, con);
            //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;
            BitArray im1 = new BitArray(imgarray1);
            BitArray im2 = new BitArray(imgarray2);

            com.Parameters.Add(new MySqlParameter("@Image1", imgarray1));
            com.Parameters.Add(new MySqlParameter("@Image2", imgarray2));
            //com.Parameters.AddWithValue("@Image1", MySqlDbType.LongBlob).Value = imgarray1;
            //com.Parameters.AddWithValue("@Image2", MySqlDbType.LongBlob).Value = imgarray2;
            com.ExecuteNonQuery();
            lbl_addquestionwarning.Visible = true;
            lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

            //imagebindGrid();



        }
        private void Imageupload3(HttpPostedFile httpPostedFile1, HttpPostedFile httpPostedFile2, HttpPostedFile httpPostedFile3, int a, int b, int c)
        {


            int imagefilelenth1 = httpPostedFile1.ContentLength;
            byte[] imgarray1 = new byte[imagefilelenth1];
            HttpPostedFile image1 = httpPostedFile1;
            image1.InputStream.Read(imgarray1, 0, imagefilelenth1);
            int imagefilelenth2 = httpPostedFile2.ContentLength;
            byte[] imgarray2 = new byte[imagefilelenth2];
            HttpPostedFile image2 = httpPostedFile2;
            image2.InputStream.Read(imgarray2, 0, imagefilelenth2);
            int imagefilelenth3 = httpPostedFile3.ContentLength;
            byte[] imgarray3 = new byte[imagefilelenth3];
            HttpPostedFile image3 = httpPostedFile3;
            image3.InputStream.Read(imgarray3, 0, imagefilelenth3);
            connection();
            string eid = Request.QueryString["eid"];
            if (a == 1 && b == 2 && c==3)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_two=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 2 && c == 4)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_three=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 2 && c == 5)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 3 && c == 4)
                query = "update question set myImg=@Image1, popt_two=@Image2,popt_three=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 3 && c == 5)
                query = "update question set myImg=@Image1, popt_two=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 4 && c == 5)
                query = "update question set myImg=@Image1, popt_three=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 3 && c == 4)
                query = "update question set popt_one=@Image1, popt_two=@Image2,popt_three=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 3 && c == 5)
                query = "update question set popt_one=@Image1, popt_two=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 4 && c == 5)
                query = "update question set popt_one=@Image1, popt_three=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 3 && b == 4 && c == 5)
                query = "update question set popt_two=@Image1, popt_three=@Image2,popt_four=@Image3 where exam_id='" + eid + "' and question_id = " + qid + "";
            else { }
            MySqlCommand com = new MySqlCommand(query, con);
            //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;
            com.Parameters.Add(new MySqlParameter("@Image1", imgarray1));
            com.Parameters.Add(new MySqlParameter("@Image2", imgarray2));
            com.Parameters.Add(new MySqlParameter("@Image3", imgarray3));
            //com.Parameters.AddWithValue("@Image1", SqlDbType.Image).Value = imgarray1;
            //com.Parameters.AddWithValue("@Image2", SqlDbType.Image).Value = imgarray2;
            //com.Parameters.AddWithValue("@Image3", SqlDbType.Image).Value = imgarray3;
            com.ExecuteNonQuery();
            lbl_addquestionwarning.Visible = true;
            lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

            //imagebindGrid();



        }

        private void Imageupload4(HttpPostedFile httpPostedFile1, HttpPostedFile httpPostedFile2, HttpPostedFile httpPostedFile3,HttpPostedFile httpPostedFile4, int a, int b, int c,int d)
        {


            int imagefilelenth1 = httpPostedFile1.ContentLength;
            byte[] imgarray1 = new byte[imagefilelenth1];
            HttpPostedFile image1 = httpPostedFile1;
            image1.InputStream.Read(imgarray1, 0, imagefilelenth1);
            int imagefilelenth2 = httpPostedFile2.ContentLength;
            byte[] imgarray2 = new byte[imagefilelenth2];
            HttpPostedFile image2 = httpPostedFile2;
            image2.InputStream.Read(imgarray2, 0, imagefilelenth2);
            int imagefilelenth3 = httpPostedFile3.ContentLength;
            byte[] imgarray3 = new byte[imagefilelenth3];
            HttpPostedFile image3 = httpPostedFile3;
            image3.InputStream.Read(imgarray3, 0, imagefilelenth3);
            int imagefilelenth4 = httpPostedFile4.ContentLength;
            byte[] imgarray4 = new byte[imagefilelenth4];
            HttpPostedFile image4 = httpPostedFile4;
            image4.InputStream.Read(imgarray4, 0, imagefilelenth4);
            connection();
            string eid = Request.QueryString["eid"];
            if (a == 1 && b == 2 && c == 3 && d==4)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_two=@Image3,popt_three=@Image4 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 2 && c == 3 && d == 5)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_two=@Image3,popt_four=@Image4 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 2 && c == 4 && d == 5)
                query = "update question set myImg=@Image1, popt_one=@Image2,popt_three=@Image3,popt_four=@Image4 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 1 && b == 3 && c == 4 && d == 5)
                query = "update question set myImg=@Image1, popt_two=@Image2,popt_three=@Image3,popt_four=@Image4 where exam_id='" + eid + "' and question_id = " + qid + "";
            else if (a == 2 && b == 3 && c == 4 && d == 5)
                query = "update question set popt_one=@Image1, popt_two=@Image2,popt_three=@Image3,popt_four=@Image4 where exam_id='" + eid + "' and question_id = " + qid + "";
            else { }
            MySqlCommand com = new MySqlCommand(query, con);
            //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;

            com.Parameters.Add(new MySqlParameter("@Image1", imgarray1));
            com.Parameters.Add(new MySqlParameter("@Image2", imgarray2));
            com.Parameters.Add(new MySqlParameter("@Image3", imgarray3));
            com.Parameters.Add(new MySqlParameter("@Image4", imgarray4));

            //com.Parameters.AddWithValue("@Image1", SqlDbType.Image).Value = imgarray1;
            //com.Parameters.AddWithValue("@Image2", SqlDbType.Image).Value = imgarray2;
            //com.Parameters.AddWithValue("@Image3", SqlDbType.Image).Value = imgarray3;
            //com.Parameters.AddWithValue("@Image4", SqlDbType.Image).Value = imgarray4;
            com.ExecuteNonQuery();
            lbl_addquestionwarning.Visible = true;
            lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

            //imagebindGrid();



        }

        private void Imageupload5(HttpPostedFile httpPostedFile1, HttpPostedFile httpPostedFile2, HttpPostedFile httpPostedFile3, HttpPostedFile httpPostedFile4, HttpPostedFile httpPostedFile5)
        {


            int imagefilelenth1 = httpPostedFile1.ContentLength;
            byte[] imgarray1 = new byte[imagefilelenth1];
            HttpPostedFile image1 = httpPostedFile1;
            image1.InputStream.Read(imgarray1, 0, imagefilelenth1);
            int imagefilelenth2 = httpPostedFile2.ContentLength;
            byte[] imgarray2 = new byte[imagefilelenth2];
            HttpPostedFile image2 = httpPostedFile2;
            image2.InputStream.Read(imgarray2, 0, imagefilelenth2);
            int imagefilelenth3 = httpPostedFile3.ContentLength;
            byte[] imgarray3 = new byte[imagefilelenth3];
            HttpPostedFile image3 = httpPostedFile3;
            image3.InputStream.Read(imgarray3, 0, imagefilelenth3);
            int imagefilelenth4 = httpPostedFile4.ContentLength;
            byte[] imgarray4 = new byte[imagefilelenth4];
            HttpPostedFile image4 = httpPostedFile4;
            image4.InputStream.Read(imgarray4, 0, imagefilelenth4);
            int imagefilelenth5 = httpPostedFile5.ContentLength;
            byte[] imgarray5 = new byte[imagefilelenth5];
            HttpPostedFile image5 = httpPostedFile5;
            image5.InputStream.Read(imgarray5, 0, imagefilelenth5);
            connection();
            string eid = Request.QueryString["eid"];

            query = "update question set myImg=@Image1, popt_one=@Image2,popt_two=@Image3,popt_three=@Image4,popt_four=@Image5 where exam_id='" + eid + "' and question_id = " + qid + "";
            
            MySqlCommand com = new MySqlCommand(query, con);
            //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;

            com.Parameters.Add(new MySqlParameter("@Image1", imgarray1));
            com.Parameters.Add(new MySqlParameter("@Image2", imgarray2));
            com.Parameters.Add(new MySqlParameter("@Image3", imgarray3));
            com.Parameters.Add(new MySqlParameter("@Image4", imgarray4));
            com.Parameters.Add(new MySqlParameter("@Image5", imgarray5));

            //com.Parameters.AddWithValue("@Image1", SqlDbType.Image).Value = imgarray1;
            //com.Parameters.AddWithValue("@Image2", SqlDbType.Image).Value = imgarray2;
            //com.Parameters.AddWithValue("@Image3", SqlDbType.Image).Value = imgarray3;
            //com.Parameters.AddWithValue("@Image4", SqlDbType.Image).Value = imgarray4;
            //com.Parameters.AddWithValue("@Image5", SqlDbType.Image).Value = imgarray5;
            com.ExecuteNonQuery();
            lbl_addquestionwarning.Visible = true;
            lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

            //imagebindGrid();



        }

        private void Imageupldoad(HttpPostedFile httpPostedFile, System.Web.UI.WebControls.FileUpload FileUpload1)
        {

            if (FileUpload1.HasFile)
            {
                int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelenth];
                HttpPostedFile image = FileUpload1.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelenth);
                connection();
                string eid = Request.QueryString["eid"];
                query = "update question set myImg=@Image where exam_id='" + eid + "' and question_id = " + qid + "";
                MySqlCommand com = new MySqlCommand(query, con);
                //com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = TextBox1.Text;
                com.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgarray;
                com.ExecuteNonQuery();
                lbl_addquestionwarning.Visible = true;
                lbl_addquestionwarning.Text = "Image Is Uploaded successfully";

                //imagebindGrid();

            }

        }

        protected void btn_LinkButton1_Click(object sender, CommandEventArgs e) {
            var fUp=FileUpload2;
            var tBox=txt_optionfour;
            var myVal = require_op1;
            var myVal1 = RegularExpressionValidator2;
            var myVal2 = RequiredFieldValidator2;
            if (e.CommandName == "1") {
                fUp = FileUpload2;
                tBox = txt_optionone;
                myVal = require_op1;
                myVal1 = RegularExpressionValidator2;
                myVal2 = RequiredFieldValidator2;
            }
            else if (e.CommandName == "2")
            {
                fUp = FileUpload3;
                tBox = txt_optiontwo;
                myVal = require_op2;
                myVal1 = RegularExpressionValidator3;
                myVal2 = RequiredFieldValidator3;
            }
            else if (e.CommandName == "3")
            {
                fUp = FileUpload4;
                tBox = txt_optionthree;
                myVal = require_op3;
                myVal1 = RegularExpressionValidator4;
                myVal2 = RequiredFieldValidator4;
            }
            else if (e.CommandName == "4")
            {
                fUp = FileUpload5;
                tBox = txt_optionfour;
                myVal = require_op4;
                myVal1 = RegularExpressionValidator5;
                myVal2 = RequiredFieldValidator5;
            }
            else { }
            if (fUp.Enabled == false)
            {
                fUp.Enabled = true;
                tBox.Enabled = false;
                tBox.Text = null;
                myVal.Enabled = false;
                myVal1.Enabled = true;
                myVal2.Enabled = true;
            }
            else if (fUp.Enabled == true)
            {
                fUp.Enabled = false;
                tBox.Enabled = true;
                tBox.Text = null;
                myVal.Enabled = true;
                myVal1.Enabled = false;
                myVal2.Enabled = false;
            }
            else { }



        }

        protected void btn_Link1_Click(object sender, EventArgs e)
        {
            
            if (FileUpload2.Enabled == false)
            {
                FileUpload2.Enabled = true;
                txt_optionone.Enabled = false;
                txt_optionone.Text = null;
                require_op1.Enabled = false;
                RegularExpressionValidator2.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
            }
            else
            {
                FileUpload2.Enabled = false;
                txt_optionone.Enabled = true;
                txt_optionone.Text = null;
                require_op1.Enabled = true;
                RegularExpressionValidator2.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
            }
            //panel_addquestion_warning.Visible = true;
            //lbl_addquestionwarning.Text = "In button clicked </br>";
        }
        protected void btn_Link2_Click(object sender, EventArgs e)
        {

            if (FileUpload3.Enabled == false)
            {
                FileUpload3.Enabled = true;
                txt_optiontwo.Enabled = false;
                txt_optiontwo.Text = null;
                require_op2.Enabled = false;
                RegularExpressionValidator3.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
            }
            else
            {
                FileUpload3.Enabled = false;
                txt_optiontwo.Enabled = true;
                txt_optiontwo.Text = null;
                require_op2.Enabled = true;
                RegularExpressionValidator3.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
            }
            //panel_addquestion_warning.Visible = true;
            //lbl_addquestionwarning.Text = "In button clicked </br>";
        }

        protected void btn_Link3_Click(object sender, EventArgs e)
        {

            if (FileUpload4.Enabled == false)
            {
                FileUpload4.Enabled = true;
                txt_optionthree.Enabled = false;
                txt_optionthree.Text = null;
                require_op3.Enabled = false;
                RegularExpressionValidator4.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
            }
            else
            {
                FileUpload4.Enabled = false;
                txt_optionthree.Enabled = true;
                txt_optionthree.Text = null;
                require_op3.Enabled = true;
                RegularExpressionValidator4.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
            }
            //panel_addquestion_warning.Visible = true;
            //lbl_addquestionwarning.Text = "In button clicked </br>";
        }
        protected void btn_Link4_Click(object sender, EventArgs e)
        {

            if (FileUpload5.Enabled == false)
            {
                FileUpload5.Enabled = true;
                txt_optionfour.Enabled = false;
                txt_optionfour.Text = null;
                require_op4.Enabled = false;
                RegularExpressionValidator5.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
            }
            else
            {
                FileUpload5.Enabled = false;
                txt_optionfour.Enabled = true;
                txt_optionfour.Text = null;
                require_op4.Enabled = true;
                RegularExpressionValidator5.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
            }
            //panel_addquestion_warning.Visible = true;
            //lbl_addquestionwarning.Text = "In button clicked </br>";
        }
        protected void btn_LinkButton2_Click(object sender, CommandEventArgs e) { }
        protected void btn_LinkButton3_Click(object sender, CommandEventArgs e) { }
        protected void btn_LinkButton4_Click(object sender, CommandEventArgs e) { }
        protected void btn_LinkButton5_Click(object sender, CommandEventArgs e) { }

        protected void btn_addquestion_Click(object sender, EventArgs e)
        {
            string eid = Request.QueryString["eid"];
            
            
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {

                        String qO1 = txt_optionone.Text.Length == 0 ? null : txt_optionone.Text;
                        String qO2 = txt_optiontwo.Text.Length == 0 ? null : txt_optiontwo.Text;
                        String qO3 = txt_optionthree.Text.Length == 0 ? null : txt_optionthree.Text;
                        String qO4 = txt_optionfour.Text.Length == 0 ? null : txt_optionfour.Text;

                        String cat = getCat();
                        MySqlCommand cmd = new MySqlCommand("insert into question(question_id,exam_id,category_name,question_name,opt_one,opt_two,opt_three,opt_four,question_answer,marks) values(" + qid + ",'" + eid + "','" + cat + "','" + txt_questionname.Text + "','" + qO1 + "','" + qO2 + "','" + qO3 + "','" + qO4 + "','" + rdo_correctanswer.SelectedValue + "','"+TextBox1.Text+"')", con);


                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                           
                            
                            checkImageupload();
                            DataTable dt_m = obj.sel("select sum(marks) as marks from question where exam_id='" + eid + "'");
                            int m = Convert.ToInt32(dt_m.Rows[0]["marks"]);
                        int tq = Convert.ToInt16(qid);
                            obj.ins_up_del("update exam set exam_totalquestions=" + tq + ",exam_marks="+m+" where exam_id='"+eid+"'");
                            Response.Redirect("~/admin/exam.aspx");
                        }
                        else
                        {
                            txt_questionname.Focus();
                            panel_addquestion_warning.Visible = true;
                            lbl_addquestionwarning.Text = "Try again.";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_questionname.Focus();
                        panel_addquestion_warning.Visible = true;
                        lbl_addquestionwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                }
            

         
     
        }
        protected void checkText(object sender, EventArgs e) {

            if (txt_optionone.Enabled == true) {
                panel_addquestion_warning.Visible = true;
                lbl_addquestionwarning.Text = "TextBox1Enabled";
            }
            else if (txt_optiontwo.Enabled == true)
            {
                panel_addquestion_warning.Visible = true;
                lbl_addquestionwarning.Text = "TextBox2Enabled";
            }
            else { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
            string eid = Request.QueryString["eid"];
            DataTable dtt = new DataTable();
            dtt = obj.sel("select question_id from question where exam_id=" + eid + "");
            int maxLavel;
            
            

            if (Session["rc"].ToString() != "done")
            {
                panel_addquestion_warning.Visible = true;
                lbl_addquestionwarning.Text = "In Session </br>";
                

                if (!IsPostBack)
                {
                    try
                    {
                        maxLavel = Convert.ToInt32(dtt.Compute("max([question_id])", string.Empty));
                    }
                    catch (Exception ex)
                    {
                        maxLavel = 0;
                    }
                    qid = maxLavel + 1;
                    txt_questionId.Text = qid.ToString();
                    if (txt_optionone.Text != null)
                    {
                        require_op1.Enabled = true;
                        txt_optionone.Enabled = true;
                        FileUpload2.Enabled = false;
                        RegularExpressionValidator2.Enabled = false;
                        RequiredFieldValidator2.Enabled = false;
                    }
                    if (txt_optiontwo.Text != null)
                    {
                        require_op2.Enabled = true;
                        txt_optiontwo.Enabled = true;
                        FileUpload3.Enabled = false;
                        RegularExpressionValidator3.Enabled = false;
                        RequiredFieldValidator3.Enabled = false;
                    }
                    if (txt_optionthree.Text != null)
                    {
                        require_op3.Enabled = true;
                        txt_optionthree.Enabled = true;
                        FileUpload4.Enabled = false;
                        RegularExpressionValidator4.Enabled = false;
                        RequiredFieldValidator4.Enabled = false;
                    }
                    if (txt_optionfour.Text != null)
                    {
                        require_op4.Enabled = true;
                        txt_optionfour.Enabled = true;
                        FileUpload5.Enabled = false;
                        RegularExpressionValidator5.Enabled = false;
                        RequiredFieldValidator5.Enabled = false;
                    }

                    panel_addquestion_warning.Visible = true;
                    lbl_addquestionwarning.Text = "In postBack </br>";
                    txt_optionone.Enabled = true;
                    txt_optiontwo.Enabled = true;
                    txt_optionthree.Enabled = true;
                    txt_optionfour.Enabled = true;
                    require_op1.Enabled = true;
                    require_op2.Enabled = true;
                    require_op3.Enabled = true;
                    require_op4.Enabled = true;
                    FileUpload2.Enabled = false;
                    RegularExpressionValidator2.Enabled = false;
                    RequiredFieldValidator2.Enabled = false;
                    FileUpload3.Enabled = false;
                    RegularExpressionValidator3.Enabled = false;
                    RequiredFieldValidator3.Enabled = false;
                    FileUpload4.Enabled = false;
                    RegularExpressionValidator4.Enabled = false;
                    RequiredFieldValidator4.Enabled = false;
                    FileUpload5.Enabled = false;
                    RegularExpressionValidator5.Enabled = false;
                    RequiredFieldValidator5.Enabled = false;
                    if (eid == null)
                    {
                        Response.Redirect("~/admin/exam.aspx");
                    }
                }

            }
        }

        protected void btn_qImg_Click(object sender, EventArgs e) {
            panel_addquestion_warning.Visible = true;
            lbl_addquestionwarning.Text = "In button clicked </br>";
            if (FileUpload1.Enabled == true)
            {
                FileUpload1.Enabled = false;
                Button12.Text = "Yes";
                RegularExpressionValidator1.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
            }
            else {
                FileUpload1.Enabled = true;
                Button12.Text = "No";
                RegularExpressionValidator1.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
            }
            panel_addquestion_warning.Visible = true;
            lbl_addquestionwarning.Text = "In button clicked </br>";
        }

        protected String getCat() {
            DataTable dtt1 = new DataTable();
            string eid = Request.QueryString["eid"];
            dtt1 = obj.sel("select category_name from question where exam_id='" + eid + "'");
            String cat = dtt1.Rows[0][1].ToString();
            return cat;
        }

        protected void timepass(object sender, EventArgs e)
        {
            string eid = Request.QueryString["eid"];
            if (IsValid)
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                    String cat = getCat();
                    MySqlCommand cmd = new MySqlCommand("insert into question(question_id,exam_id,category_name,question_name,opt_one,opt_two,opt_three,opt_four,question_answer) values(" + qid + ",'" + eid + "','"+cat+"','" + txt_questionname.Text + "','" + txt_optionone.Text + "','" + txt_optiontwo.Text + "','" + txt_optionthree.Text + "','" + txt_optionfour.Text + "','" + rdo_correctanswer.SelectedValue + "')", con);
                    
                    
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            checkImageupload();
                            Response.Redirect("~/admin/exam.aspx");
                        }
                        else
                        {
                            txt_questionname.Focus();
                            panel_addquestion_warning.Visible = true;
                            lbl_addquestionwarning.Text = "Try again.";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_questionname.Focus();
                        panel_addquestion_warning.Visible = true;
                        lbl_addquestionwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } 
            }
            else
            {
                txt_questionname.Focus();
                panel_addquestion_warning.Visible = true;
                lbl_addquestionwarning.Text = "You must fill all the requirements";
            }
        }
    }
}