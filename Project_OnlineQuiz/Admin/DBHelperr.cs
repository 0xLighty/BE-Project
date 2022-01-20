using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project_OnlineQuiz.Admin
{
    public class DBHelperr
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
            public DBHelperr()
            {
            con.ConnectionString = connectionString ;
            }

            public int ins_up_del(String str)
            {
                con.Open();
                cmd.CommandText = str;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }

            public DataTable sel(String str)
            {
                con.Open();
                dt.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(str, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
        




        
    }
}