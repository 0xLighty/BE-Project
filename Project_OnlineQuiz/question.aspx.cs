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
namespace Project_OnlineQuiz
{
    public partial class question : System.Web.UI.Page
    {
        

        DBHelper.Class1 obj = new DBHelper.Class1();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string eid1 = Request.QueryString["eid"];
            string enroll = Session["Enrollment"].ToString();
            int checkbool = 0;

            HttpCookie usercookie = Request.Cookies["user_cookies"];
            if (Session["Enrollment"] != null || usercookie != null)
            {
                if (Session["Enrollment"] == null)
                {
                    getstringuser.Text = usercookie["Enrollment"];
                }
                else
                {
                    getstringuser.Text = Session["Enrollment"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            DataTable dt_date = new DataTable();
            dt_date = obj.sel("select examdate from assign where exam_id='" + eid1 + "' AND enroll='" + enroll + "'");
            DateTime dt_day = Convert.ToDateTime(dt_date.Rows[0]["examdate"].ToString());
            String pda = dt_day.ToShortDateString();
            Label1.Text = pda;
            if (!IsPostBack)
            {
                
                DataTable dtt = new DataTable();
                dtt.Clear();
                dtt = obj.sel("select exam_duration from exam where exam_id=" + eid1 + "");
                int time = Convert.ToInt16(dtt.Rows[0]["exam_duration"].ToString());
                if (string.IsNullOrEmpty(Session[eid1 + enroll] as string))
                {
                    Session[eid1 + enroll] = DateTime.Now.AddMinutes(time).ToString();
                    
                }
                string eid = Request.QueryString["eid"];
                if (eid == null)
                {
                    Response.Redirect("index2.aspx");
                }
                string enrollment = Session["Enrollment"].ToString();
                DataTable dt1 = new DataTable();
                dt1 = obj.sel("select * from result where exam_fid='" + eid + "' AND user_enroll='"+enrollment+"'");

                if (dt1.Rows.Count > 0)
                {
                    btn_submit.Visible = false;
                    lblTime.Visible = false;
                    
                    panel_questshow_warning.Visible = true;
                    lbl_questshowwarning.Visible = true;
                    lbl_questshowwarning.Text = "You Can not retake this exam";
                    checkbool = 1;
                    Response.Redirect("myresult.aspx?eid="+eid);
                }
                else
                {
                    if (dt_day.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        questionistmethod(eid);
                    }
                    else
                    {
                        saveinresult("fail", 0);
                    }
                }

            }

            if (checkbool == 0)
            {
                lblTime.Visible = true;
                DataTable dt = new DataTable();
                dt.Columns.Add("EndDate", typeof(DateTime));
                //string enroll = Session["Enrollment"].ToString();
                dt.Rows.Add(Session[eid1 + enroll].ToString());
                DateTime startDate = DateTime.Now;
                DateTime endDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                lblTime.Text = CalculateTimeDifference(startDate, endDate);
            }
            else {
                lblTime.Visible = false;
                lblTime.Text = "0";
            }
           

        }

        

        public string CalculateTimeDifference(DateTime startDate, DateTime endDate)
        {
            int days = 0; int hours = 0; int mins = 0; int secs = 0;
            string final = string.Empty;
            if (endDate > startDate)
            {
                days = (endDate - startDate).Days;
                hours = (endDate - startDate).Hours;
                mins = (endDate - startDate).Minutes;
                secs = (endDate - startDate).Seconds;
                final = string.Format("{1} hours {2} mins {3} secs", days, hours, mins, secs);
            }
            else
            {
                int select_number = 0;
                foreach (GridViewRow row in gridview_examquestion.Rows)
                {
                    Label li = row.FindControl("lblid") as Label;
                    RadioButton r1 = row.FindControl("option_one") as RadioButton;
                    RadioButton r2 = row.FindControl("option_two") as RadioButton;
                    RadioButton r3 = row.FindControl("option_three") as RadioButton;
                    RadioButton r4 = row.FindControl("option_four") as RadioButton;

                    if (r1.Checked == true)
                    {
                        select_number = 1;
                    }
                    else if (r2.Checked == true)
                    {
                        select_number = 2;
                    }
                    else if (r3.Checked == true)
                    {
                        select_number = 3;
                    }
                    else if (r4.Checked == true)
                    {
                        select_number = 4;
                    }
                    else
                    {
                        select_number = 5;
                    }

                    checkanswer(li.Text,select_number);
                    panel_questshow_warning.Visible = false;
                }
                saveinresult(passfail(), correct_number);


            }
            return final;
        }

        public void questionistmethod(string id)
        {
            string q = "select question.id,question_id,question_name,opt_one,opt_two,opt_three,opt_four,popt_one,marks from question where exam_id='" + id + "'";

            DataTable dt = new DataTable();
            //try
            //{
                dt = obj.sel(q);
                var newdt = dt.AsEnumerable().OrderRandomly().CopyToDataTable();

            if (dt.Rows.Count > 0)
                {
                    gridview_examquestion.DataSource = newdt;
                    gridview_examquestion.DataBind();
                }
                else
                {
                    panel_questshow_warning.Visible = true;
                    lbl_questshowwarning.Text = "Sorry! There is no question in this exam "+ id;
                }
            //}
            //catch (Exception ex)
            //{
            //    panel_questshow_warning.Visible = true;
            //    lbl_questshowwarning.Text = "(questionistmethod)Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            //}
        }


        
        string result = string.Empty;
        
        int correct_number = 0;
        int wrong_number = 0;
        int count = 1;

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            int select_number = 0;
            foreach (GridViewRow row in gridview_examquestion.Rows)
            {
                Label li = row.FindControl("lblid") as Label;
                RadioButton r1 = row.FindControl("option_one") as RadioButton;
                RadioButton r2 = row.FindControl("option_two") as RadioButton;
                RadioButton r3 = row.FindControl("option_three") as RadioButton;
                RadioButton r4 = row.FindControl("option_four") as RadioButton;

                if (r1.Checked == true)
                {
                    select_number = 1;
                }
                else if (r2.Checked == true)
                {
                    select_number = 2;
                }
                else if (r3.Checked == true)
                {
                    select_number = 3;
                }
                else if (r4.Checked == true)
                {
                    select_number = 4;
                }
                else
                {
                    select_number = 5;
                }

                checkanswer(li.Text,select_number);
                panel_questshow_warning.Visible = false;
            }
            saveinresult(passfail(), correct_number);

        }

        
        public void checkanswer(string qid,int select_number)
        {
            string eid = Request.QueryString["eid"];
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = "select * from question where question_id = "+qid+" AND exam_id='"+eid+"'";
                
                cmd.Connection = con;

                try
                {
                    con.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (select_number == Convert.ToInt32(rd["question_answer"]))
                        {
                            DataTable dt_marks = new DataTable();
                            dt_marks.Clear();
                            dt_marks = obj.sel("select marks from question where question_id=" + qid + " AND exam_id=" + eid + "");
                            int temp = Convert.ToInt16(dt_marks.Rows[0]["marks"]);
                            correct_number = correct_number + temp;
                            break;
                        }
                        else
                        {
                            wrong_number = wrong_number + 1;
                            break;
                        }
                    }
                    count++;
                    //con.Close();

                }
                catch (Exception ex)
                {
                    panel_questshow_warning.Visible = true;
                    lbl_questshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
                finally { con.Close(); }
            }
        }

