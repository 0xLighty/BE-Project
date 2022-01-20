using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
namespace Project_OnlineQuiz
{
    public class DBHelper
    {
        public class Class1
        {
            static String server = "063LATITUDE5420/SQLEXPRESS";
            static String database = "online_quiz";
            static String uid = "Jay";
            static String password = "BJay";
            string connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            public Class1()
            {
                con.ConnectionString = connectionString;
            }

            public int ins_upd_del(String str)
            {

                try
                {
                    con.Open();
                    cmd.CommandText = str;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex) { }
                finally { con.Close(); }
                    return 1;
                

            }

            public DataTable sel(String str)
            {
                try
                {
                    con.Open();
                    dt.Clear();
                    MySqlDataAdapter da = new MySqlDataAdapter(str, con);
                    da.Fill(dt);

                }
                catch (Exception ex) { }
                finally { con.Close(); }
                return dt;
            }
        }

    
    }
}