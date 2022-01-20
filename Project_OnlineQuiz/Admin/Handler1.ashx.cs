using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
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

   
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

        public class Handler1 : IHttpHandler
        {
            //createting the object of Default.aspx class page to 
            //call connection and use strings variable
            imageTemp cls = new imageTemp();

            public void ProcessRequest(HttpContext context)
            {
            //storing the querystring value that comes from Defaul.aspx page
            try
            {
                string displayimgid = context.Request.QueryString["id_Image"].ToString();
                string str = context.Request.QueryString["str"].ToString();
                cls.connection();
                //retriving the images on the basis of id of uploaded 
                //images,by using the querysting valaues which comes from Defaut.aspx page


                cls.query = "select " + str + " from question where id=" + displayimgid;
                MySqlCommand com = new MySqlCommand(cls.query, cls.con);
                MySqlDataReader dr = com.ExecuteReader();
                dr.Read();

                context.Response.BinaryWrite((Byte[])dr[0]);

                context.Response.End();
            }
            catch (Exception ex) {
                context.Response.Write("n");
            }

            }

            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
}
