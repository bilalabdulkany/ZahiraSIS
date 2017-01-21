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

        public DataTable GetMedium()
        {
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass = "select (rtrim(code)+ '  |  '+rtrim(name)) as name,key_fld from medium";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
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


        public DataTable GetGrades()
        {
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass = "select * from grade";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
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
                string selectClass = " select g.key_fld as gfield, s.key_fld,s.name as name ,g.name as gname,s.code as scode, m.code as mcode, m.name as mname,m.key_fld as mfield from stuclass s left join grade g on g.key_fld=s.key_grd "+
 "left join medium m on m.key_fld = s.key_med "+
 "where s.status = @Type order by g.code,mcode";
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

        

        public DataTable GetClassByGrade(int grade,int medium)
        {
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass = " select g.key_fld as gfield,s.key_fld as sfield,s.name as sname ,g.name as gname,s.code as scode, m.code as mcode, m.name,m.key_fld from stuclass s left join grade g on g.key_fld=s.key_grd " +
 "left join medium m on m.key_fld = s.key_med "+
 "where s.status = 'ACT' and g.key_fld = @Grade and m.key_fld = @Medium order by g.name; ";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
            };
                cmd.Parameters.Add("@Grade", SqlDbType.Int).Value = grade;
                cmd.Parameters.Add("@Medium", SqlDbType.Int).Value = medium;

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