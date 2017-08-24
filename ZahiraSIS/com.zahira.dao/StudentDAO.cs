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
        public readonly String COLUMN_PAIDTILL= "PaidTill";
        public readonly String COLUMN_TOTAL_PAID= "Total Fee paid this year";
        public readonly String COLUMN_ARREARS = "Arrears";

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

                    var _bfArrears = rdr["bfArrears"].ToString();
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
                String sql = "select trnno,trndate,paid,payfrom,payto,mfeerate,totarrears,arrearsfrm,arrearsto,s.code as key_class from mnthfeepay m "
                    +"left join stuclass s on s.key_fld=m.key_class "+
                    "where m.key_stu =(select key_fld from student where admno = @Index) order by m.trndate";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Index", SqlDbType.VarChar).Value = studentIndex;

                //Console.WriteLine("SQL:" + cmd.CommandText);
                //Console.WriteLine("index" + studentIndex);
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
               // Console.WriteLine("*class:" + studentClass);
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
        public DataTable getMonthFeeRevision(int key, int effectYear)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            DataTable tbl = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT [key_fld],[key_mfee],[effdate],[amount],[key_change],[igadvpay] FROM[Zahira_SIS].[dbo].[mnthfeerev] where key_mfee=@Key and effdate >='" + effectYear + "-01-01' and effdate <= '" + effectYear + "-12-01'";
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = sql
                };
                cmd.Parameters.Add("@Key", SqlDbType.Int).Value = key;
                //Console.WriteLine("SQL:" + cmd.CommandText);
                //Console.WriteLine("date: " + effectYear);
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
               // String sql =
                 //   "SELECT [key_fld],[active],[enamfcnsn],[mfeecnsn],[admno],[name],[dob],[address],[registerno],[bloodgr],[comments],[prntname],[prntphone],[prntemail],[key_class],[bfarrears],[curarrears],[key_change],[curbfarres],[admon],[arrearsfrm],[arrearsto] FROM dbo.student where admno = @Index";

                String sql = "SELECT s.[key_fld],[active], [enamfcnsn],[mfeecnsn],[admno],s.[name],[dob],[address],[registerno],[bloodgr],[comments],"
