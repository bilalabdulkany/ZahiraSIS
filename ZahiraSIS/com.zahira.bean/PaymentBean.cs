using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahiraSIS.com.zahira.bean
{
   public class PaymentBean
    {
        public string KeyStu { get; set; }
        public string Admno { get; set; }
        public Boolean IsCash { get; set; }
        public double Paid { get; set; }
        public double ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public double FeeRate { get; set; }
        public DateTime PayFrom { get; set; }
        public DateTime PayTo { get; set; }
        public int Deleted { get; set; }
        public DateTime? ArrearsFrom { get; set; }
        public DateTime? ArrearsTo { get; set; }
        public double TotalArrears { get; set; }
        public double Balance { get; set; }
        
        public void SetCheque(Boolean IsCash) {
            if (IsCash) {
                ChequeNo = 0;
                ChequeDate = null;
            }
        }

    }
}
