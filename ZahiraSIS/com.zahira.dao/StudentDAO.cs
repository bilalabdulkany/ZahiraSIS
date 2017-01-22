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
                String sql = "select trnno,trndate,paid,payfrom,payto,mfeerate,totarrears,arrearsfrm,arrearsto,key_class from mnthfeepay where mnthfeepay.key_stu ="
  + "(select key_fld from student where admno = @Index) order by trndate";
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
                Console.WriteLine("SQL:" + cmd.CommandText);
                Console.WriteLine("date: " + effectYear);
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

                        bean = new StudentBean((int)keyFld, (int)active, enamfcnsn, (double)mfeecnsn, admno, name, dob,
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
        public StudentArrearsBean getStudentArrearsByDatePerClass(string studentClass, string fromDate, string toDate)
        {
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
                classwiseStudents.Columns.Add("Total Fee paid this year");
                int stlen = classwiseStudents.Rows.Count;
                Console.WriteLine("Total students: " + stlen);
                double cumArrears = 0;
                double totalPaid = 0;
                for (int i = 0; i < stlen; i++)
                {
                    string admno = classwiseStudents.Rows[i]["admno"].ToString().Trim();
                    try
                    {
                        arrearsBean = this.NewForwardBalance(admno, studentClass, DateTime.Parse(toDate), false);
                        if (arrearsBean != null)
                        {
                            classwiseStudents.Rows[i]["Arrears"] = arrearsBean.curArrears;
                            classwiseStudents.Rows[i]["Total Fee paid this year"] = arrearsBean.feePaidForTheYear;
                            classwiseStudents.Rows[i]["PaidTill"] = arrearsBean.paidTill.ToString("dd-MMM-yyyy");

                            cumArrears = cumArrears + double.Parse(arrearsBean.curArrears);
                            totalPaid =totalPaid+arrearsBean.feePaidForTheYear;
                            //Call fillTable. Then add all the fees to a bean.
                            //Its better if FillTable returns a bean consisting of student's arrears.
                            Console.WriteLine("cum. arrears: " + cumArrears);
                        }
                        else {
                            //Student on fee concession.
                            classwiseStudents.Rows[i]["Arrears"] = "0";
                            classwiseStudents.Rows[i]["PaidTill"] = "0";
                            classwiseStudents.Rows[i]["Total Fee paid this year"] = "0";
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
                if (rdr.HasRows)
                {
                    int key_fld = int.Parse(rdr["key_fld"] + "");
                    int key_grd = (int)rdr["key_grd"];
                    int key_med = (int)rdr["key_med"];
                    string name = rdr["name"] + "";
                    string code = rdr["code"] + "";
                    string classcode = rdr["classcode"] + "";
                    int key_tea = (int)rdr["key_tea"];
                    int key_fee = (int)rdr["key_fee"];
                    int key_change = (int)rdr["key_change"];
                    bean = new StuclassBean();
                    bean.Key_fld = key_fld;
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
                            int key_fee = 0;
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

                Console.WriteLine(cmd.CommandText);
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

        private double guessClassAndFee(string classCode, int currentYear,int arrearsYear)
        {
            ClassDAO clsDao = new ClassDAO();
            int yearsToReduce = currentYear - arrearsYear;
            double feeRate = 0;
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
            Console.WriteLine("grade:" + grade + " medium:" + guessedClass);
            int key_fee = (int)clsDao.GetStudentClassFee(grade, guessedClass.ToString()).Rows[0]["key_fee"];
            Console.WriteLine("***grade: " + grade);
            Console.WriteLine("***key_fee: " + key_fee);
            int thisYear = DateTime.Now.Year;
            if (arrearsYear > thisYear) {
                arrearsYear = thisYear;
            }
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

                Console.WriteLine(cmd.CommandText);
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


        public StudentArrearsBean NewForwardBalance(string admNo, string classCode, DateTime? asAt, bool guessClass) {
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

              /*  if (arrearsFromFromStudent > arrearsToFromStudent)
                {
                    //arrearsFromFromStudent=arrearsFromFromStudent.
                    arrearsToFromStudent = arrearsFromFromStudent.AddMonths(-1);
                }*/
                Console.WriteLine("net arrears in Student: " + totalArrearsFromStudent);

                Console.WriteLine("arrears to date in student: " + arrearsToFromStudent.ToString("dd-MMM-yyyy"));

                if (CheckStudentConcessions(admNo, classCode) == true)
                {
                    arrearsBean.curArrears = totalArrearsFromStudent+"";
                    arrearsBean.studentConcession = true;
                    return arrearsBean;
                }
                DateTime arrearsTo = arrearsFromFromStudent;
                DateTime paidTo = arrearsToFromStudent;
                double totalPaid = 0;
                DateTime todayDate = DateTime.Now;
                Boolean surplusPaid = false;
                Boolean paidLess = false;
                Boolean IsMonthFeeNull = false;
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
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

                    arrearsTo = (DateTime)lastRow["arrearsto"];
                    DateTime arrearsFrom= (DateTime)lastRow["arrearsfrm"];
                
                    Console.WriteLine("arrears to date in mnthfee: " + arrearsTo.ToString("dd-MMM-yyyy"));
                    double totalArrears = Double.Parse(lastRow["totarrears"].ToString());
                    totalPaid = Double.Parse(lastRow["paid"].ToString());
                    double netArrears = totalArrears - totalPaid;
                    Console.WriteLine("net arrears in mnthfee: " + netArrears);
                    arrearsBean.paidTill = (DateTime)lastRow["payto"];
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
                        totalPaid = GetFeePaidForTheYear(todayDate.Year, admNo);
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
                feeRate = this.guessClassAndFee(classCode, todayDate.Year, arrearsToFromStudent.Year);             
                Console.WriteLine("fee: " + feeRate);

                StudentArrearsBean calculatedBean = calculateArrears(arrearsToFromStudent, todayDate, feesArrears, classCode, totalArrearsFromStudent, feeRate);
                if (arrearsBean.paidTill.Month == todayDate.Month)
                {
                    if (totalPaid < feeRate ) {
                        paidLess = true;
                    }
                }
                double mnthFeeArrears = 0;
                if (!IsMonthFeeNull)
                {
                    if (takeFromFeePaid || surplusPaid)
                    {
                        mnthFeeArrears = -(totalPaid - feeRate * todayDate.Month);
                        calculatedBean.curArrears = mnthFeeArrears.ToString();
                    }
                    if (paidLess)
                    {
                        mnthFeeArrears = feeRate - totalPaid;
                        calculatedBean.curArrears = mnthFeeArrears.ToString();
                    }
                }
                // calculatedBean = calculateArrears(arrearsTo, todayDate, feesArrears, classCode, totalArrearsFromStudent, feeRate);

                arrearsTo = arrearsTo.AddMonths(1);
                    feesArrears = Double.Parse(calculatedBean.curArrears);
                    if (arrearsTo.Year > todayDate.Year || feesArrears < 0)
                    {
                    //negatives should be omitted here, and taken into another column
                        Console.WriteLine("resetting to 0");
                        if (dateDifference == 0)
                        {
                            feesArrears = 0;
                        }
                    }
                    Console.WriteLine("Date Diff:" + dateDifference + " arrears: " + feesArrears);
                    arrearsBean.curArrears = calculatedBean.curArrears;//feesArrears + "";
                    arrearsBean.arrearsMap = calculatedBean.arrearsMap;//arrearsMap;
                    arrearsBean.feePaidForTheYear = GetFeePaidForTheYear(todayDate.Year,admNo);

                //Put all the fees to arrears map
                if (arrearsBean.paidTill != null) {

                }

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


        private StudentArrearsBean calculateArrears(DateTime arrearsTo,DateTime todayDate,double feesArrears,string classCode,double netArrears, double feeRate) {
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
                    Console.WriteLine("data is not properly recorded");
                    feesArrears = 0;
                    break;
                }
                countYear++;
                Console.WriteLine("today:" + i);
                Console.WriteLine("till:" + arrearsTo.Year);
                Console.WriteLine("class code:" + classCode + " length:" + classCode.Trim().Length);

                if (i == arrearsTo.Year)
                {//Paid till year is in the current loop. 

                    //If for current years' arrears.
                    if (arrearsTo.Year == todayDate.Year)
                    {
                        Console.WriteLine("calculating fee arrears for the current years'" +
                                          " Arrears: " + feesArrears);
                        int paidMonth = arrearsTo.Month;
                        if (paidMonth == 13)
                        {
                            paidMonth = 12;//paidMonth % 12;
                        }
                        int thisMonth = todayDate.Month + 1;
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
                            Console.WriteLine("arrears before:" + feesArrears);
                            feesArrears = feeRate * paidMonth1 + feesArrears + netArrears;
                            Console.WriteLine("paid till month: " + paidMonth1);
                            Console.WriteLine("fee Rate:" + feeRate);
                            Console.WriteLine("arrears:" + feesArrears);
                            arrearsMap[i] = feeRate + "|" + paidMonth1 + "|" + feeRate * paidMonth1;
                        }
                        else
                        {
                            feesArrears = netArrears + feesArrears;
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
                                        //calculate the rates with respect to the effective year fee. 
                    //Also check student concessions.  
                   
                    
                      /*  int yearsToReduce = 0;
                        int key_fee = 0;
                        if (countYear != 1)
                        {
                            yearsToReduce = todayDate.Year - i;
                        }*/
                    //i is this year but the students class is based on this year so reduce one year.
                    feeRate = this.guessClassAndFee(classCode, todayDate.Year, i);
                       
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
                        break;
                    }
                    else if (i > todayDate.Year) {
                        arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate * 12;
                    } else
                    {
                        feesArrears = feeRate * 12 + feesArrears;
                        arrearsMap[i] = feeRate + "|" + 12 + "|" + feeRate * 12;
                    }
                    Console.WriteLine("Fee rate: " + feeRate + " Arrears: " + feesArrears);
                }
            }
            bean.curArrears = feesArrears+"";
            bean.arrearsMap = arrearsMap;            
            return bean;

        }

        public double GetFeePaidForTheYear(int year,string admno) {
            SqlConnection conn = null;
            SqlCommand cmd = null;          
            SqlDataReader rdr = null;
            double paidAmount = 0;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "select sum(paid) as paid from mnthfeepay where mnthfeepay.key_stu =" +
  "(select key_fld from student where admno = @Admno) and trndate > '" + (year - 1) + "-12-31' and trndate<= '" + year + "-12-31'";
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

            }
            return paidAmount;
            }

    }
}
