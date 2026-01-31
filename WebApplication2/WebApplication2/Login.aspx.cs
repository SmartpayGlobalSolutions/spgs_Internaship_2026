using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        DBHelper db = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack) // you Page_load Is called first time and Not called from any event.
            {
                Session.Clear();
                Session.Abandon();    
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //Response.Write("<script> alert('"+txtUsername.Text+"'); </script>");
            //Response.Write("<h3><i>Welcome " + txtUsername.Text + "</i></h3>");
            
            string username = txtUsername.Text.Trim();
            string password = txtpassword.Text.Trim();
            
            if (string.IsNullOrEmpty(username))
            {
                Response.Write("<script> alert('Please enter valid Username !'); </script>");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                Response.Write("<script> alert('Please enter valid password !'); </script>");
                return;
            }

            db.UserLogin(username, password);
            //Response.Write("You are successfully Logged In !");

            if (username == DBLogic._username && password == DBLogic._password)
            {
                Session["username"] = username;
                Session["loginStatus"] = "1";

                Response.Redirect("welcome.aspx");
            }
            else
            {
                Response.Write("<script> alert('username or password is not valid !'); </script>");
                return;
            }
        }
    }
}