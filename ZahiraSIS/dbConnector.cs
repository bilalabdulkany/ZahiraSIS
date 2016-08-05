using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ZahiraSIS
{
    class dbConnector
    {

        public bool connectDB(String username,String password) {
            bool verify = false;
            try
            {
                String connectionString = "";
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();
                SqlDataReader rdr = null;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from z_users where username='"+username+"' AND password ='"+password+"'", conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    verify = true; 
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception e) {
                Console.WriteLine("exception"+e.ToString());
            }
            return verify;
        }

        public String getTeacherName(String teacher) {
            String tName = "";
            try
            {
                String connectionString = "";
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();
                SqlDataReader rdr = null;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select name from teacher where key_fld='" + teacher + "'",conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                   
                   tName = rdr["name"].ToString();
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
            }
            return tName;

        }
    }

    

}
