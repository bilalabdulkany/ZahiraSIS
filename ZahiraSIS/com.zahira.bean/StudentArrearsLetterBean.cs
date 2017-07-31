using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZahiraSIS.com.zahira.bean.student;

namespace ZahiraSIS.com.zahira.bean
{

    class StudentArrearsLetterBean
    {

        public StudentBean studentBean { get; set; }
        public StudentArrearsBean studentArrearsBean { get; set; }

        public StudentArrearsLetterBean(StudentBean stuBean, StudentArrearsBean stuArrearsBean) {
            this.studentArrearsBean = stuArrearsBean;
            this.studentBean = stuBean;
        }
    }
}
