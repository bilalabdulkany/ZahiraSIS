﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZahiraSIS.com.zahira.bean
{
   public class StuclassBean
    {
        private int key_fld;
        private int key_grd;
        private int key_med;
        private string name;
        private string code;
        private string classcode;
        private int key_tea;
        private int key_fee;
        private int key_change;

        public StuclassBean() {
        }

        public StuclassBean(int key_fld, int key_grd, int key_med, string name, string code, int key_tea, int key_fee, int key_change) {
            this.key_fld = key_fld;
            this.key_med = key_med;
            this.name = name;
            this.code = code;
            this.key_tea = key_tea;
            this.key_fee = key_fee;
            this.key_change = key_change;
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

        public int Key_grd
        {
            get
            {
                return key_grd;
            }

            set
            {
                key_grd = value;
            }
        }

        public int Key_med
        {
            get
            {
                return key_med;
            }

            set
            {
                key_med = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Classcode
        {
            get
            {
                return classcode;
            }

            set
            {
                classcode = value;
            }
        }

        public int Key_tea
        {
            get
            {
                return key_tea;
            }

            set
            {
                key_tea = value;
            }
        }

        public int Key_fee
        {
            get
            {
                return key_fee;
            }

            set
            {
                key_fee = value;
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
    }
}
