using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahiraSIS.com.zahira.bean.student
{
    class StudentArrearsBean
    {
        
        private String bfArrears;
        private String curArrears;
        private String curBfArrears;

        public StudentArrearsBean(String bfArrears, String curArrears, String curBfArrears)
        {
            this.bfArrears = bfArrears;
            this.curArrears = curArrears;
            this.curBfArrears = curBfArrears;
        }

        public String getBfArrears() {
            return this.bfArrears;
        }
        public String getCurArrears()
        {
            return this.curArrears;
        }
        public String getCurBfArrears()
        {
            return this.curBfArrears;
        }

        public void setBfArrears(String bfArrears)
        {
            this.bfArrears=bfArrears;
        }

        public void setCurArrears( String curArrears)
        {
            this.curArrears=curArrears;
        }
        public void setCurBfArrears(String curBfArrears)
        {
            this.curBfArrears=curBfArrears;
        }

    }
}