+ "[prntname],[prntphone],[prntemail],[key_class],[bfarrears],[curarrears],s.[key_change],[curbfarres],"
+ "[admon],[arrearsfrm],[arrearsto],m.name as medium,sc.code as classcode FROM dbo.student s, dbo.medium m, dbo.stuclass sc where admno =  @Index and s.key_class= sc.key_fld and m.key_fld= sc.key_med";

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Index", SqlDbType.VarChar).Value = index;

                //Console.WriteLine("SQL:" + cmd.CommandText);
               // Console.WriteLine("index:" + index);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var keyFld = rdr.GetInt32(0); //["key_fld"]+"";
                        var active = rdr["active"];
                        var enamfcnsn = rdr.GetInt32(2);
                        var mfeecnsn = rdr.GetDecimal(3);
                        var admno = (string)rdr["admno"];
                        var name = rdr.GetString(5);
                        var dob = rdr.GetDateTime(6);//.GetDateTime(6);//6
                        var address = rdr.GetString(7);
                        var registerno = (string)rdr["registerno"];
                        var bloodgr = (string)rdr["bloodgr"];//9
                        var comments = rdr.GetString(10);//10
                        var prntname = rdr.GetString(11);//(string) rdr["prntname"];//11
                        var prntphone = (string)rdr["prntphone"];
                        var prntemail = (string)rdr["prntemail"];
                        var key_class = (int)rdr.GetInt32(14);//14
                        var bfarrears = (double)rdr.GetDecimal(15);
                        var curarrears = (double)rdr.GetDecimal(16);
                        var key_change = (int)rdr.GetInt32(17);
                        var curbfarres = (double)rdr.GetDecimal(18);
                        var admon = (DateTime)rdr.GetDateTime(19);
                        var arrearsfrm = (DateTime)rdr.GetDateTime(20);
                        var arrearsto = (DateTime)rdr.GetDateTime(21);
                        var medium = (string)rdr["medium"];
                        var classcode= (string)rdr["classcode"];

                        bean = new StudentBean((int)keyFld, (int)active, enamfcnsn, (double)mfeecnsn, admno, name, dob,
                            address, registerno, bloodgr, comments, prntname, prntphone, prntemail, key_class, bfarrears,
                            curarrears, key_change, curbfarres, admon, arrearsfrm, arrearsto);
                        bean.Medium = medium;
                        bean.ClassCode = classcode;
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
        public StudentArrearsBean getStudentArrearsByDatePerClass(string studentClass, string fromDate, string toDate,bool logging)
        {
            StudentArrearsBean arrearsBean = null;
            StudentArrearsBean cumArrearsBean = null;
            try
            {
                //conn = new SqlConnection(connectionString);
                //conn.Open();
                var classwiseStudents = this.getStudentIndexFromClass(studentClass.Trim());
                classwiseStudents.Columns.Add(COLUMN_ARREARS);
                classwiseStudents.Columns.Add(COLUMN_PAIDTILL);
                classwiseStudents.Columns.Add(COLUMN_TOTAL_PAID);
                int stlen = classwiseStudents.Rows.Count;
                if(logging)
                Console.WriteLine("Total students: " + stlen);
                double cumArrears = 0;
                double totalPaid = 0;
                for (int i = 0; i < stlen; i++)
                {
                    string admno = classwiseStudents.Rows[i]["admno"].ToString().Trim();
                    try
                    {
                        arrearsBean = this.NewForwardBalance(admno, studentClass, DateTime.Parse(toDate), false,false);
                        if (arrearsBean != null)
                        {
                            classwiseStudents.Rows[i][COLUMN_ARREARS] = arrearsBean.curArrears;
                            classwiseStudents.Rows[i][COLUMN_TOTAL_PAID] = arrearsBean.feePaidForTheYear;
                            classwiseStudents.Rows[i][COLUMN_PAIDTILL] = arrearsBean.paidTill.ToString("dd-MMM-yyyy");

                            cumArrears = cumArrears + double.Parse(arrearsBean.curArrears);
                            totalPaid =totalPaid+arrearsBean.feePaidForTheYear;
                            //Call fillTable. Then add all the fees to a bean.
                            //Its better if FillTable returns a bean consisting of student's arrears.
                            if (logging) { Console.WriteLine("cum. arrears: " + cumArrears); }
                        }
                        else {
                            //Student on fee concession.
                            classwiseStudents.Rows[i][COLUMN_ARREARS] = "0";
                            classwiseStudents.Rows[i][COLUMN_PAIDTILL] = "0";
                            classwiseStudents.Rows[i][COLUMN_TOTAL_PAID] = "0";
                            cumArrears = 0;
                            totalPaid = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("e:" + ex);

                    }

                }//end of for loop
                cumArrearsBean = new StudentArrearsBean();
                cumArrearsBean.stPaidData = classwiseStudents;
                cumArrearsBean.curArrears = cumArrears + "";
                cumArrearsBean.feePaidForTheYear = totalPaid;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("exception" + e.ToString());
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
               // Console.WriteLine(cmd.CommandText);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                //string key_fld = "";
                if (rdr.HasRows)
                {
                    bean = new StuclassBean();
                    bean.Key_fld = int.Parse(rdr["key_fld"] + "");
                    bean.Key_grd = (int)rdr["key_grd"];
                    bean.Key_med = (int)rdr["key_med"];
                    bean.Name = rdr["name"] + "";
                    bean.Code = rdr["code"] + "";
                    bean.Classcode = rdr["classcode"] + "";
                    bean.Key_tea = (int)rdr["key_tea"];
                    bean.Key_fee = (int)rdr["key_fee"];
                    bean.Key_change = (int)rdr["key_change"];            
                    
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

        /**
         * Fill the data table from the admission number,
         * then fill the latest fee payments on the textboxes.
         * 
         * @param admNo string
         * @param classCode string 
         * @param guessClass bool
         **/
        public StudentArrearsBean getStudentArrearsInfo(string admNo, string classCode, DateTime? asAt, bool guessClass)
        {
            //TODO need to add as-at months-year
            /**
             *  only current year and paid till grades are known.
             **/
            StudentArrearsBean arrearsBean = null;
            Double feesArrears = 0;
            DataTable dt = null;
            Dictionary<int, string> arrearsMap = new Dictionary<int, string>();
            admNo = admNo.Trim();
            classCode = classCode.Trim();
            try
            {
                arrearsBean = new StudentArrearsBean();
                dt = new DataTable();
                
                

                dt = getStudentArrearsByIndex(admNo);
                arrearsBean.stPaidData = dt;
                if (CheckStudentConcessions(admNo, classCode) == true)
                {
                    arrearsBean.curArrears = "0.00";
                    arrearsBean.studentConcession = true;
                    return arrearsBean;
                }
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                double feeRate = 0;
                DateTime paidTill = (DateTime)lastRow["payto"];
                arrearsBean.paidTill = paidTill;
                DateTime paidTo = paidTill;
                DateTime todayDate = DateTime.Now;
                if (asAt.HasValue)
                {
                    todayDate = (DateTime)asAt;
                }

                int dateDifference = todayDate.Year - paidTo.Year;
                int countYear = 0;
                string guessedClass = GetMedium(classCode.Trim());// classCode[classCode.Length - 2];
                int grade = int.Parse(classCode[classCode.Length - 3] + ""); //FIXME 2 or 3
                Console.WriteLine("Current grade:" + grade + " adding:" + (countYear - 1));
                Console.WriteLine("guessed class: " + guessedClass);

                for (int i = todayDate.Year; i >= paidTill.Year; i--)
                {
                    /**Loop from the current year to the paid till year and find out the arrears amount.
                     */
                    if (paidTill.Year == 1899)
                    {
                        //the data is not recorded properly due to corruption.
                        Console.WriteLine("data is not properly recorded");
                        feesArrears = 0;
                        break;
                    }
                    countYear++;
                    Console.WriteLine("today:" + i);
                    Console.WriteLine("till:" + paidTill.Year);
                    Console.WriteLine("class code:" + classCode + " length:" + classCode.Trim().Length);

                    if (i == paidTill.Year)
                    {//Paid till year is in the current loop. 

                        //If for current years' arrears.
                        if (paidTill.Year == todayDate.Year)
                        {
                            Console.WriteLine("calculating fee arrears for the current years'" +
                                              " Arrears: " + feesArrears);
                            int paidMonth = paidTill.Month + 1;
                            if (paidMonth > 12)
                            {
                                paidMonth = paidMonth % 12;
                            }
                            int thisMonth = todayDate.Month + 1;
                            int monthDiff = (thisMonth - paidMonth);
                            if (monthDiff < 0)
                            {
                                monthDiff = -(monthDiff);
                            }
                            feeRate = Double.Parse(lastRow["mfeerate"] + "");
                            feesArrears = feeRate * ((thisMonth - paidMonth)) + feesArrears;
                            arrearsMap[i] = feeRate + "|" + (thisMonth - paidMonth) + "|" + feeRate * monthDiff;
                        }
                        else
                        { // paid till year is not the current year.
                            int paidMonth1 = paidTill.Month;
                            if (paidMonth1 != 12 && paidMonth1 < 12)
                            {
                                //calculate the remaining months in this year to be paid.   
                                paidMonth1 = 12 - paidMonth1;
                                feeRate = Double.Parse(lastRow["mfeerate"] + "");
                                Console.WriteLine("arrears before:" + feesArrears);
                                feesArrears = feeRate * paidMonth1 + feesArrears;
                                Console.WriteLine("paid till month: " + paidMonth1);
                                Console.WriteLine("fee Rate:" + feeRate);
                                Console.WriteLine("arrears:" + feesArrears);
                                arrearsMap[i] = feeRate + "|" + paidMonth1 + "|" + feeRate * paidMonth1;
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
                                    this.getMonthFeeRevision(int.Parse(input.Trim()), i).Rows[0]["amount"].ToString
                                        ());

                            Console.WriteLine(input.Trim() + " with arrears: " + feesArrears + " feeRate:" + feeRate);
                        }
                        else
                        {
                            int yearsToReduce = 0;
                            //int key_fee = 0;
                            if (countYear != 1)
                            {
                                yearsToReduce = todayDate.Year - i;
                            }
                            //i is this year but the students class is based on this year so reduce one year.
                            feeRate = this.guessClassAndFee(classCode, todayDate.Year, i);
                           

                        }

                        if (i == todayDate.Year)
                        {
                            //i == todayDate.Year and i!=paidTill.Year-- but there are arrears
                            Console.WriteLine("Calculating fee for this year:" + i);

                            int thisMonth = todayDate.Month;

                            int monthDiff = (thisMonth - 1) + 1;
                            if (monthDiff < 0)
                            {
                                monthDiff = -(monthDiff);
                            }
                            Console.WriteLine("month diff: " + monthDiff);
                            Console.WriteLine("fee Rate:" + feeRate);
                            Console.WriteLine("arrears:" + feesArrears);
                            feesArrears = feeRate * monthDiff + feesArrears;
                            Console.WriteLine("arrears:" + feesArrears);
                            arrearsMap[i] = feeRate + "|" + monthDiff + "|" + feeRate * monthDiff;
                        }
                        else
                        {
                            feesArrears = feeRate * 12 + feesArrears;
                            arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate * 12;
                        }
                        Console.WriteLine("Fee rate: " + feeRate + " Arrears: " + feesArrears);
                    }
                }
                paidTill = paidTill.AddMonths(1);
                if (paidTill.Year > todayDate.Year || feesArrears < 0)
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

        public bool CheckStudentConcessions(string admno, string classCode)
        {
            //TODO
            //--if paypct is 100, fee is getting paid in total for the year.
            //--someone is paying the fee in full and check the payment from the mnthfeepay table.
            //--if entry is not there, then full arrears has to be paid.
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "select top 1 * from stuconcessionrev where key_stu in ("+
"select key_fld from student where admno = @Admno) order by key_fld desc";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;                
                cmd.Parameters.Add("@Admno", SqlDbType.VarChar).Value = admno;

               // Console.WriteLine(cmd.CommandText);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                //string key_fld = "";
                if (rdr.HasRows)
                {
                    Console.WriteLine((decimal)rdr["paypct"]);
                    if ((decimal) rdr["paypct"]==0) { 
                    return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public double guessClassAndFee(string classCode, int currentYear,int arrearsYear)
        {
            ClassDAO clsDao = new ClassDAO();
            int yearsToReduce = currentYear - arrearsYear;
            //Suppose arrears is paid upto next year, yearsToReduce becomes negative. In that case change signs.
            if (yearsToReduce < 0) yearsToReduce = 0;//(-yearsToReduce);
            double feeRate = 0;
            classCode = classCode.Trim();
            string guessedClass = this.GetMedium(classCode); //classCode[classCode.Length - 2];
            string grade = classCode.Substring(0, classCode.Length - 2);
            if (!grade.Equals("1"))
            {
                //If the grade is not 1
                int reduceYear = int.Parse(grade) - yearsToReduce;

                grade = reduceYear.ToString();
            }
            if (grade.Length == 1)
            {
                grade = "0" + grade;
            }
            //Console.WriteLine("grade:" + grade + " medium:" + guessedClass);
            int key_fee = (int)clsDao.GetStudentClassFee(grade, guessedClass.ToString()).Rows[0]["key_fee"];
            //Console.WriteLine("***grade: " + grade);
            //Console.WriteLine("***key_fee: " + key_fee);
            int thisYear = DateTime.Now.Year;
            if (arrearsYear > thisYear) {
                arrearsYear = thisYear;
            }
            if (arrearsYear > currentYear) arrearsYear = currentYear;
            feeRate = double.Parse(this.getMonthFeeRevision(key_fee, arrearsYear).Rows[0]["amount"].ToString
                                    ());
            return feeRate;
        }

        private string GetMedium(string classCode) {
            string medium = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                String sql = "select m.code from stuclass s left join medium m on m.key_fld = s.key_med where s.code = @Class";
  
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Class", SqlDbType.VarChar).Value = classCode;

              //  Console.WriteLine(cmd.CommandText);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                //string key_fld = "";
                if (rdr.HasRows)
                {
                    medium = rdr["code"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return medium;
        }


        public StudentArrearsBean NewForwardBalance(string admNo, string classCode, DateTime? asAt, bool guessClass,bool logging) {
            /**
             * TODO
             * Check Student table for the current arrears and 
             * tally with the mnthfeepay table.
             * Student table supersedes mnthfeepay table!
                         * 
             * 
             */

            StudentArrearsBean arrearsBean = null;
            Double feesArrears = 0,  feeRate=0 ;
            DataTable dt = null;
            Dictionary<int, string> arrearsMap = new Dictionary<int, string>();
            admNo = admNo.Trim();
            classCode = classCode.Trim();
            Boolean takeFromFeePaid = false;
            double totalArrearsFromStudent = 0;
            double totalPaid = 0;
            double totalPaidinMnthFeeTable = 0;
            double totalPaidTillDate = 0;
            double mfeerate = 0;
            DateTime todayDate = DateTime.Now;
            Boolean surplusPaid = false;
            Boolean paidLess = false;
            Boolean IsMonthFeeNull = false;
            Boolean IsFeePaidThisYear = false;
            DataRow lastRowMnthFee = null;

            try
            {
                arrearsBean = new StudentArrearsBean();
                dt = new DataTable();
                dt = getStudentArrearsByIndex(admNo);
                arrearsBean.stPaidData = dt;

                StudentBean bean = getStudentInfoFromIndex(admNo);
                totalArrearsFromStudent = bean.Curarrears;
                DateTime arrearsToFromStudent = bean.Arrearsto;
                //This below statement is for wrongly added student info!
                DateTime arrearsFromFromStudent = bean.Arrearsfrm;

               //First check arrears info from student table.
                if (logging)
                {
                    Console.WriteLine("net arrears in Student: " + totalArrearsFromStudent);

                    Console.WriteLine("arrears to date in student: " + arrearsToFromStudent.ToString("dd-MMM-yyyy"));
                }
                //Check student concessions
                if (CheckStudentConcessions(admNo, classCode) == true)
                {
                    arrearsBean.curArrears = totalArrearsFromStudent+"";
                    arrearsBean.studentConcession = true;
                    return arrearsBean;
                }
                DateTime arrearsTo = arrearsFromFromStudent;
                DateTime paidTo = arrearsToFromStudent;
                                if (asAt.HasValue)
                {
                    todayDate = (DateTime)asAt;
                }
                //Corrections on student table.
                if (arrearsFromFromStudent > arrearsToFromStudent)
                {
                    arrearsToFromStudent = arrearsFromFromStudent;
                }
                try
                {
                    lastRowMnthFee = dt.Rows[dt.Rows.Count - 1];

                    arrearsTo = (DateTime)lastRowMnthFee["arrearsto"];
                    DateTime arrearsFrom= (DateTime)lastRowMnthFee["arrearsfrm"];               
                    
                    double totalArrears = Double.Parse(lastRowMnthFee["totarrears"].ToString());
                    mfeerate = Double.Parse(lastRowMnthFee["mfeerate"].ToString());//TODO check null
                    totalPaid = GetTotalFeePaidForTheYear(todayDate.Year, admNo);//Double.Parse(lastRowMnthFee["paid"].ToString());
                    totalPaidTillDate = GetFeePaidForTheYear(todayDate.Year, admNo, todayDate);
                    //TODO what about check payment by date?
                    totalPaidinMnthFeeTable =Double.Parse(lastRowMnthFee["paid"].ToString());//TODO check null
                    if (totalPaid > 0) IsFeePaidThisYear = true;
                    double netArrears = totalArrears - totalPaid;
                    if (logging)
                    {
                        Console.WriteLine("arrears to date in mnthfee: " + arrearsTo.ToString("dd-MMM-yyyy"));
                        Console.WriteLine("net arrears in mnthfee: " + netArrears);
                    }
                        arrearsBean.paidTill = (DateTime)lastRowMnthFee["payto"];
                    paidTo = arrearsTo;
                    //Corrections on mnthfeetable
                    if (arrearsFrom > arrearsTo) arrearsTo = arrearsFrom;                
                    
                    if (arrearsBean.paidTill > arrearsToFromStudent)
                    {
                        arrearsToFromStudent = arrearsBean.paidTill;
                        arrearsTo = arrearsToFromStudent;
                        if(arrearsToFromStudent>todayDate)
                        takeFromFeePaid = true;
                    }
                    if (arrearsTo < arrearsToFromStudent) arrearsTo = arrearsToFromStudent;
                    if (arrearsBean.paidTill > todayDate)
                    { surplusPaid = true;
                        //if(totalPaid==0)
                       // totalPaid = GetFeePaidForTheYear(todayDate.Year, admNo);
                    }

                    
                    //arrearsBean.arrearsTo = (DateTime)arrearsTo;
                    
                }
                catch (Exception e) {
                Console.WriteLine("exception.. mnthfeepaytable has errors or null", e);
                    //Since mnthfeepay table has no record. Calculte arrears info from student table.

                    IsMonthFeeNull = true;

                }

                arrearsBean.arrearsTo = (DateTime)arrearsTo;
                int dateDifference = todayDate.Year - paidTo.Year;
                
                /*for loop*/
                if (arrearsToFromStudent.Year == 0) { }
                // TODO here if the fee is paid till next year or so, fee rate should be coming from  mnthfeepay
                //- this is for lower grades, where they pay excess for next year as well.
                feeRate = this.guessClassAndFee(classCode, todayDate.Year, arrearsToFromStudent.Year);

                if (logging) { Console.WriteLine("fee: " + feeRate); }

                StudentArrearsBean calculatedBean = calculateArrears(arrearsToFromStudent, todayDate, feesArrears, classCode, totalArrearsFromStudent, feeRate,logging);

                //TODO check below conditions properly
                if (!arrearsBean.paidTill.Equals(todayDate)&&arrearsBean.paidTill.Month == todayDate.Month&& arrearsBean.paidTill.Year == todayDate.Year)
                {//This checks for current day and month and paidtill field.
                    //If the fee is less,
                    //fee rate is more than the totalpaid.
                    if (totalPaid < feeRate ) {
                        paidLess = true;
                    }
                    
                }
                if ((totalPaid < feeRate * todayDate.Month))
                {//If the todayDate is different than current month, calculate
                    //till this month and determine if paid less or not.
                    paidLess = true;
                }
                //TODO what are the other scenarios, there would be paid Less boolean = true?

                double mnthFeeArrears = 0;
                if (!IsMonthFeeNull)
                {
                    if (takeFromFeePaid || surplusPaid)
                    {
                        if (totalPaid == 0 && totalPaidinMnthFeeTable != 0)
                        {
                            //This is for grade 2 students, where the student table has no fee info, but the mnthfeepay has.
                            totalPaid = totalPaidinMnthFeeTable;
                            //feeRate = mfeerate;
                        }
                        else if (totalPaid == 0)
                        {
                            //TODO since surplus paid, consider the paid Till column.
                            totalPaid = totalPaidTillDate;
                            //for 00686
                        }
                        else {
                            //for 19353 its ok. total paid is 17100 for last year. total paid
                            //19643 gets upset.
                           // totalPaid = totalPaidTillDate;
                        }
                        
                            mnthFeeArrears = (totalPaid - feeRate * todayDate.Month);
                        if (surplusPaid)
                           // if (mnthFeeArrears>=0)
                                mnthFeeArrears = (-mnthFeeArrears);

                        calculatedBean.curArrears = mnthFeeArrears.ToString();
                    }
                  
                     if (paidLess&&IsFeePaidThisYear)
                    {
                        mnthFeeArrears = feeRate * todayDate.Month - totalPaid;
                        calculatedBean.curArrears = mnthFeeArrears.ToString();
                    }
                }
                else {
                    //no record in the monthfeepaid table, and feeArrears is 0 in student table.
                    if (arrearsTo.Year > todayDate.Year) {
                        feesArrears = -(feeRate * 12+feesArrears);
                        feesArrears= Double.Parse(calculatedBean.curArrears)+feesArrears;
                        calculatedBean.curArrears = feesArrears.ToString();
                    }
                }
                
                // calculatedBean = calculateArrears(arrearsTo, todayDate, feesArrears, classCode, totalArrearsFromStudent, feeRate);

                arrearsTo = arrearsTo.AddMonths(1);
                    if(!IsMonthFeeNull)
                    feesArrears = Double.Parse(calculatedBean.curArrears);
                    if (arrearsTo.Year > todayDate.Year || feesArrears < 0)
                    {
                    //negatives should be omitted here, and taken into another column
         //               Console.WriteLine("resetting to 0");
                        if (dateDifference == 0)
                        {
                            feesArrears = 0;
                        }
                    }
                    if(logging)
                    Console.WriteLine("Date Diff:" + dateDifference + " arrears: " + feesArrears);
                    arrearsBean.curArrears = calculatedBean.curArrears;//feesArrears + "";                  
                    arrearsBean.feePaidForTheYear = totalPaid;//GetFeePaidForTheYear(todayDate.Year,admNo, todayDate);
                    
                //Put all the fees to arrears map
                if (arrearsBean.paidTill != null&&lastRowMnthFee["key_class"]!=null) {
                  //  int keyClass = int.Parse(lastRowMnthFee["key_class"].ToString());
                    //String code=getStudentClasses(keyClass).Code;
                    arrearsMap.Clear();
                    for (int year = arrearsBean.paidTill.Year; year <= todayDate.Year; year++)
                    {
                        double FeeRate = guessClassAndFee(classCode, todayDate.Year, year);
                        arrearsMap[year] = "Arrears Year: "+year + " | Rate: " + FeeRate;
                        feeRate = FeeRate;
                    }

                   // calculatedBean.arrearsMap = arrearsMap;
                }
                arrearsBean.arrearsMap = arrearsMap;
                arrearsBean.feerate = feeRate;
                if (logging)
                {
                    foreach (KeyValuePair<int, string> kvp in arrearsMap)
                    {
                        //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }
                }
                
              
            }
            catch (Exception e1)
            {
                Console.WriteLine("error: ", e1);
            }
            return arrearsBean;
        }


        private StudentArrearsBean calculateArrears(DateTime arrearsTo,DateTime todayDate,double feesArrears,string classCode,double netArrears, double feeRate,bool logging) {
            StudentArrearsBean bean = new StudentArrearsBean();
            int countYear = 0;
            //double feeRate=0;
            Dictionary<int, string> arrearsMap = new Dictionary<int, string>();
            for (int i = arrearsTo.Year; i <= todayDate.Year; i++)
            {
                /**Loop from the current year to the paid till year and find out the arrears amount.
                 */
                if (arrearsTo.Year == 1899)
                {
                    //the data is not recorded properly due to corruption.
                    //Console.WriteLine("data is not properly recorded");
                    feesArrears = 0;
                    break;
                }
                countYear++;
                if (logging)
                {
                    Console.WriteLine("today:" + i);
                    Console.WriteLine("till:" + arrearsTo.Year);
                    Console.WriteLine("class code:" + classCode + " length:" + classCode.Trim().Length);
                }
                if (i == arrearsTo.Year)
                {//Paid till year is in the current loop. 

                    //If for current years' arrears.
                    if (arrearsTo.Year == todayDate.Year)
                    {
                        if(logging)
                        Console.WriteLine("calculating fee arrears for the current years'" +
                                          " Arrears: " + feesArrears);
                        int paidMonth = arrearsTo.Month;
                        if (paidMonth == 13)
                        {
                            paidMonth = 12;//paidMonth % 12;
                        }
                        int thisMonth = todayDate.Month + (netArrears==0?1:0);
                        if (thisMonth == 13)
                        {
                            thisMonth = 12;//paidMonth % 12;
                        }
                        int monthDiff = (thisMonth - paidMonth);
                        if (monthDiff < 0)
                        {
                            monthDiff = (monthDiff)+1;
                            thisMonth -= 1;
                        }
                        //feeRate = Double.Parse(lastRow["mfeerate"] + "");
                        feesArrears = feeRate * ((thisMonth - paidMonth)) + netArrears;
                        arrearsMap[i] = feeRate + "|" + (monthDiff) + "|" + feeRate * monthDiff;
                    }
                    else
                    { // arrears years is not the current year.
                        int paidMonth1 = arrearsTo.Month;
                        if (paidMonth1 != 12 && paidMonth1 < 12)
                        {
                            //calculate the remaining months in this year to be paid.   
                            paidMonth1 = 12 - paidMonth1;

                            //Get the fee rate for the year
                            
                            feeRate = this.guessClassAndFee(classCode, todayDate.Year, i);

                            //feeRate = Double.Parse(lastRow["mfeerate"] + "");
                            if(logging)
                            Console.WriteLine("arrears before:" + feesArrears);
                            feesArrears = feeRate * paidMonth1 + feesArrears + netArrears;
                            if (logging)
                            {
                                Console.WriteLine("paid till month: " + paidMonth1);
                                Console.WriteLine("fee Rate:" + feeRate);
                                Console.WriteLine("arrears:" + feesArrears);
                            }
                                arrearsMap[i] = feeRate + "|" + paidMonth1 + "|" + feeRate * paidMonth1;
                        }
                        else
                        {
                            feesArrears = netArrears + feesArrears;
                        }
                    }
                    if(logging)
                    Console.WriteLine("fee is not paid fully for the year " + i + ": " + feesArrears);

                }
                else
                {
                    //If for other years' arrears.
                    //Check the medium and then guess the key_fee.
                    if(logging)
                    Console.WriteLine("Calculating fee for other years.");
                    //int feecode = dao.getStudentClasses(keyClass).Key_fee;
                                        //calculate the rates with respect to the effective year fee. 
                    //Also check student concessions.  
                   
                    //i is this year but the students class is based on this year so reduce one year.
                    feeRate = this.guessClassAndFee(classCode, todayDate.Year, i);
                       
                    if (i == todayDate.Year)
                    {
                        //i == todayDate.Year and i!=paidTill.Year-- but there are arrears
                        if(logging)
                        Console.WriteLine("Calculating fee for this year:" + i);

                        int thisMonth = todayDate.Month;

                        int monthDiff = (thisMonth - 1) + 1;
                        if (monthDiff < 0)
                        {
                            monthDiff = -(monthDiff);
                        }
                        if (logging)
                        {
                            Console.WriteLine("month diff: " + monthDiff);
                            Console.WriteLine("fee Rate:" + feeRate);
                            Console.WriteLine("arrears:" + feesArrears);
                        }
                            feesArrears = feeRate * monthDiff + feesArrears;
                        if(logging)
                        Console.WriteLine("arrears:" + feesArrears);
                        arrearsMap[i] = feeRate + "|" + monthDiff + "|" + feeRate * monthDiff;
                        break;
                    }
                    else if (i > todayDate.Year) {
                        arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate * 12;
                    } else
                    {
                        feesArrears = feeRate * 12 + feesArrears;
                        arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate * 12;
                    }
                    if(logging)
                    Console.WriteLine("Fee rate: " + feeRate + " Arrears: " + feesArrears);
                }
            }
            bean.curArrears = feesArrears+"";
            bean.arrearsMap = arrearsMap;
                  
            return bean;

        }

        public double GetFeePaidForTheYear(int year,string admno,DateTime paidTill) {
            //TODO what if the fee is paid last year for the following year?
            SqlConnection conn = null;
            SqlCommand cmd = null;          
            SqlDataReader rdr = null;
            double paidAmount = 0;           
            try
            {
                string paidTillString=paidTill.ToString("yyyy-MM-dd");
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "select sum(m.paid) as paid from mnthfeepay m left join student s on  s.key_fld=m.key_stu where " +
  "s.admno = @Admno and m.trndate > '" + (year - 1) + "-12-31' and m.trndate<= '" + paidTillString + "' and m.deleted=0";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;

                cmd.Parameters.Add("@Admno", SqlDbType.VarChar).Value = admno;
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    paidAmount = Double.Parse(rdr["paid"].ToString());
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("exception", e);
            }
            finally {
                try
                {
                    if (rdr != null)
                        rdr.Close();
                    if (cmd != null)
                        cmd.Connection.Close();
                }
                catch (Exception e1) {
                    Console.WriteLine("exception when closing", e1);
                }
            }
            return paidAmount;
            }
        /**
         * This method gives all the fees paid for the whole year even if its paid last year
         */
        public double GetTotalFeePaidForTheYear(int year, string admno)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            double paidAmount = 0;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "select sum(paid) as paid from mnthfeepay m left join student s on s.key_fld= m.key_stu  where s.admno = @Admno " +
             " and m.deleted = 0 " +
                "and m.payfrom > '" + (year - 1) + "-12-31' and m.payto <= '" + year + "-12-31' ";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Admno", SqlDbType.VarChar).Value = admno;
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    paidAmount = Double.Parse(rdr["paid"].ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("exception", e);
            }
            finally
            {
                try
                {
                    if (rdr != null)
                        rdr.Close();
                    if (cmd != null)
                        cmd.Connection.Close();
                }
                catch (Exception e1)
                {
                    Console.WriteLine("exception when closing", e1);
                }
            }
            return paidAmount;
        }

        /**
       * Get a DataTable of the student admission numbers when the class is given.
       **/
        public string getReceiptLastNo(string RcptType)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            DataTable tbl = null;
            string rcptNo = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                //MFEERCPT
                //MFEES
                //ADMRCPT
                //GENRCPT
                //ALRCPT
                String sql = "select prefix,lastno from genlastno where groupname=@RCPT";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@RCPT", SqlDbType.VarChar).Value = RcptType;

                //Console.WriteLine("SQL:" + cmd.CommandText);
                // Console.WriteLine("*class:" + studentClass);
                //  rdr = cmd.ExecuteReader();
                tbl = new DataTable();
                tbl.Load(cmd.ExecuteReader());
                rcptNo = tbl.Rows[0]["prefix"].ToString() + tbl.Rows[0]["lastno"].ToString();
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
            return rcptNo;

        }

        public int updateRCPTLastNo(String RcptName)
        {
            //SqlDataReader rdr = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            int count = 0;
            try
            {

                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "update genlastno set lastno=lastno+1 where groupname=@Rcpt";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Rcpt", SqlDbType.VarChar).Value = RcptName;
                
                count=cmd.ExecuteNonQuery();
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
            return count;

        }
        //Monthly Fee insert for AL students
        private int getLastMnthFeeId() {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            int id = 0;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT MAX(key_fld)+1 as key_fld FROM mnthfeepay";
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;                
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    id = int.Parse(rdr["key_fld"].ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("exception", e);
            }
            finally
            {
                try
                {
                    if (rdr != null)
                        rdr.Close();
                    if (cmd != null)
                        cmd.Connection.Close();
                }
                catch (Exception e1)
                {
                    Console.WriteLine("exception when closing", e1);
                }
            }
            return id;
        }


        public Boolean insertALstudentFee(PaymentBean payBean) {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            int count = 0;
            try
            {
                int key_fld = getLastMnthFeeId();
                StudentBean stubean = getStudentInfoFromIndex(payBean.Admno);
                StuclassBean stuclass = new ClassDAO().getStuClass(stubean.Key_class);
                string trno = getReceiptLastNo("ALRCPT");

                string query = "insert into mnthfeepay (key_fld,trnno,trndate,key_stu,paid,balance,paymode,payccrd,paycash,paycheque,"
     + "ccrdno,chequeno,cashtndrd,chequedate,payfrom,payto,deleted,mfeerate,totarrears,arrearsfrm,arrearsto,"
     + "created,key_class,curbfarres,key_fee,key_grd,key_med,key_tea,key_sec,key_sh,key_vp,crtdky_user,winlguser,computernm)"
     + "values(@key_fld,@trnno,@trndate,@key_stu,@paid,@balance,@payccrd,@paycash,@paycheque,@ccrdno,@chequeno,@cashtndrd,@chequedate,"
     + "@payfrom,@payto,@deleted,@mfeerate,@totarrears,@arrearsfrm,@arrearsto,@created,@key_class,@curbfarres,@key_fee,@key_grd,@key_med,@key_tea,@key_sec,@key_sh,@key_vp,@crtdky_user,@winlguser,@computernm)";
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
               
                cmd.Parameters.AddWithValue("@trnno", trno);
                cmd.Parameters.AddWithValue("@key_fld", key_fld);
                cmd.Parameters.AddWithValue("@trndate", new DateTime());
                cmd.Parameters.AddWithValue("@key_stu", stubean.Key_fld);
                cmd.Parameters.AddWithValue("@paid", payBean.Paid);
                cmd.Parameters.AddWithValue("@balance", payBean.Balance);
                cmd.Parameters.AddWithValue("@payccrd",0);
                cmd.Parameters.AddWithValue("@paycash", payBean.IsCash == true? payBean.Paid : 0);
                cmd.Parameters.AddWithValue("@paycheque", payBean.IsCash == true ? 0: payBean.Paid);//cheque
                cmd.Parameters.AddWithValue("@ccrdno",0);
                cmd.Parameters.AddWithValue("@chequeno", payBean.ChequeNo);
                cmd.Parameters.AddWithValue("@cashtndrd",0);//cash
                cmd.Parameters.AddWithValue("@chequedate", payBean.ChequeDate);//
                cmd.Parameters.AddWithValue("@payfrom", payBean.PayFrom);
                cmd.Parameters.AddWithValue("@payto", payBean.PayTo);
                cmd.Parameters.AddWithValue("@deleted", payBean.Deleted);//1 means deleted
                cmd.Parameters.AddWithValue("@mfeerate", payBean.FeeRate);//AL fee rate for the year
                cmd.Parameters.AddWithValue("@totarrears", payBean.TotalArrears);//same as balance
                cmd.Parameters.AddWithValue("@arrearsfrm", payBean.ArrearsFrom);//not paid from month
                cmd.Parameters.AddWithValue("@arrearsto", payBean.ArrearsTo);//not paid date to
                cmd.Parameters.AddWithValue("@created", new DateTime());//created date
                cmd.Parameters.AddWithValue("@key_class", stubean.Key_class);//get appropriata class
                cmd.Parameters.AddWithValue("@curbfarres",0);//
                cmd.Parameters.AddWithValue("@key_fee", stuclass.Key_fee );//key_fee 
                cmd.Parameters.AddWithValue("@key_grd", stuclass.Key_grd);//
                cmd.Parameters.AddWithValue("@key_med", stuclass.Key_med);
                cmd.Parameters.AddWithValue("@key_tea", stuclass.Key_tea);
                cmd.Parameters.AddWithValue("@key_sec",0);
                cmd.Parameters.AddWithValue("@key_sh",0);
                cmd.Parameters.AddWithValue("@key_vp",0);
                cmd.Parameters.AddWithValue("@crtdky_user",0);
                cmd.Parameters.AddWithValue("@winlguser",0);
                cmd.Parameters.AddWithValue("@computernm","User1");
                cmd.ExecuteNonQuery();

            }
            catch (Exception e) {
              
            }
            return true;

        }

        public Boolean updateStudentFeeInfo(PaymentBean bean) {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            Boolean flag=false;
            int count = 0;
            try
            {
                string sql = "update STUDENT SET ";
            }
            catch (Exception e) {

            }
                return true;
        }

    }
}
