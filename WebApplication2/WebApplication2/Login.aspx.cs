using System;
using System.Collections.Generic;
using System.Data;
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
            //int rslt = db.UserSignup("", "", "", "", "");

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


            try
	        {
                string qry = string.Format("SELECT firstName,lastName FROM users WHERE userName = '{0}' AND Password = '{1}'",username,password);
                //string fullname = db.UserLogin(username, password);
                DataTable dt = db.GetDataFromQuery(qry);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Invalid username or password !");
                }

                Session["username"] = dt.Rows[0]["firstName"].ToString() +" "+ dt.Rows[0]["lastName"].ToString();
                Session["loginStatus"] = "1";

                Response.Redirect("welcome.aspx");
	        }
	        catch (Exception ex)
	        {
                Response.Write("<script> alert('"+ ex.Message +"'); </script>");
                return;
            }
        }
    }
}