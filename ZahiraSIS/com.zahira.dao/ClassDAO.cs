using System;
using System.Data;
using System.Data.SqlClient;

namespace ZahiraSIS
{
    public class ClassDAO
    {
        private string connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["Zahira_SISConnectionString"].ToString();

        public DataTable GetClassByType() {
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass = "select statuscode, description from status";
                var cmd = new SqlCommand {
                    Connection = conn,CommandText=selectClass
                };
                Console.WriteLine("SQL:" + cmd.CommandText);
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
                    if (conn != null)
                    {
                        conn.Close();
                        // rdr.Close();
                        conn.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;
        }

        public DataTable GetClass(string type)
        {
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass = "select * from stuclass where status=@Type order by code";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
            };
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;

                Console.WriteLine("SQL:" + cmd.CommandText);
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
                    if (conn != null)
                    {
                        conn.Close();
                        // rdr.Close();
                        conn.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;


        }




        public DataTable GetStudentClassFee(string grade, string medium)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass =
                    " select s.key_fld,s.name,m.code as medium,s.code as classcode,s.key_fee,g.code as grade,g.name as gradename from stuclass s " +
                    "left join grade g on s.key_grd=g.key_fld " +
                    "left join medium m on m.key_fld= s.key_med " +
                    "where m.code= @Medium and g.code= @Grade";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
                };
                cmd.Parameters.Add("@Medium", SqlDbType.VarChar).Value = medium;
                cmd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = grade;
                Console.WriteLine("SQL:" + cmd.CommandText);
                
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
                    if (conn != null)
                    {
                        conn.Close();
                        // rdr.Close();
                        conn.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tbl;
        }
    }
}