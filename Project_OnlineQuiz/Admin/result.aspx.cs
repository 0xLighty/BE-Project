using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using System.Web.Services;
using iTextSharp.text.html.simpleparser;
using MySql.Data.MySqlClient;

namespace Project_OnlineQuiz.Admin
{
    public partial class result : System.Web.UI.Page
    {
        DBHelperr obj = new DBHelperr();
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["facemail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }
            btn_Report.Visible = false;
            if (Request.QueryString["uid"] == null)
            {
                drp_year.Visible = true;
                RequiredFieldValidator1.Enabled = true;
                panel1.Visible = true;
                

            }
            else {
                drp_year.Visible = false;
                panel1.Visible = false;
                RequiredFieldValidator1.Enabled = false;
            }
            //get_categoryyedrp();
            //string uemail = Request.QueryString["uid"];
            if (!IsPostBack)
            {
                btn_Report.Visible = false;
                get_categoryyedrp();
                get_yeardrp();
                //if (uemail != null)
                //{
                //    getspecificresults(uemail);
                //    gridviewspecific.Visible = true;
                //    gridresult.Visible = false;
                //}
                //else
                //{
                    //getallresults();
                    //gridviewspecific.Visible = false;
                    //gridresult.Visible = true;
                //}

            }
        }

        protected void btn_q_Click(object sender, EventArgs e) {
            if (IsValid)
            {
                btn_Report.Visible = false;

                if (Request.QueryString["uid"] == null)
                    getallresults();
                else
                {
                    string uemail = Request.QueryString["uid"];
                    getspecificresults(uemail);
                }
            }
            
        }


        public void getallresults()
        {
            //string uid = ClientQueryString[0].ToString();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd;
                //if (uid == null)
                //{
                cmd = new MySqlCommand("select * from result left join exam on result.exam_fid = exam.exam_id where result.exam_fid='" + drp_EId.Text + "' and result.pOyear=" + drp_year.Text + " ORDER BY user_enroll ASC ", con);
                //}
                //else
                //{
                   // DataTable dtt = new DataTable();
                    //dtt = obj.sel("select enroll from users where email=" + uid + "");
                    //var enroll = Convert.ToDecimal(dtt.Rows[0][0].ToString());
                    //cmd = new MySqlCommand("select * from result left join exam on result.exam_id = exam.exam_id where result.exam_id='" + drp_EId.SelectedIndex.ToString() + "' AND result.user_enroll='"+ enroll +"' ORDER BY user_enroll ASC ", con);
                //}
                try
                {
                    con.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridresult.DataSource = null;
                                gridresult.DataBind();
                                GridView1.DataSource = null;
                                GridView1.DataBind();
                                gridresult.DataSource = tb;
                                gridresult.DataBind();
                                GridView1.DataSource = tb;
                                GridView1.DataBind();
                                if (gridresult.Rows.Count == 0)
                                {
                                    btn_Report.Visible = false;
                                }
                                else {
                                    btn_Report.Visible = true;
                                }

                                
                            }
                            else
                            {
                                panel_resultshow_warning.Visible = true;
                                lbl_resultshowwarning.Text = "There is no result right now in this application";
                                btn_Report.Visible = false;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    btn_Report.Visible = false;
                    panel_resultshow_warning.Visible = true;
                    lbl_resultshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;

                }
                finally { con.Close(); }
            }
        }

