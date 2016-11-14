using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZahiraSIS.com.zahira.bean
{
    class StudentBean
    {
        private int key_fld;
        private int active;
        private int enamfcnsn;
        private double mfeecnsn;
        private string address;
        private string registerno;
        private string bloodgr;
        private string comments;
        private string prntname;
        private string prntphone;
        private string prntemail;
        private int key_class;
        private double bfarrears;
        private double curarrears;
        private int key_change;
        private double curbfarres;
        private DateTime admon;
        private DateTime arrearsfrm;
        private DateTime arrearsto;

        public StudentBean(int keyFld, int active, int enamfcnsn, double mfeecnsn, string admno, string name, DateTime dob, string address, string registerno, string bloodgr, string comments, string prntname, string prntphone, string prntemail, int keyClass, double bfarrears, double curarrears, int keyChange, double curbfarres, DateTime admon, DateTime arrearsfrm, DateTime arrearsto)
        {
            this.key_fld = keyFld;
            this.active = active;
            this.enamfcnsn = enamfcnsn;
            this.mfeecnsn = mfeecnsn;
            this.Admno = admno;
            this.Name = name;
            this.Dob = dob;
            this.address = address;
            this.registerno = registerno;
            this.bloodgr = bloodgr;
            this.comments = comments;
            this.prntname = prntname;
            this.prntphone = prntphone;
            this.prntemail = prntemail;
            key_class = keyClass;
            this.bfarrears = bfarrears;
            this.curarrears = curarrears;
            key_change = keyChange;
            this.curbfarres = curbfarres;
            this.admon = admon;
            this.arrearsfrm = arrearsfrm;
            this.arrearsto = arrearsto;
        }

        public int Key_fld
        {
            get
            {
                return key_fld;
            }

            set
            {
                key_fld = value;
            }
        }

        public int Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public int Enamfcnsn
        {
            get
            {
                return enamfcnsn;
            }

            set
            {
                enamfcnsn = value;
            }
        }

        public double Mfeecnsn
        {
            get
            {
                return mfeecnsn;
            }

            set
            {
                mfeecnsn = value;
            }
        }

        public string Admno { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Registerno
        {
            get
            {
                return registerno;
            }

            set
            {
                registerno = value;
            }
        }

        public string Bloodgr
        {
            get
            {
                return bloodgr;
            }

            set
            {
                bloodgr = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public string Prntname
        {
            get
            {
                return prntname;
            }

            set
            {
                prntname = value;
            }
        }

        public string Prntphone
        {
            get
            {
                return prntphone;
            }

            set
            {
                prntphone = value;
            }
        }

        public string Prntemail
        {
            get
            {
                return prntemail;
            }

            set
            {
                prntemail = value;
            }
        }

        public int Key_class
        {
            get
            {
                return key_class;
            }

            set
            {
                key_class = value;
            }
        }

        public double Bfarrears
        {
            get
            {
                return bfarrears;
            }

            set
            {
                bfarrears = value;
            }
        }

        public double Curarrears
        {
            get
            {
                return curarrears;
            }

            set
            {
                curarrears = value;
            }
        }

        public int Key_change
        {
            get
            {
                return key_change;
            }

            set
            {
                key_change = value;
            }
        }

        public double Curbfarres
        {
            get
            {
                return curbfarres;
            }

            set
            {
                curbfarres = value;
            }
        }

        public DateTime Admon
        {
            get
            {
                return admon;
            }

            set
            {
                admon = value;
            }
        }

        public DateTime Arrearsfrm
        {
            get
            {
                return arrearsfrm;
            }

            set
            {
                arrearsfrm = value;
            }
        }

        public DateTime Arrearsto
        {
            get
            {
                return arrearsto;
            }

            set
            {
                arrearsto = value;
            }
        }
    }
}
