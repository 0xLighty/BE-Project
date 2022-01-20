using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Project_OnlineQuiz.Admin
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string file = context.Request.QueryString["v"].ToString();
            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            if (file == "myexcel.xlsx")
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=SampleStudents_VGEC_OnlineQuiz.xlsx");
            }
            else if (file == "Questions.xlsx")
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=SampleQuestions_VGEC_OnlineQuiz.xlsx");
            }
            else { }
            context.Response.WriteFile(System.Web.HttpContext.Current.Server.MapPath("Files\\"+file));
            context.Response.End();
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