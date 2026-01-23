using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class welcome : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginStatus"] == null || Session["loginStatus"].ToString() != "1")
                {
                    Response.Redirect("login.aspx");
                }
                lblWelcomeMessage.Text = "Hello " + Session["username"].ToString();
            
            }
             
        }
    }
}