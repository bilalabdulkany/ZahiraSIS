using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahiraSIS
{
    class dbConnector
    {

        public bool connectDB(String username,String password) {
            bool verify = false;
            try
            {
                SqlDataReader rdr = null;
                SqlConnection conn = new SqlConnection("Data Source=ABDULKANY\\SQLEXPRESS32;Initial Catalog=Zahira_SIS;Integrated Security=True");
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
    }
}
