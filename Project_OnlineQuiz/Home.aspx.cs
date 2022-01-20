using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_OnlineQuiz
{
    public partial class Home : System.Web.UI.Page
    {
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(Session["rc"] as string))
            {
                if (Session["rc"].ToString() == "done")
                {
                    Response.Redirect("index2.aspx");
                }
            }
            else
            Session["rc"] = "Home";
        }

        protected void cccc(object sender, EventArgs e) {
            if (count == 5) {
                count = 0;
                Response.Redirect("RealAdmin/AdLogin.aspx");
            }
            count++;
        }
    }

}