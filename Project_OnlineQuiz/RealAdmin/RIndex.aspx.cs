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
using Project_OnlineQuiz.Admin;
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

namespace Project_OnlineQuiz.RealAdmin
{
    public partial class RIndex : System.Web.UI.Page
    {
        DBHelperr obj = new DBHelperr();
        public static String examId;
        //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["Ademail"] as string))
            {
                Response.Redirect("~/Home.aspx");
            }

            //DBHelperr obj = new DBHelperr();
            //gettotalexam();
            //gettotalquestion();
            //gettotalstudents();


            if (!IsPostBack)
            {
                panel1.Visible = false;
                panel_subject.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel_password.Visible = false;
                panel8.Visible = false;
                panel_addStudents.Visible = false;
                panel9.Visible = false;
                panel_examReport.Visible = false;
                panel11.Visible = false;
                btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#343A40");
                btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
                btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
                btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
                btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
                btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
                btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
                get_branchdrp();
                get_branchhdrp();
                get_categoryyadrp();
                get_yeardrp();
                get_branchdrpi();
                get_categoryyadrpi();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FilePath = Server.MapPath(Convert.ToString(FileUpload1.PostedFile.FileName));
                try
                {
                    FileUpload1.SaveAs(FilePath);
                    Import_To_Grid(FilePath, Extension, "Yes");
                }
                catch (Exception ex)
                {

                    panel9.Visible = true;
                    Label7.Text = "" + ex.Message;
                }
            }
        }

