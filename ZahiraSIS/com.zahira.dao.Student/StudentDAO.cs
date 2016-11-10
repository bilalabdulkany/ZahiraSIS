using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ZahiraSIS.com.zahira.bean.student;
using System.Data;
using ZahiraSIS.com.zahira.bean;

namespace ZahiraSIS
{
    class StudentDAO
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();

        public StudentArrearsBean getStudentArrears(String studentClass)
        {
            StudentArrearsBean bean = null;
            String _bfArrears;
            String _curArrears;
            String _curBfArrears;
            SqlDataReader rdr = null;            
            try
            {              
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(bfarrears)as bfArrears, SUM(curarrears) as curArrears,SUM(curbfarres) as curBfArrears from student where key_class =" + studentClass + " group by key_class", conn);
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
        public DataTable getStudentArrearsByIndex(String studentIndex)
        {
            
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable tbl = null;
            try
            {
                
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "select trnno,trndate,paid,payfrom,payto,mfeerate,totarrears,arrearsfrm,arrearsto,key_class from mnthfeepay where mnthfeepay.key_stu ="
  + "(select key_fld from student where admno = @Index)";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Index", SqlDbType.VarChar).Value = studentIndex;

                Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("params:" + studentIndex);
                //  rdr = cmd.ExecuteReader();
                tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
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
                    // rdr.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;

        }

        /**
         * Get a DataTable of the student admission numbers when the class is given.
         **/
        public DataTable getStudentIndexFromClass(String studentClass)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "SELECT admno, name FROM dbo.student "
                      + "where key_class = @Class"
                      + " order by admno";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = studentClass;

                Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("params:" + studentClass);
                //  rdr = cmd.ExecuteReader();
                tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
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
                    // rdr.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;

        }

        public DataTable getStudentArrearsByDate(String studentClass, String fromDate, String toDate)
        {
            // String _keyfield;
            //String _admno;
            //String _name;
            
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable tbl = null;
            try
            {
            
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "SELECT key_fld, active, mfeecnsn, admno, name, address, registerno,prntname,  key_class, bfarrears, curarrears, key_change, curbfarres, CONVERT(VARCHAR(11), admon, 106) as admon, "
                     + "CONVERT(VARCHAR(11), arrearsfrm, 106) as arrearsfrm, CONVERT(VARCHAR(11), arrearsto, 106) as arrearsto FROM dbo.student "
                      + "where key_class = @Class and arrearsfrm >= @From and arrearsto <= @To"
                      + " order by arrearsfrm asc";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = studentClass;
                cmd.Parameters.Add("@From", SqlDbType.DateTime).Value = fromDate + " 00:00:00.000";
                cmd.Parameters.Add("@To", SqlDbType.DateTime).Value = toDate + " 00:00:00.000"; ;
                Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("params:" + studentClass + " " + fromDate + " " + toDate);
                //  rdr = cmd.ExecuteReader();

                tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
                /* rdr.Read();
                 if (rdr.HasRows)
                 {

                     _keyfield = rdr["key_fld"].ToString();
                     _admno = rdr["admno"].ToString();
                     _name = rdr["name"].ToString();

                     Console.WriteLine("Data from database:" + _keyfield + ";" + _admno + ";" + _name);     
                 }
                 */

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
                    // rdr.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;

        }

        public StuclassBean getStudentClasses(int stuClass)
        {
            StuclassBean bean = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "select key_fld,key_grd,key_med,name,code,classcode,key_tea,key_fee,key_change from stuclass where key_fld=" + stuClass;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //cmd.Parameters.Add("@Class", SqlDbType.Int).Value = stuClass;
                Console.WriteLine(cmd.CommandText);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                //string key_fld = "";
                if(rdr.HasRows)
                {
                    int key_fld = int.Parse(rdr["key_fld"]+"");
                    int key_grd = (int)rdr["key_grd"]; 
                    int key_med = (int)rdr["key_med"];
                    string name = rdr["name"] + "";
                    string code = rdr["code"] + "";
                    string classcode = rdr["classcode"] + "";
                    int key_tea = (int)rdr["key_tea"]; 
                    int key_fee = (int)rdr["key_fee"]; 
                    int key_change = (int)rdr["key_change"];                  
                    bean = new StuclassBean();
                   bean.Key_fld=key_fld;
                    bean.Key_grd = key_grd;
                    bean.Key_med = key_med;
                    bean.Name = name;
                    bean.Code = code;
                    bean.Classcode = classcode;
                    bean.Key_tea = key_tea;
                    bean.Key_fee = key_fee;
                    bean.Key_change = key_change;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                try
                {
                    conn.Close();
                    // rdr.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return bean;
        }

    }
}
