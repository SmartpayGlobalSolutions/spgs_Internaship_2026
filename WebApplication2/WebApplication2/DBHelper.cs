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
        
        public int UserLogin(string _user , string _pass)
        {
            string Qry = "SELECT firstName +' '+ lastName as UserFullName FROM users WHERE userName = '"+_user+"' AND Password = '"+_pass+"'";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(Qry, conn);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            string returnValue = dt.Rows[0]["UserFullName"].ToString();


            conn.Close();
            //if (conn.State == ConnectionState.Closed)
            //{
            //    conn.Open();
            //}


            return 1;
        }
    }
}