        protected void Button21_Click(object sender, EventArgs e)
        {


            DataTable dti = new DataTable();
            dti.Clear();
            dti = obj.sel("select distinct exam_id from assign where examdate >= '" + T1.Text + "' and examdate <= '" + T2.Text + "' and branchAs='" + drp_brancha.Text + "' and semAs = " + drp_categoryexam.Text + "");
            if (dti.Rows.Count != 0)
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                GridView2.DataSource = dti;
                GridView2.DataBind();
                panel11.Visible = true;
                Label8.Text = "" + dti.Rows.Count;
                Button1qw_Click(dti.Rows.Count);
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                panel11.Visible = false;
            }

        }







        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);

            //MySqlConnection connExcel = new MySqlConnection();
            //connExcel.ConnectionString = conStr;

            //MySqlCommand cmdExcel = new MySqlCommand();
            //MySqlDataAdapter oda = new MySqlDataAdapter();

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            //connExcel.Open();
            //DataTable dtExcelSchema;
            //dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //string SheetName = dtExcelSchema.Rows[0]["questionMaster"].ToString();
            //connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            //cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdExcel.CommandText = "SELECT * From [Sheet1$]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            //Bind Data to GridView
            GridView1.Caption = Path.GetFileName(FilePath);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //Insert Data into Table
            insertdata(dt);

        }
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        void insertdata(DataTable dt)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(connectionString);
                //MySqlConnection cn = new MySqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
                DBHelperr obj = new DBHelperr();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                DataTable dttt = new DataTable();

                cmd.Connection = cn;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == null || dt.Rows[i][0].ToString() == String.Empty)
                    {
                        continue;
                    }
                    dttt.Clear();
                    dttt = obj.sel("select enroll from users where enroll = '" + dt.Rows[i][0] + "'");
                    if (dttt.Rows.Count != 0)
                    {
                        String my = "Some students are already there in our record.. so those students have been skipped!";
                        panel9.Visible = true;
                        Label7.Text = my;
                        continue;
                    }
                    cmd.CommandText = "insert into users (enroll, fName, lName) values ('" + dt.Rows[i][0] + "', '" + dt.Rows[i][1] + "', '" + dt.Rows[i][2] + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                panel9.Visible = true;
                Label7.Text = "" + ex.Message;

            }
        }



        public String ExID, ExDate, TotMarks, firstName, lastName;
        public int totalPStud = 0;
        public int totalFStud = 0;
        public int totalAbStud = 0;

        //uyuyuyuyuyuyu
        //uyuyuyuyuyuyu

        public PdfPCell getCell(String text, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text));
            cell.BorderWidth = 0;
            cell.Border = 0;
            return cell;
        }

        protected void Button1qw_Click(int count)
        {

            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, iTextSharp.text.Color.RED);


            Chunk cc = new Chunk
            ("\n\n",
            FontFactory.GetFont("Verdana", 8));
            Paragraph pp = new Paragraph();
            pp.Alignment = Element.ALIGN_JUSTIFIED;
            pp.Add(cc);

            Chunk branchc = new Chunk
                ("Branch: " + drp_brancha.Text + "",
                boldFont);
            Paragraph branchpp = new Paragraph();
            branchpp.Alignment = Element.ALIGN_CENTER;
            branchpp.Add(branchc);


            Chunk semd = new Chunk
                ("\nSem: " + drp_categoryexam.Text + "\n",
                boldFont);
            Paragraph semp = new Paragraph();
            branchpp.Alignment = Element.ALIGN_CENTER;
            branchpp.Add(semd);

            Paragraph ppv = new Paragraph();
            ppv.Alignment = Element.ALIGN_CENTER;
            Chunk vv1 = new Chunk
                    ("From ",
                    normalFont);
            ppv.Add(vv1);

            Chunk vv2 = new Chunk
                    (T1.Text,
                    boldFont);
            ppv.Add(vv2);

            Chunk vv3 = new Chunk
                    (" To ",
                    normalFont);
            ppv.Add(vv3);


            Chunk vv4 = new Chunk
                    (T2.Text,
                    boldFont);
            ppv.Add(vv4);

            Chunk vv5 = new Chunk
                    (" total ",
                    normalFont);
            ppv.Add(vv5);


            Chunk vv6 = new Chunk
                    ("" + count,
                    boldFont);
            ppv.Add(vv6);


            Chunk vv7 = new Chunk
                    (" exams have been taken.\n\n ",
                    normalFont);
            ppv.Add(vv7);









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
            + "\\svgec.png";
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(Pathd);
            PNG.Alignment = Element.ALIGN_CENTER;

            //PNG.SetAbsolutePosition(50, 50);

            pdfDocument.Add(PNG);
            //pdfDocument.Add(p);
            //pdfDocument.Add(p1);

            pdfDocument.Add(pp);
            pdfDocument.Add(branchpp);

            pdfDocument.Add(ppv);
            //pdfDocument.Add(ppvv);

            if (GridView2.HeaderRow.Cells.Count != null)
            {
                int columnsCount = GridView2.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(5);

                PdfPCell pdfCell33 = new PdfPCell(new Phrase("Exam Id"));
                pdfCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(pdfCell33);
                PdfPCell pdfCell44 = new PdfPCell(new Phrase("Exam Setter"));
                pdfCell44.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(pdfCell44);
                PdfPCell pdfCell17 = new PdfPCell(new Phrase("Students appeared"));
                pdfCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(pdfCell17);
                PdfPCell pdfCell11 = new PdfPCell(new Phrase("Overall Result"));
                pdfCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(pdfCell11);
                PdfPCell pdfCell22 = new PdfPCell(new Phrase("Date"));
                pdfCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(pdfCell22);




                // Loop thru each datarow in GrdiView
                //2,3,5


                foreach (GridViewRow gridViewRow in GridView2.Rows)
                {


                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            ExID = gridViewCell.Text.ToString();
                            totalPStud = 0;
                            totalAbStud = 0;
                            totalFStud = 0;
                            DataTable dv = new DataTable();
                            dv.Clear();

                            //dv = obj.sel("select status,examdate from result,assign where exam_fid='" + ExID + "' and exam_id='" + ExID + "' and user_enroll=enroll and examdate >= '" + T1.Text + "' and examdate <= '" + T2.Text + "' ");
                            //dv=obj.sel("select result.status,assign.examdate,exam.setter from exam,result,assign where exam.exam_id='" + ExID + "' AND assign.exam_id='" + ExID + "' AND result.exam_fid='" + ExID + "' AND assign.enroll=result.user_enroll AND assign.examdate >= '" + T1.Text + "' and assign.examdate <= '" + T2.Text + "' ")
                            dv = obj.sel("select result.status,assign.examdate,faculty.fName,faculty.lName from exam,result,assign,users,faculty where exam.exam_id='" + ExID + "' AND assign.exam_id='" + ExID + "' AND result.exam_fid='" + ExID + "' AND assign.enroll=result.user_enroll AND assign.enroll=users.enroll AND sem=" + drp_categoryexam.Text + " AND users.branch='" + drp_brancha.Text + "' AND exam.setter=faculty.email and examdate >= '" + T1.Text + "' and examdate <= '" + T2.Text + "'");
                            GridView3.DataSource = null;
                            GridView3.DataBind();
                            GridView3.DataSource = dv;
                            GridView3.DataBind();
                            PdfPCell pdfCell = new PdfPCell(new Phrase(ExID, FontFactory.GetFont("Verdana", 8)));
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(pdfCell);
                            DateTime payear = Convert.ToDateTime(dv.Rows[0]["examdate"].ToString());
                            String pda = payear.ToShortDateString();

                            int i = 1;
                            foreach (GridViewRow gridViewRow1 in GridView3.Rows)
                            {


                                if (gridViewRow1.RowType == DataControlRowType.DataRow)
                                {
                                    // Loop thru each cell in GrdiView data row

                                    foreach (TableCell gridViewCell1 in gridViewRow1.Cells)
                                    {

                                        if (i == 4)
                                        {
                                            firstName = gridViewCell1.Text.ToString();
                                        }
                                        if (i == 5)
                                        {
                                            lastName = gridViewCell1.Text.ToString();
                                        }



                                        //font.Color = new BaseColor(255, 0, 0);
                                        if (i != 5 && i != 4 && i != 3)
                                        {
                                            PdfPCell pdfCell1 = new PdfPCell(new Phrase(gridViewCell1.Text, FontFactory.GetFont("Verdana", 8)));
                                            if (gridViewCell1.Text.ToString() == "pass")
                                            {
                                                totalPStud++;
                                                // pdfCell.setBackgroundColor(new BaseColor(226, 226, 226));


                                            }
                                            if (gridViewCell1.Text.ToString() == "fail")
                                            {
                                                totalFStud++;

                                                // pdfTable.AddCell(pdfCell);
                                            }

                                            if (gridViewCell1.Text.ToString() == "Absent")
                                            {
                                                totalAbStud++;
                                            }
                                        }

                                        i++;

                                    }

                                }
                                if (i == 6) { i = 1; }

                            }
                            float tot = totalPStud + totalFStud + totalAbStud;
                            float tot1 = totalPStud + totalFStud;
                            float allover = (float)((float)totalPStud * (100) / (float)tot);

                            PdfPCell pdfCellrf = new PdfPCell(new Phrase(" " + firstName + " " + lastName + " ", FontFactory.GetFont("Verdana", 8)));
                            pdfCellrf.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(pdfCellrf);


                            PdfPCell pdfCellrft = new PdfPCell(new Phrase("" + tot1, FontFactory.GetFont("Verdana", 8)));
                            pdfCellrft.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(pdfCellrft);

                            PdfPCell pdfCellr = new PdfPCell(new Phrase("" + allover + "%", FontFactory.GetFont("Verdana", 8)));
                            pdfCellr.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(pdfCellr);

                            PdfPCell pdfCellq = new PdfPCell(new Phrase(pda, FontFactory.GetFont("Verdana", 8)));
                            pdfCellq.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(pdfCellq);


                            panel11.Visible = true;
                            Label8.Text = "" + allover;




                            /*Chunk chunkv = new Chunk(ExID + " :: " + allover + "% :: " + pda + " \n", FontFactory.GetFont("Verdana", 8));
                            Paragraph p1v = new Paragraph();
                            p1v.Alignment = Element.ALIGN_CENTER;
                            p1v.Add(chunkv);
                            pdfDocument.Add(p1v);*/

                        }

                    }





                }
                pdfDocument.Add(pdfTable);
            }


            //pdfDocument.Add(table);
            //pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=" + T1.Text + "_" + T2.Text + ".pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

        }

        protected void Savee(object sender, EventArgs e)
        {
            int semm = Convert.ToInt32(drp_sem.SelectedItem.Text) + 1;
            if (semm > 8) { }
            else
            {
                Saveee(semm);
            }


        }

        protected void Saveed(object sender, EventArgs e)
        {
            int semm = Convert.ToInt32(drp_sem.SelectedItem.Text) - 1;
            if (semm <= 0) { }
            else
            {
                Saveee(semm);
            }


        }

        protected void Saveee(int semm)
        {

            try
            {

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {

                    foreach (GridViewRow row in GridView_StudentsList.Rows)
                    {
                        //Label1.Text = "Inside for .  </br>";
                        if ((row.FindControl("chkSelect") as CheckBox).Checked)
                        {
                            Decimal id = Decimal.Parse(row.Cells[1].Text);
                            //con.Open();
                            obj.ins_up_del("update users set sem=" + semm + " where enroll = " + id + "");
                            //MySqlDataAdapter daa = new MySqlDataAdapter("select * from assign where exam_id = " + examId + " and enroll = " + id + "", con);
                            //MySqlCommand cmdd = new MySqlCommand("select * from assign where exam_id = " + examId + " and enroll = " + id + "");
                            //daa.Fill(dt1);
                            //con.Close();


                            panel7.Visible = true;
                            Label4.Text = "Successfully changed..";
                            Label4.ForeColor = System.Drawing.Color.ForestGreen;

                            Label1.Visible = false;
                            GridView_StudentsList.DataSource = null;
                            GridView_StudentsList.DataBind();
                            //Label1.Text = "Inside for else.  </br>"+examId;
                        }
                        else
                        {
                            //Label1.Visible = true;
                            //Label1.Text = "Inside for else.  </br>";
                        }
                    }

                }
                //Response.Redirect("~/admin/exam.aspx");
            }
            catch (Exception ex)
            {
                panel7.Visible = true;
                Label4.Text = "" + ex.Message;
                Label4.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void btn_panelExamReport_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel8.Visible = false;
            panel_examReport.Visible = true;
            panel11.Visible = false;
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#343A40");
        }


        protected void btn_panelFaclist_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = true;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel8.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            get_branchdrp();
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }
        protected void btn_paneladdEmail_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel8.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            //get_branchdrp();
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }

        protected void btn_panelAddStudents_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel8.Visible = false;
            panel_addStudents.Visible = true;
            panel9.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            //get_branchdrp();
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }

        protected void btn_panelflush_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel8.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            //get_branchdrp();
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }

        protected void btn_paneladdSubject_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = true;
            panel_Faculty.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = false;
            panel8.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            //Button3.Visible = false;
            Button2.Visible = false;
            //get_categoryydrp();
            get_branchdrpp();
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }

        protected void btn_panelPassword_Click(object sender, EventArgs e)
        {
            panel_subject.Visible = false;
            panel_Faculty.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel_password.Visible = true;
            panel8.Visible = false;
            panel_addStudents.Visible = false;
            panel9.Visible = false;
            panel_examReport.Visible = false;
            panel11.Visible = false;
            //Button3.Visible = false;
            Button2.Visible = false;
            //get_categoryydrp();
            get_branchdrpp();
            btn_panelfaclist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdsub.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdemail.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelflush.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_panelPassword.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_addStudents.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_examreport.BackColor = ColorTranslator.FromHtml("#DC3545");
        }

        protected void btn_passEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_NewPassword.Text.CompareTo(txt_RePassword.Text) != 0)
                {
                    panel8.Visible = true;
                    Label6.Visible = true;
                    Label6.Text = "Password not matched!";
                    txt_NewPassword.Text = "";
                    txt_RePassword.Text = "";
                }
                else
                {
                    panel8.Visible = true;
                    DBHelper.Class1 obj = new DBHelper.Class1();
                    obj.ins_upd_del("update admintab set pass = '" + txt_NewPassword.Text + "'");
                    Label6.Text = "Password Change Successfully!!";
                    Label6.ForeColor = System.Drawing.Color.Green;
                    //Response.Redirect("index2.aspx");
                }
            }
            catch (Exception ex)
            {
                panel8.Visible = true;
                Label6.Text = ex.Message;
                Label6.ForeColor = System.Drawing.Color.Red;

            }


        }


        protected void flush8th(object sender, EventArgs e)
        {
            try
            {

                obj.ins_up_del("update users set sem = 9 where sem = 8");

                panel7.Visible = true;
                Label4.Text = "Flushed Successfully!!Still you can get it if you want..";
                Label4.ForeColor = System.Drawing.Color.ForestGreen;
            }
            catch (Exception ex)
            {
                panel7.Visible = true;
                Label4.Text = "" + ex.Message;
                Label4.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void Update(object sender, EventArgs e)
        {
            try
            {
                DataTable mydt = new DataTable();
                mydt = obj.sel("select * from recoverytable");
                string premail = mydt.Rows[0]["email"].ToString();
                obj.ins_up_del("update recoverytable set email = '" + txt_emailrec.Text + "', pass = '" + txt_passrec.Text + "' where email = '" + premail + "'");
                panel5.Visible = true;
                Label3.Text = "Email Changed Successfully!!";
                Label3.ForeColor = System.Drawing.Color.ForestGreen;
            }
            catch (Exception ex)
            {
                panel5.Visible = true;
                Label3.Text = "" + ex.Message;
                Label3.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void LoadMe(object sender, EventArgs e)
        {
            GridView_StudentsList.DataSource = null;
            GridView_StudentsList.DataBind();
            BindAssignGrid();
        }

        protected void BindAssignGrid()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                String branch = DropDownList3.Text;
                int sem = Convert.ToInt32(drp_sem.SelectedItem.Value);

                MySqlCommand cmd = new MySqlCommand("select enroll from users where branch = '" + branch + "' and sem =" + sem + " and passOutYear = " + DropDownList4.Text + " ", con);

                try
                {
                    con.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            da.Fill(dtatble);
                            GridView_StudentsList.DataSource = dtatble;
                            GridView_StudentsList.DataBind();
                            if (dtatble.Rows.Count > 0)
                                btnSave.Visible = true;
                            else
                                btnSave.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    btnSave.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong </br>" + ex.Message;
                }
            }

        }


        protected void checkAll(object sender, EventArgs e)
        {
            CheckBox header = (CheckBox)GridView_StudentsList.HeaderRow.FindControl("checkAll");
            foreach (GridViewRow row in GridView_StudentsList.Rows)
            {
                CheckBox rows = (CheckBox)row.FindControl("chkSelect");
                if (header.Checked == true)
                {
                    rows.Checked = true;
                }
                else
                {
                    rows.Checked = false;
                }
            }
        }


        protected void Save(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {



                    //String cat = getCat();


                    string q = "select * from faculty where email='" + txt_email.Text + "' OR mobile = '" + txt_mobile.Text + "'";
                    con.Open();
                    DataTable dt = new DataTable();
                    dt = obj.sel(q);
                    if (dt.Rows.Count == 0)
                    {


                        MySqlCommand cmd = new MySqlCommand("insert into faculty(fName,lName,branch,email,mobile,pass) values('" + txt_fName.Text + "','" + txt_lName.Text + "','" + drp_branch.Text + "','" + txt_email.Text + "','" + txt_mobile.Text + "','" + txt_Pass.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();
                        //int m = Convert.ToInt16(txt_questionId.Text);
                        //m++;
                        //checkImageupload();
                        //obj.ins_up_del("update exam set exam_totalquestions='" + qid + "',exam_marks='" + qid + "',exam_marks='" + m + "' where exam_id='" + eid + "'");
                        Response.Redirect("RIndex.aspx");
                        con.Close();
                    }
                    else
                    {
                        Label1.Focus();
                        panel1.Visible = true;
                        Label1.Text = "Email or Mobile already in use! </br>";
                    }

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. </br>" + ex.Message;
                }
            }
        }

        protected void Loadd()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                String branch = DropDownList1.SelectedItem.Value;
                int sem = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                MySqlCommand cmd = new MySqlCommand("select subject_name from subjects where branchName = '" + branch + "' AND Sem = " + sem + "", con);

                try
                {
                    con.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            da.Fill(dtatble);
                            GridView_SubjectssList.DataSource = dtatble;
                            GridView_SubjectssList.DataBind();
                            if (dtatble.Rows.Count > 0)
                            {
                                Button2.Visible = true;
                                panel3.Visible = true;
                            }
                            else
                            {
                                Button2.Visible = false;

                                panel3.Visible = true;
                                Button2.Visible = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //btnSave.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong </br>" + ex.Message;
                }
            }

        }

        protected void Del1(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    foreach (GridViewRow row in GridView_SubjectssList.Rows)
                    {
                        //Label1.Text = "Inside for .  </br>";
                        if ((row.FindControl("chkSelect") as CheckBox).Checked)
                        {
                            String id = row.Cells[0].Text.ToString();
                            con.Open();
                            DataTable dtemp = new DataTable();
                            dtemp = obj.sel("select subject_id from subjects where subject_name = '" + id + "' AND branchName = '" + DropDownList1.Text + "'");
                            if (dtemp.Rows.Count != 0)
                            {
                                int ffd = Convert.ToInt32(dtemp.Rows[0][0].ToString());
                                obj.ins_up_del("delete from exam where subject_fid = " + ffd + "");
                            }
                            else { }
                            obj.ins_up_del("delete from subjects where subject_name = '" + id + "' and branchName = '" + DropDownList1.Text + "'");
                            Loadd();
                            con.Close();

                        }
                        else
                        {
                            //Label1.Visible = true;
                            //Label1.Text = "Inside for else.  </br>";
                        }
                    }


                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. </br>" + ex.Message;
                }
            }
        }

        protected void Save12(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {



                    //String cat = getCat();

                    int semm = Convert.ToInt32(DropDownList2.Text);
                    string q = "select * from subjects where subject_name='" + TextBox1.Text + "' AND branchName = '" + DropDownList1.Text + "' AND Sem = " + semm + "";
                    con.Open();
                    DataTable dt = new DataTable();
                    dt = obj.sel(q);
                    if (dt.Rows.Count == 0)
                    {


                        MySqlCommand cmd = new MySqlCommand("insert into subjects(subject_name,branchName,Sem) values('" + TextBox1.Text + "','" + DropDownList1.Text + "'," + semm + ")", con);
                        int i = cmd.ExecuteNonQuery();
                        //int m = Convert.ToInt16(txt_questionId.Text);
                        //m++;
                        //checkImageupload();
                        //obj.ins_up_del("update exam set exam_totalquestions='" + qid + "',exam_marks='" + qid + "',exam_marks='" + m + "' where exam_id='" + eid + "'");
                        Response.Redirect("RIndex.aspx");
                        con.Close();
                    }
                    else
                    {
                        Label1.Focus();
                        panel1.Visible = true;
                        Label1.Text = "Subject is already there! </br>";
                    }

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. </br>" + ex.Message;
                }
            }
        }

        public void get_categoryydrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
                try
                {
                    con.Open();
                    DropDownList2.DataSource = cmd.ExecuteReader();
                    DropDownList2.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select Semester", "-1");
                    DropDownList2.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_categoryyadrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
                try
                {
                    con.Open();
                    drp_sem.DataSource = cmd.ExecuteReader();
                    drp_sem.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select Semester", "-1");
                    drp_sem.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_categoryyadrpi()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
                try
                {
                    con.Open();
                    drp_categoryexam.DataSource = cmd.ExecuteReader();
                    drp_categoryexam.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select Semester", "-1");
                    drp_categoryexam.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    panel1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            Loadd();

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            get_categoryydrp();

        }
        public void get_branchdrpp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {
                    con.Open();

                    DropDownList1.DataSource = cmd.ExecuteReader();


                    DropDownList1.DataBind();
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select branch", "-1");

                    DropDownList1.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }


        public void get_branchhdrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {
                    con.Open();
                    DropDownList3.DataSource = cmd.ExecuteReader();


                    DropDownList3.DataBind();

                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select branch", "-1");
                    DropDownList3.Items.Insert(0, li);

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }



        public void get_branchdrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {
                    con.Open();
                    drp_branch.DataSource = cmd.ExecuteReader();


                    drp_branch.DataBind();

                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select branch", "-1");
                    drp_branch.Items.Insert(0, li);

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_branchdrpi()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct branch from branch", con);
                try
                {
                    con.Open();
                    drp_brancha.DataSource = cmd.ExecuteReader();


                    drp_brancha.DataBind();

                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select branch", "-1");
                    drp_brancha.Items.Insert(0, li);

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }


        public void get_yeardrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select distinct passOutYear from users", con);
                try
                {
                    con.Open();
                    DropDownList4.DataSource = cmd.ExecuteReader();


                    DropDownList4.DataBind();

                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("Select year", "-1");
                    DropDownList4.Items.Insert(0, li);

                }
                catch (Exception ex)
                {
                    Label1.Focus();
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

    }
}