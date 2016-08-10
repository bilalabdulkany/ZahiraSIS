using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ZahiraSIS.com.zahira.bean.student;

namespace ZahiraSIS
{
    class StudentDAO
    {

        
        public StudentArrearsBean getStudentArrears(String studentClass) {
            StudentArrearsBean bean = null;
            String _bfArrears;
            String _curArrears;
            String _curBfArrears;
            try
            {
                
                String connectionString = "";
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();
                SqlDataReader rdr = null;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(bfarrears)as bfArrears, SUM(curarrears) as curArrears,SUM(curbfarres) as curBfArrears from student where key_class ="+studentClass+" group by key_class",conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {

                    _bfArrears = rdr["bfArrears"].ToString();
                    _curArrears = rdr["curArrears"].ToString();
                    _curBfArrears = rdr["curBfArrears"].ToString();
                    bean = new StudentArrearsBean(_bfArrears, _curArrears, _curBfArrears);
                }

                conn.Close();
                conn.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
            }
            return bean;

        }
    }

    

}
