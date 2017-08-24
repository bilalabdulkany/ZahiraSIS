using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahiraSIS.com.zahira.bean.student
{
    class StudentArrearsBean
    {
        public double feePaidForTheYear { get; set; }
        public double feerate { get; set; }
        public string studentName { get; set; }
        public string admNo { get; set; }
        public string classCode { get; set; }
        public DateTime paidTill { get; set; }
        public DateTime arrearsFrom { get; set; }
        public DateTime arrearsTo { get; set; }
        public DataTable stPaidData { get; set; }
        public string curArrears { get; set; }
        public string bfArrears { get; set; }
        public string curBfArrears { get; set; }
        public Dictionary<int, string> arrearsMap { get; set; }
        public bool studentConcession { get; set; }
        public int studentCount { get; set; }

        public StudentArrearsBean()
        {
        }

        public StudentArrearsBean(String bfArrears, String curArrears, String curBfArrears)
        {
            this.bfArrears = bfArrears;
            this.curArrears = curArrears;
            this.curBfArrears = curBfArrears;
        }

       

    }
}