        static String server = "063LATITUDE5420/SQLEXPRESS";
        static String database = "online_quiz";
        static String uid = "Jay";
        static String password = "BJay";
        string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        public string passfail()
        {

            string eid = Request.QueryString["eid"];
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select exam_pass from exam where exam_id = "+eid+"", con);
            
            con.Open();
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (correct_number >= Convert.ToInt32(rd["exam_pass"]))
                {

                    result = result + "pass";
                    break;
                }
                else
                {
                    result = result + "fail";
                    break;
                }
            }
            con.Close();
            return result;
        }

        
        public void saveinresult(string status, int score)
        {
            
            string eid = Request.QueryString["eid"];
            string temp = "NULL";
            string enrollment = Session["Enrollment"].ToString();
            DataTable dto = new DataTable();
            dto = obj.sel("select passOutYear from users where enroll='"+enrollment+"'");
            int payear = Convert.ToInt32(dto.Rows[0]["passOutYear"].ToString());
                string q = "insert into result values("+temp+",'" + status + "'," + score + "," + eid + ",'"+enrollment+"',"+payear+")";

                try
                {
                    obj.ins_upd_del(q);
                    Response.Redirect("~/index2.aspx");
                }
                catch (Exception ex)
                {
                    panel_questshow_warning.Visible = true;
                    lbl_questshowwarning.Text = "(saveinresult)Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        protected void gridview_examquestion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            string eid = Request.QueryString["eid"];
            DataTable dt = new DataTable();
            dt = obj.sel("select exam_duration from exam where exam_id=" + eid + "");
            int time = Convert.ToInt16(dt.Rows[0][0].ToString());

           
        }*/
    }
    public static class Test1
    {

        private static Random random = new Random();

        public static IEnumerable<T> OrderRandomly<T>(this IEnumerable<T> items)
        {
            List<T> randomly = new List<T>(items);

            while (randomly.Count > 0)
            {

                Int32 index = random.Next(randomly.Count);
                yield return randomly[index];

                randomly.RemoveAt(index);
            }
        }
    }
}

