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
           // String _bfArrears;
            //String _curArrears;
            //String _curBfArrears;
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

                     var  _bfArrears = rdr["bfArrears"].ToString();
                    var _curArrears = rdr["curArrears"].ToString();
                    var _curBfArrears = rdr["curBfArrears"].ToString();
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

                //Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("index" + studentIndex);
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
        public DataTable getStudentIndexFromClass(string studentClass)
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
                      + "where key_class = (select key_fld from stuclass where code=@Class)"
                      + " order by admno";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = studentClass;

                //Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("*class:" + studentClass);
                //  rdr = cmd.ExecuteReader();
                tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + e.ToString());
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
         * @param key Integer for key fee
         * @param effectDate year
         * */
        public DataTable getMonthFeeRevision(int key,String effectDate)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                 string sql = "SELECT [key_fld],[key_mfee],[effdate],[amount],[key_change],[igadvpay] FROM[Zahira_SIS].[dbo].[mnthfeerev] where key_mfee=@Key and effdate >='"+effectDate+"-01-01' and effdate <= '"+effectDate+"-12-01'";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = sql
                };
                cmd.Parameters.Add("@Key", SqlDbType.Int).Value = key;
                Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("date: " + effectDate);
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

        /**
       * Get a bean of the student details when the index is given.
       **/
        public StudentBean getStudentInfoFromIndex(String index)
        {
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            StudentBean bean = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql =
                    "SELECT [key_fld],[active],[enamfcnsn],[mfeecnsn],[admno],[name],[dob],[address],[registerno],[bloodgr],[comments],[prntname],[prntphone],[prntemail],[key_class],[bfarrears],[curarrears],[key_change],[curbfarres],[admon],[arrearsfrm],[arrearsto] FROM dbo.student where admno = @Index";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Index", SqlDbType.VarChar).Value = index;

                //Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("index:" + index);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var keyFld = rdr.GetInt32(0); //["key_fld"]+"";
                        var active = rdr["active"];
                        var enamfcnsn = rdr.GetInt32(2);
                        var mfeecnsn = rdr.GetDecimal(3);
                        var admno = (string) rdr["admno"];
                        var name = rdr.GetString(5);
                        var dob = rdr.GetDateTime(6);//.GetDateTime(6);//6
                        var address = rdr.GetString(7);
                        var registerno = (string) rdr["registerno"];
                        var bloodgr = (string) rdr["bloodgr"];//9
                        var comments = rdr.GetString(10);//10
                        var prntname = rdr.GetString(11);//(string) rdr["prntname"];//11
                        var prntphone = (string) rdr["prntphone"];
                        var prntemail = (string) rdr["prntemail"];
                        var key_class = (int) rdr.GetInt32(14);//14
                        var bfarrears = (double) rdr.GetDecimal(15);
                        var curarrears = (double) rdr.GetDecimal(16);
                        var key_change = (int) rdr.GetInt32(17);
                        var curbfarres = (double) rdr.GetDecimal(18);
                        var admon = (DateTime)rdr.GetDateTime(19);
                        var arrearsfrm = (DateTime)rdr.GetDateTime(20);
                        var  arrearsto = (DateTime)rdr.GetDateTime(21);

                        bean = new StudentBean((int) keyFld, (int) active, enamfcnsn, (double)mfeecnsn, admno, name, dob,
                            address, registerno, bloodgr, comments, prntname, prntphone, prntemail, key_class, bfarrears,
                            curarrears, key_change, curbfarres, admon, arrearsfrm, arrearsto);
                    }
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
                    rdr.Close();
                    conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return bean;

        }
        public StudentArrearsBean getStudentArrearsByDate(string studentClass, string fromDate, string toDate)
        {
        //TODO should return a datatable containing all the students' arrears info, till date, and the sum of the arrears.
        
            SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable tbl = null;
            StudentArrearsBean arrearsBean = null;
            StudentArrearsBean cumArrearsBean = null;
            try
            {
            
                conn = new SqlConnection(connectionString);
                conn.Open();
                var classwiseStudents = this.getStudentIndexFromClass(studentClass.Trim());
                classwiseStudents.Columns.Add("Arrears");
                classwiseStudents.Columns.Add("PaidTill");
                int stlen = classwiseStudents.Rows.Count;
                Console.WriteLine("Total students: "+stlen);
                double cumArrears = 0;
                for (int i = 0; i < stlen; i++)
                {
                    string admno = classwiseStudents.Rows[i]["admno"].ToString().Trim();
                    try
                    {
                        arrearsBean = this.getStudentArrearsInfo(admno, studentClass, false);
                        classwiseStudents.Rows[i]["Arrears"] = arrearsBean.curArrears;
                        classwiseStudents.Rows[i]["PaidTill"] = arrearsBean.paidTill.ToString("dd-MMM-yyyy");
                        cumArrears = cumArrears + double.Parse(arrearsBean.curArrears);
                        //Call fillTable. Then add all the fees to a bean.
                        //Its better if FillTable returns a bean consisting of student's arrears.
                        Console.WriteLine("cum. arrears: " + cumArrears);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("e:"+ex);
                     
                    }

                }
                cumArrearsBean=new StudentArrearsBean();
                cumArrearsBean.stPaidData = classwiseStudents;
                cumArrearsBean.curArrears = cumArrears+"";

                string sql = "";


               /* String sql = "SELECT key_fld, active, mfeecnsn, admno, name, address, registerno,prntname,  key_class, bfarrears, curarrears, key_change, curbfarres, CONVERT(VARCHAR(11), admon, 106) as admon, "
                     + "CONVERT(VARCHAR(11), arrearsfrm, 106) as arrearsfrm, CONVERT(VARCHAR(11), arrearsto, 106) as arrearsto FROM dbo.student "
                      + "where key_class = @Class and arrearsfrm >= @From and arrearsto <= @To"
                      + " order by arrearsfrm asc";
    */            
               /* cmd = new SqlCommand();
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
               
                tbl = classwiseStudents;*/

            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
            }
            finally
            {
                try
                {
                    //conn.Close();
                    // rdr.Close();
                    //conn.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return cumArrearsBean;

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

        /**
         * Fill the data table from the admission number,
         * then fill the latest fee payments on the textboxes.
         **/
        public StudentArrearsBean getStudentArrearsInfo(string admNo, string classCode,bool guessClass)
        {
            /**
             *  only current year and paid till grades are known.
             **/
            StudentArrearsBean arrearsBean = null;
            Double feesArrears = 0;
            DataTable dt = null;
           Dictionary<int,string> arrearsMap=new Dictionary<int,string>();

            try
            {
                arrearsBean = new StudentArrearsBean();

                dt = new DataTable();
                dt = this.getStudentArrearsByIndex(admNo);
                arrearsBean.stPaidData = dt;
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                double feeRate = 0;
                DateTime paidTill = (DateTime)lastRow["payto"];
                arrearsBean.paidTill = paidTill;
                DateTime paidTo = paidTill;
                DateTime todayDate = DateTime.Now;
                int dateDifference = todayDate.Year - paidTo.Year;
                int countYear = 0;
                char guessedClass = classCode[classCode.Length - 2];
                int grade = int.Parse(classCode[classCode.Length - 3] + ""); //FIXME 2 or 3
                Console.WriteLine("Current grade:" + grade + " adding:" + (countYear - 1));
                Console.WriteLine("guessed class: " + guessedClass);
                
                for (int i = todayDate.Year; i >= paidTill.Year; i--)
                {
                    if (paidTill.Year == 1899)
                    {
                        Console.WriteLine("data is not properly recorded");
                        feesArrears = 0;
                        break;
                    }
                    countYear++;
                    Console.WriteLine("today:" + i);
                    Console.WriteLine("till:" + paidTill.Year);
                    Console.WriteLine("class code:" + classCode + " length:" + classCode.Trim().Length);
                    
                    //Get the grade from the students records. check primary or secondary or senior.
                    if (i == paidTill.Year) //i == paidTill.Year&&
                    {
                        //If for current years' arrears.
                        //if paid till is not current year??
                        if (paidTill.Year == todayDate.Year)
                        {
                            Console.WriteLine("calculating fee arrears for the current years'" +
                                              " Arrears: " + feesArrears);
                            int paidMonth = paidTill.Month + 1;
                            if (paidMonth > 12)
                            {
                                paidMonth = paidMonth % 12;
                            }
                            int thisMonth = DateTime.Now.Month;
                            int monthDiff = (thisMonth - paidMonth);
                            if (monthDiff < 0)
                            {
                                monthDiff = -(monthDiff);
                            }
                            feeRate = Double.Parse(lastRow["mfeerate"] + "");
                            feesArrears = feeRate * ((thisMonth - paidMonth)) + feesArrears;
                            arrearsMap[i] = feeRate+"|"+ (thisMonth - paidMonth) + "|"+feeRate*monthDiff;
                        }
                        else
                        {
                            int paidMonth1 = paidTill.Month;
                            if (paidMonth1 != 12 && paidMonth1 < 12)
                            {
                                
                                paidMonth1 = 12 - paidMonth1;
                                feeRate = Double.Parse(lastRow["mfeerate"] + "");
                                Console.WriteLine("arrears before:" + feesArrears);
                                feesArrears = feeRate * paidMonth1 + feesArrears;
                                Console.WriteLine("paid till month: " + paidMonth1);
                                Console.WriteLine("fee Rate:"+feeRate);
                                Console.WriteLine("arrears:"+feesArrears);
                                arrearsMap[i] = feeRate + "|" + paidMonth1 + "|" + feeRate*paidMonth1;
                            }
                        }
                        Console.WriteLine("fee is not paid fully for the year " + i + ": " + feesArrears);

                    }
                    else
                    {
                        //If for other years' arrears.
                        //Check the medium and then guess the key_fee.
                        Console.WriteLine("Calculating fee for other years.");
                        //int feecode = dao.getStudentClasses(keyClass).Key_fee;

                        //get the grades in order and check if primary, secondary or senior.
                        //calculate the rates with respect to the effective year fee. 
                        //Also check student concessions.  
                        if (guessClass)
                        {
                            string input =
                                Prompt.ShowDialog(
                                    "ClassCode: " + classCode + " Years: " + countYear + "- grade:" + grade,
                                    "Year: " + i);
                            feeRate =
                                double.Parse(
                                    this.getMonthFeeRevision(int.Parse(input.Trim()), i + "").Rows[0]["amount"].ToString
                                        ());

                            Console.WriteLine(input.Trim() + " with arrears: " + feesArrears + " feeRate:" + feeRate);
                        }
                        else
                        {
                            int yearsToReduce = 0;
                            int key_fee = 0;
                            if (countYear != 1)
                            {
                                yearsToReduce = todayDate.Year - i;
                            }
                            //i is this year but the students class is based on this year so reduce one year.
                            key_fee = this.guessClassAndFee(classCode, countYear,yearsToReduce);
                            feeRate =
                                double.Parse(
                                    this.getMonthFeeRevision(key_fee, i + "").Rows[0]["amount"].ToString
                                        ());
                           
                        }
                        
                        if (i == todayDate.Year)
                        {
                            //i == todayDate.Year and i!=paidTill.Year-- but there are arrears
                            Console.WriteLine("Calculating fee for this year:"+i);
                        
                            int thisMonth = DateTime.Now.Month;
                            
                            int monthDiff = (thisMonth - 1);
                            if (monthDiff < 0)
                            {
                                monthDiff = -(monthDiff);
                            }
                            Console.WriteLine("month diff: "+monthDiff);
                            Console.WriteLine("fee Rate:" + feeRate);
                            Console.WriteLine("arrears:" + feesArrears);
                            feesArrears = feeRate * monthDiff + feesArrears;
                            Console.WriteLine("arrears:"+feesArrears);
                            arrearsMap[i] = feeRate + "|" + monthDiff + "|" + feeRate*monthDiff;
                        }
                        else
                        {
                            feesArrears = feeRate * 12 + feesArrears;
                            arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate*12;
                        }
                        Console.WriteLine("Fee rate: " + feeRate + " Arrears: " + feesArrears);
                    }
                }
                paidTill = paidTill.AddMonths(1);
                if (paidTill.Year > DateTime.Now.Year || feesArrears < 0)
                {
                    Console.WriteLine("resetting to 0");
                    if (dateDifference == 0)
                    {
                        feesArrears = 0;
                    }
                }
                Console.WriteLine("Date Diff:" + dateDifference + " arrears: " + feesArrears);
                arrearsBean.curArrears = feesArrears + "";
                arrearsBean.arrearsMap = arrearsMap;
                foreach (KeyValuePair<int, string> kvp in arrearsMap)
                {
                    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("error: " + e1);
            }
            return arrearsBean;
        }

        /*TODO guess the fee rate given the current class
         */

        private int guessClassAndFee(string classCode, int countYear, int yearsToReduce)
        {
            //TODO check if the grade should be reversed or not - addition or subtraction.
            /*
key_fld	code    	name
6	    1         	Praimary 2 -5                                     
7	    2         	Junior 6-8                                        
8	    3         	Senior 9-11                                       
9	    4         	English (2-5)                                     
14	    5         	A / L (Tam & Sin)                                 
15	    0000      	Left Student Fees                                 
16	    1ST       	Primary 1                                         
17	    6         	Sinhala/ English                                  
18	    1E        	1 English Primary                                 
24	    E2        	6-13  English                                     
25	    0001E     	0001E Primary                                     
26	    0001S     	0001S Primary                                     
27	    0001T     	0001T Primary                                     
             
             */
            ClassDAO clsDao = new ClassDAO();
            char guessedClass = classCode[classCode.Length - 2];
            string grade = classCode.Substring(0, classCode.Length - 2);
            if (!grade.Equals("1"))
            {
                int reduceYear = int.Parse(grade) - yearsToReduce;
            
            grade = reduceYear.ToString();
        }
        if (

        grade.Length == 1)
            {
                grade = "0"+grade;
                
            }
            Console.WriteLine("grade:" + grade+" medium:"+guessedClass);
            int key_fee = (int)clsDao.GetStudentClassFee( grade, guessedClass.ToString()).Rows[0]["key_fee"];
            Console.WriteLine("***grade: "+grade);
            Console.WriteLine("***Current grade:" + grade + " adding:" + (countYear - 1));

            Console.WriteLine("***key_fee: " + key_fee);

            return key_fee;
        }


    }
}
