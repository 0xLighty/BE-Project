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
    public partial class exam : System.Web.UI.Page
    {
        public static String examId;
        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        DBHelperr obj = new DBHelperr();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["rcf"].ToString() == "done")
                {

                    if (!IsPostBack)
                    {

                        panel_examlist.Visible = true;
                        panel_addexam.Visible = false;
                        panel_assign.Visible = false;
                        btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
                        btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");
                        // getexamList();
                    }
                    getexamList();
                }
            }
            catch (Exception ex)
            {
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "Something went wrong.</br>" + ex.Message;
            }
        }

        //-------------Panel Exam List---------
        protected void btn_panelexamlist_Click(object sender, EventArgs e)
        {
            GridView_StudentsList.DataSource = null;
            GridView_StudentsList.DataBind();
            panel_examlist.Visible = true;
            panel_addexam.Visible = false;
            panel_assign.Visible = false;
            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");
            getexamList();
        }

        //-----------Panel Add Exam------------
        protected void btn_paneladdexam_Click(object sender, EventArgs e)
        {
            GridView_StudentsList.DataSource = null;
            GridView_StudentsList.DataBind();
            panel_examlist.Visible = false;
            panel_addexam.Visible = true;
            panel_assign.Visible = false;
            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#343A40");
            get_branchhdrp();
            //get_categorydrp();
            //get_subjectdrp();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_categorydrp();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_subjectdrp();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadinexam();
        }

        protected void loadinexam() {
            DataTable dt_sid = obj.sel("select subject_name from subjects where subject_id='" + drp_subjectexam.Text + "'");
            string sid = dt_sid.Rows[0]["subject_name"].ToString();

            DataTable dt_count = obj.sel("select count(exam_id) as exam_id from exam where subject_fid=" + drp_subjectexam.SelectedValue + "");
            int count = Convert.ToInt16(dt_count.Rows[0]["exam_id"]);
            count++;

            String myex = drp_brancha.Text + "_"+ drp_categoryexam.Text+"_"+ sid + "_"+DateTime.Now.Year.ToString()+"_"+count;
            txt_examid.Text = myex;
        }

        //-----------Panel Assign Exam------------
        protected void btn_panelassign_Click(object sender, EventArgs e)
        {
            GridView_StudentsList.DataSource = null;
            GridView_StudentsList.DataBind();
            btnSave.Visible = false;
            panel_examlist.Visible = false;
            panel_addexam.Visible = false;
            panel_assign.Visible = true;
            Label1.Visible = false;
            //Label1.Visible = true;
            //Label1.Text = "Inside Assign";
            //panel_addexam_warning.Visible = true;
            //lbl_examaddwarning.Text = "Inside Assign: </br>";

            btn_panelexamlist.BackColor = ColorTranslator.FromHtml("#DC3545");
            btn_paneladdexam.BackColor = ColorTranslator.FromHtml("#DC3545");
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "heyDude":
                    examId = btn.CommandArgument.ToString();
                    //Label1.Text = "ExamID: </br>" + examId;
                    break;
            }
            //BindAssignGrid();
            get_branchdrp();
            get_categoryydrp();
            //get_students();
            //get_categorydrp();
            //get_subjectdrp();

        }

        protected void BindAssignGrid()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                String branch = drp_branch.SelectedItem.Value;
                int sem = Convert.ToInt32(drp_sem.SelectedItem.Value);

                MySqlCommand cmd = new MySqlCommand("select enroll from users where branch = '" + branch + "' and sem =" + sem + " and enroll NOT IN (select enroll from assign where exam_id = '" + examId + "')", con);

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

        protected void Button1_Click()
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, "Yes");
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
            //GridView1.Caption = Path.GetFileName(FilePath);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //Insert Data into Table
            insertdata(dt);

        }

        void insertdata(DataTable dt)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(connectionString);
                //MySqlConnection cn = new MySqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == null || dt.Rows[i][0].ToString() == String.Empty)
                    {
                        continue;
                    }
                    cmd.CommandText = "insert into question (question_id, exam_id, category_name, question_name, opt_one, opt_two, opt_three, opt_four, question_answer,marks) values ('" + dt.Rows[i][0] + "','" + txt_examid.Text + "','" + drp_categoryexam.SelectedValue + "' ,'" + dt.Rows[i][1] + "', '" + dt.Rows[i][2] + "', '" + dt.Rows[i][3] + "', '" + dt.Rows[i][4] + "', '" + dt.Rows[i][5] + "', '" + dt.Rows[i][6] + "', '" + dt.Rows[i][7] + "')";
                    cmd.ExecuteNonQuery();
                }

                DataTable dt_tm = obj.sel("select sum(marks) from question where exam_id='" + txt_examid.Text + "'");
                int marks = Convert.ToInt16(dt_tm.Rows[0][0]);
                obj.ins_up_del("update exam set exam_marks=" + marks + ", exam_totalquestions=" + dt.Rows.Count + " where exam_id='" + txt_examid.Text + "'");

            }
            catch (Exception ex)
            {
                panel_addexam_warning.Visible = true;

                lbl_examaddwarning.Text = "Something went wrong.</br>" + ex.Message;
            }
        }


        protected void btn_addexam_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    DateTime today = DateTime.Today;
                    //DateTime ta = DateTime.CURDATE();
                    //string tempdate = txt_examdate.Text;
                    //DateTime dtd = Convert.ToDateTime(txt_examdate.Text);
                    String fidd = Session["facemail"].ToString();
                    MySqlCommand cmd = new MySqlCommand("insert into exam (exam_id,exam_name, exam_description, exam_duration, category_fid, subject_fid, exam_pass, setter) values('" + txt_examid.Text + "','" + txt_examname.Text + "','" + txt_examdis.Text + "', '" + txt_examduration.Text + "','" + drp_categoryexam.SelectedValue + "','" + drp_subjectexam.SelectedValue + "','" + txt_exampassmarks.Text + "', '" + fidd + "')", con);

                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Button1_Click();
                            Response.Redirect("~/admin/exam.aspx");
                        }
                        else
                        {
                            txt_examname.Focus();
                            panel_addexam_warning.Visible = true;
                            lbl_examaddwarning.Text = "Try again.";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. </br>" + ex.Message;
                    }
                }
            }
            else
            {
                txt_examname.Focus();
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "You must fill all the requirements";
            }

        }


        //------------------------------------
        //
        //
        //
        //------------------------
        //......................Ahiya.................
        //--------------------------------
        //
        //
        //
        //------------------------------
        /*protected void Save(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                //DateTime today = DateTime.Today;
                //DateTime ta = DateTime.CURDATE();
                MySqlCommand cmd = new MySqlCommand("insert into assign (exam_id,enroll) values(examId,@enroll)", con);//here

                try
                {
                    con.Open();

                    foreach (GridViewRow row in GridView_StudentsList.Rows)
                    {
                        //Get the HobbyId from the DataKey property.
                        int studentEnroll = Convert.ToInt32(GridView_StudentsList.DataKeys[row.RowIndex].Values[0]);

                        //Get the checked value of the CheckBox.
                        bool isSelected = (row.FindControl("chkSelect") as CheckBox).Checked;

                        //Save to database
                        if (isSelected == true)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@exam_id", examId);
                            cmd.Parameters.AddWithValue("@enroll", studentEnroll);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    /*int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        
                        //Response.Redirect("~/admin/exam.aspx");
                    }
                    else
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Try again. Subject is not added";
                    }*/
        /* }
         catch (Exception ex)
         {
             txt_examname.Focus();
             //panel_addexam_warning.Visible = true;
             Label1.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
         }
     }

            
 }*/
        protected void Loadd(object sender, EventArgs e)
        {
            GridView_StudentsList.DataSource = null;
            GridView_StudentsList.DataBind();
            BindAssignGrid();
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

            try
            {

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    int ccnntt = 3;

                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();

                    dt.Columns.AddRange(new DataColumn[2] {new DataColumn("examId", typeof(String)),
                                                            new DataColumn("enroll", typeof(Decimal)) });

                    //String branch = drp_branch.SelectedItem.Value;
                    //int sem = Convert.ToInt32(drp_sem.SelectedItem.Value);

                    //Label1.Text = "Inside before for .  </br>";
                    foreach (GridViewRow row in GridView_StudentsList.Rows)
                    {
                        //Label1.Text = "Inside for .  </br>";
                        if ((row.FindControl("chkSelect") as CheckBox).Checked)
                        {
                            Decimal id = Decimal.Parse(row.Cells[1].Text);
                            con.Open();
                            dt1.Clear();
                            MySqlDataAdapter daa = new MySqlDataAdapter("select * from assign where exam_id = " + examId + " and enroll = " + id + "", con);
                            //MySqlCommand cmdd = new MySqlCommand("select * from assign where exam_id = " + examId + " and enroll = " + id + "");
                            daa.Fill(dt1);
                            con.Close();

                            //dt1=obj.sel("select * from assign where exam_id = "+examId+" and enroll = "+id+"");
                            if (dt1.Rows.Count > 0)
                            {
                                Label1.Visible = true;
                                Label1.Text = "Exam has already been assigned to some selected students..!!  </br>";
                                ccnntt = 1;
                                break;
                            }
                            //SELECT TOP 1 1 FROM products WHERE id = 'some value';
                            dt.Rows.Add(examId, id);
                            ccnntt = 0;
                            Label1.Visible = false;
                            //Label1.Text = "Inside for else.  </br>"+examId;
                        }
                        else
                        {
                            //Label1.Visible = true;
                            //Label1.Text = "Inside for else.  </br>";
                        }
                    }
                    int i = 0;
                    while (i != dt.Rows.Count)
                    {
                        if (dt.Rows.Count > 0 && ccnntt == 0)
                        {
                            //string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                            //using (MySqlConnection con = new MySqlConnection(connectionString))
                            //{
                            string eid = dt.Rows[i][0].ToString();
                            Decimal enrl = Convert.ToDecimal(dt.Rows[i][1].ToString());

                            obj.ins_up_del("insert into assign(exam_id,enroll,examdate,branchAs,semAs) values('" + eid + "','" + enrl + "',curdate(), '" + drp_branch.Text + "', " + drp_sem.Text + ")");
                            GridView_StudentsList.DataSource = null;
                            GridView_StudentsList.DataBind();

                            /*
                            using (MySqlBulkCopy MySqlBulkCopy = new MySqlBulkCopy(con))
                            {
                                //database table name
                                MySqlBulkCopy.DestinationTableName = "dbo.assign";

                                //Map the DataTable columns with that of the database table
                                MySqlBulkCopy.ColumnMappings.Add("examId", "exam_id"); //(Source , Destination)
                                MySqlBulkCopy.ColumnMappings.Add("enroll", "enroll");

                                con.Open();
                                MySqlBulkCopy.WriteToServer(dt);
                                GridView_StudentsList.DataSource = null;
                                GridView_StudentsList.DataBind();
                                con.Close();

                                Response.Redirect("~/admin/exam.aspx");
                            }*/
                            //}
                        }
                        else if (ccnntt != 1)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Please select atleast single student..  </br>";
                        }
                        else { }
                        i++;
                    }
                }
                Response.Redirect("~/admin/exam.aspx");
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong.  </br>" + ex.Message;
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
                    drp_brancha.DataSource = cmd.ExecuteReader();
                    drp_brancha.DataBind();
                    ListItem li = new ListItem("Select branch", "-1");
                    drp_brancha.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    drp_brancha.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        /*protected void grdview_studentlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteexam")
            {
                deleteexam(Convert.ToInt32(e.CommandArgument));
                getexamList();
            }
        }*/

        protected void grdview_examlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteexam")
            {
                deleteexam(Convert.ToString(e.CommandArgument));
                getexamList();
            }
        }

        protected void grdview_examlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview_examlist.PageIndex = e.NewPageIndex;
            getexamList();
        }

        //category in assign panel
        public void get_categoryydrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
                try
                {
                    con.Open();
                    drp_sem.DataSource = cmd.ExecuteReader();
                    drp_sem.DataBind();
                    ListItem li = new ListItem("Select category", "-1");
                    drp_sem.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }




        public void get_categorydrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from semesters", con);
                try
                {
                    con.Open();
                    drp_categoryexam.DataSource = cmd.ExecuteReader();
                    drp_categoryexam.DataBind();
                    ListItem li = new ListItem("Select semester", "-1");
                    drp_categoryexam.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        //method for subject dropdown
        public void get_subjectdrp()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from subjects where branchName = '" + drp_brancha.Text + "' AND Sem = " + drp_categoryexam.SelectedValue + "", con);
                try
                {
                    con.Open();
                    drp_subjectexam.DataSource = cmd.ExecuteReader();
                    drp_subjectexam.DataBind();
                    ListItem li = new ListItem("Select subject", "-1");
                    drp_subjectexam.Items.Insert(0, li);




                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        //
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
                    ListItem li = new ListItem("Select branch", "-1");
                    drp_branch.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        //method for examlist 
        public void getexamList()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                String fidd = Session["facemail"].ToString();
                MySqlCommand cmd = new MySqlCommand("select exam_id,category_name,subject_id,subject_name,exam_name,exam_duration,exam.exam_marks from exam,subjects,semesters where exam.category_fid=semesters.category_id AND exam.subject_fid=subject_id AND exam.setter = '" + fidd + "'", con);

                try
                {
                    con.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            da.Fill(dtatble);
                            grdview_examlist.DataSource = dtatble;
                            grdview_examlist.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel_examlist_warning.Visible = true;
                    lbl_examlistwarning.Text = "Something went wrong </br>" + ex.Message;
                }
            }
        }

        //method to delete exam
        public void deleteexam(string id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string eid = id;
                MySqlCommand cmd = new MySqlCommand("delete from exam where exam_id = '" + eid + "'", con);
                MySqlCommand cmd1 = new MySqlCommand("delete from question where exam_id = '" + eid + "'", con);
                MySqlCommand cmd2 = new MySqlCommand("delete from assign where exam_id = '" + eid + "'", con);
                try
                {
                    con.Open();
                    int j = (int)cmd1.ExecuteNonQuery();
                    int k = (int)cmd2.ExecuteNonQuery();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("~/admin/exam.aspx");
                        Response.Write("Delete Succesfully");
                    }
                    else
                    {
                        panel_examlist_warning.Visible = true;
                        lbl_examlistwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_examlist_warning.Visible = true;
                    lbl_examlistwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }
    }
}