        public void get_categoryyedrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd;
                if (Request.QueryString["uid"] == null)
                {
                    cmd = new MySqlCommand("select distinct exam_fid from result", con);
                }
                else {
                    string uemail = Request.QueryString["uid"];
                    cmd = new MySqlCommand("select distinct exam_fid from result where user_enroll='" + uemail + "'", con);
                }
                try
                {
                    con.Open();
                    drp_EId.DataSource = cmd.ExecuteReader();
                    drp_EId.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select exam_id", "-1");
                    drp_EId.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    drp_EId.Focus();
                    panel_resultshow_warning.Visible = true;
                    lbl_resultshowwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
                finally { con.Close(); }
            }
        }

        public void get_yeardrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct pOyear from result where pOyear is not null ORDER BY pOyear ASC", con);
                try
                {
                    con.Open();
                    drp_year.DataSource = cmd.ExecuteReader();
                    drp_year.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select year", "-1");
                    drp_year.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    drp_year.Focus();
                    panel_resultshow_warning.Visible = true;
                    lbl_resultshowwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
                finally { con.Close(); }
            }
        }

        



        public void getspecificresults(string enroll)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from result,exam where user_enroll='" + enroll + "' AND exam_fid='" + drp_EId.Text + "' AND exam_id='" + drp_EId.Text + "';", con);

                try
                {
                    con.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridviewspecific.DataSource = null;
                                gridviewspecific.DataBind();
                                gridviewspecific.DataSource = tb;
                                gridviewspecific.DataBind();
                                gridviewspecific.Visible = true;
                            }
                            else
                            {
                                gridviewspecific.DataSource = null;
                                gridviewspecific.DataBind();
                                panel_resultshow_warning.Visible = true;
                                lbl_resultshowwarning.Text = "There is no result right now in this application";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_resultshow_warning.Visible = true;
                    gridviewspecific.DataSource = null;
                    gridviewspecific.DataBind();
                    lbl_resultshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
                finally { con.Close(); }
            }
        }

        protected void gridresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridresult.PageIndex = e.NewPageIndex;
            getallresults();
            //gridviewspecific.Visible = false;
            gridresult.Visible = true;
        }

        /*private void BindGridViewData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblEmployee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }*/
        public String ExID, ExDate, TotMarks;
        public int totalPStud = 0;
        public int totalFStud = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.HeaderRow.Cells.Count != null)
            {
                int columnsCount = GridView1.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount - 2);

                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in GridView1.HeaderRow.Cells)
                {

                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                    //font.Color = new BaseColor(255,0,0);

                    // Create the PDF cell, specifying the text and font


                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                    //pdfCell.BackgroundColor = new BaseColor(0,0,0);

                    // Add the cell to PDF table
                    if (gridViewHeaderCell.Text != "Exam_Id"  && gridViewHeaderCell.Text != "Total Marks")
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                        pdfTable.AddCell(pdfCell);

                    }

                }

                // Loop thru each datarow in GrdiView
                //2,3,5
                int i = 1;

                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {


                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            Font font = new Font();
                            if (i == 2)
                            {
                                ExID = gridViewCell.Text.ToString();
                            }
                            
                            if (i == 4)
                            {
                                TotMarks = gridViewCell.Text.ToString();
                            }
                            //font.Color = new BaseColor(255, 0, 0);
                            if (i != 2 && i != 4)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, FontFactory.GetFont("Verdana", 8)));
                                if (gridViewCell.Text.ToString() == "pass")
                                {
                                    totalPStud++;
                                   // pdfCell.setBackgroundColor(new BaseColor(226, 226, 226));
                                    pdfCell.BackgroundColor = new Color(255, 255, 255);
                                    
                                }
                                if (gridViewCell.Text.ToString() == "fail")
                                {
                                    totalFStud++;
                                    pdfCell.BackgroundColor = new Color(243, 169, 169);
                                   // pdfTable.AddCell(pdfCell);
                                }
                                pdfTable.AddCell(pdfCell);
                                //pdfCell.BackgroundColor = new BaseColor(0, 0, 0);

                                

                            }
                            i++;
                        }
                    }
                    if (i == 6) { i = 1; }




                }
                
                
                /*
                Chunk c = new Chunk
                ("Students Report \n",
                FontFactory.GetFont("Verdana", 15));
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                p.Add(c);
                Chunk chunk1 = new Chunk
                ("VGEC Online Exam \n",
                FontFactory.GetFont("Verdana", 8));
                Paragraph p1 = new Paragraph();
                p1.Alignment = Element.ALIGN_CENTER;
                p1.Add(chunk1);*/
                float tot = totalPStud + totalFStud;
                float allover = (float)((float)totalPStud * (100) / (float)tot);

                Chunk cc = new Chunk
                (String.Format("{0} : {1}", "Exam Id", ExID + "\n") + String.Format("{0} : {1}", "Exam date", " " + "\n") + String.Format("{0} : {1}", "Total Marks", TotMarks + "\n") + String.Format("{0} : {1}", "Total No. of Students", (totalPStud + totalFStud) + "\n") + String.Format("{0} : {1}", "Passout students", totalPStud + "\n") + String.Format("{0} : {1}", "All over result", allover) + "%\n\n",
                FontFactory.GetFont("Verdana", 8));
                Paragraph pp = new Paragraph();
                pp.Alignment = Element.ALIGN_JUSTIFIED;
                pp.Add(cc);


                //PdfPTable table = new PdfPTable(3);
                //String finald = "Exam Id: " + ExID + "\n" + "Exam date: " + ExDate + "\n" + "Total Marks: " + TotMarks;
                //table.AddCell(getCell(finald, PdfPCell.ALIGN_LEFT));

                //document.add(table);



                // Create the PDF document specifying page size and margins
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);


                // Roate page using Rotate() function, if you want in Landscape
                // pdfDocument.SetPageSize(PageSize.A4.Rotate());

                // Using PageSize.A4_LANDSCAPE may not work as expected
                // Document pdfDocument = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 10f);

                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                //E:\DOT NET\Project\Project_OnlineQuiz\Project_OnlineQuiz\Admin\Files
                string Pathd = Environment.GetFolderPath
                (Environment.SpecialFolder.Desktop)
                + "\\vgec.png";
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(Pathd);
                PNG.Alignment = Element.ALIGN_CENTER;

                pdfDocument.Add(PNG);
                

                pdfDocument.Add(pp);
                //pdfDocument.Add(table);
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition",
                    "attachment;filename="+drp_EId.Text+"_"+drp_year.Text+".pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
        }
        public PdfPCell getCell(String text, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text));
            cell.BorderWidth = 0;
            cell.Border = 0;
            return cell;
        }

        

        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();

        }
        protected void gridviewspecific_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string uemail = Request.QueryString["uid"];
            gridviewspecific.PageIndex = e.NewPageIndex;
            getspecificresults(uemail);
            gridviewspecific.Visible = true;
            gridresult.Visible = false;
        }



    }
}