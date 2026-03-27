using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class DBHelper
    {
        string connectionString = "Server=DESKTOP-S2204R2;Database=SalesApplication;User Id=sa;Password=123123;";
        
        public string UserLogin(string _user , string _pass)
        {
            string Qry = "SELECT firstName +' '+ lastName as UserFullName FROM users WHERE userName = '"+_user+"' AND Password = '"+_pass+"'";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(Qry, conn);
            
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string UserFullName = "";

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Invalid Username or Password !");
            }
            else
            {
                UserFullName = dt.Rows[0][0].ToString();
            }

            conn.Close();
            //if (conn.State == ConnectionState.Closed)
            //{
            //    conn.Open();
            //}

            return UserFullName;
        }

        public int UserSignup(string userName, string firstName, string LastName ,string Password ,string EmailAddress)
        {
            string Qry = string.Format("INSERT INTO Users (userName,firstName,lastName,emailAddress,password) VALUES ('{0}','{1}','{2}','{3}','{4}')", userName, firstName, LastName, EmailAddress, Password);

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand cmd = new SqlCommand(Qry, conn);
            int affectedRows = cmd.ExecuteNonQuery();
            
            conn.Close();

            return affectedRows;
        }


        public DataTable GetDataFromQuery(string qry)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter(qry, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}