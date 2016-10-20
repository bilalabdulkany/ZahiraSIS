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
            String connectionString = "";
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {

                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand("select * from z_users where username='" + username + "' AND password ='" + password + "'", conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    verify = true;
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
            }
            finally {
                try
                {
                    conn.Close();
                    conn.Dispose();
                } catch (Exception e1) {
                    Console.WriteLine("exception in closing connection:" + e1);
                }
            }
            return verify;
        }

        public String getTeacherName(String teacher) {
            String tName = "";
            String connectionString = "";
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand("select name from teacher where key_fld='" + teacher + "'",conn);
                Console.WriteLine("SQL: "+cmd.CommandText);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                   
                   tName = rdr["name"].ToString();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
            }
            finally
            {
                try
                {
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception e1)
                {
                    Console.WriteLine("exception in closing connection:" + e1);
                }
            }
            return tName;

        }




    }

    

}
