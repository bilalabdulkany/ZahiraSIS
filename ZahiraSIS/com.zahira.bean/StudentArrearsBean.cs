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
        public DateTime paidTill { get; set; }
        public DataTable stPaidData { get; set; }
        public string curArrears { get; set; }

        public string bfArrears { get; set; }

        public string curBfArrears { get; set; }

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
