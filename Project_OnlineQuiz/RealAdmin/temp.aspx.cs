using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_OnlineQuiz.RealAdmin
{
    public partial class temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void home(object sender, EventArgs e) {
            //Response.Redirect("Home.aspx");
        }
        protected void bye(object sender, EventArgs e)
        {
            //Response.Redirect("/Home.aspx");
        }
    }
}