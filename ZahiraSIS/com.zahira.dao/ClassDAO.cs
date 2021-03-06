﻿using System;
using System.Data;
using System.Data.SqlClient;
using ZahiraSIS.com.zahira.bean;

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
                //Console.WriteLine("SQL:" + cmd.CommandText);
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
              //  Console.WriteLine("SQL:" + cmd.CommandText);
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
                //Console.WriteLine("SQL:" + cmd.CommandText);
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
                string selectClass = " select g.key_fld as gfield, s.key_fld,(rtrim(s.name)+(' - ')+ s.code) as name,g.name as gname,s.code as scode, m.code as mcode, m.name as mname,m.key_fld as mfield from stuclass s left join grade g on g.key_fld=s.key_grd " +
 "left join medium m on m.key_fld = s.key_med "+
 "where s.status = @Type order by g.code,mcode";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
                };
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;

            //    Console.WriteLine("SQL:" + cmd.CommandText);
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

                //Console.WriteLine("SQL:" + cmd.CommandText);
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
               // Console.WriteLine("SQL:" + cmd.CommandText);
                
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


        public DataTable GetAllActiveClasses()
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass =
                    "select s.key_fld,s.name,m.code as medium,s.code as classcode,s.key_fee,g.code as grade,g.name as gradename from stuclass s "+
                    "left join grade g on s.key_grd = g.key_fld "+
                    "left join  medium m on m.key_fld = s.key_med "+
                    "where s.status = 'ACT'";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
                };
                
                // Console.WriteLine("SQL:" + cmd.CommandText);

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

        public StuclassBean getStuClass(int stuClass)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;
            StuclassBean StuClassBean = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string selectClass =
                    "select * from stuclass  where key_field=@Key and status = @Status";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = selectClass
                };
                cmd.Parameters.AddWithValue("@Key", stuClass);
                cmd.Parameters.AddWithValue("@Status", "ACT");

                // Console.WriteLine("SQL:" + cmd.CommandText);

                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    int keyfield = int.Parse(rdr["key_fld"].ToString());
                    int keygrade= int.Parse(rdr["key_grd"].ToString());
                    int keymed= int.Parse(rdr["key_med"].ToString());
                    string name = rdr["name"].ToString();
                    string code = rdr["code"].ToString();
                    int keytea = int.Parse(rdr["key_tea"].ToString());
                    int keyfee = int.Parse(rdr["key_fee"].ToString());
                    int keychange = int.Parse(rdr["key_change"].ToString());
                    StuClassBean = new StuclassBean(keyfield,keygrade,keymed,name,code,keytea,keyfee,keychange);
                                       

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
            return StuClassBean; ;

        }

        public Boolean CheckALClass(int keyClass)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;            
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = " select key_fld from stuclass where status=@Status and (name like '%12%' or name like '%13%') and key_fld=@key";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = query
                };
                cmd.Parameters.AddWithValue("@Status", "ACT");
                cmd.Parameters.AddWithValue("@key",keyClass);
                // Console.WriteLine("SQL:" + cmd.CommandText);

                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    return true;
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
                    if (conn != null)
                    {
                        conn.Close();
                        rdr.Close();
                        conn.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return false;
        }
        }
}