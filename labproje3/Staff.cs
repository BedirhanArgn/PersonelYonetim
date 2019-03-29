using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labproje3
{
    class Staff
    {
        private string id;
        private string name;
        private string surname;
        private string address;
        private int deneyim;
        private int Ydbdil;
        private int Calisilanil;
        private int Ailedurum;
        private int Yoneticilikgorevi;
        private int Ustogrenim;
        private double salary;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
            }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        //public double Salary
        //{
        //    get
        //    {
        //        Salary1 =(bazucret * (Deneyim + ustogrenim + ailedurum + ydbdil + yoneticilikgorevi + 1.0));
        //        return Salary1;
        //    }
        //}
        public double Deneyim
        {
            get
            {
                if (deneyim == 0)
                {
                    return 0.60;
                }
                else if (deneyim == 1)
                {
                    return 1.00;
                }
                else if (deneyim == 2)
                {
                    return 1.20;
                }
                else if (deneyim == 3)
                {
                    return 1.35;
                }
                else
                {
                    return 1.50;
                }
            }
            set { deneyim = Convert.ToInt32(value); }
        }
        public double ustogrenim
        {
            get
            {
                if (Ustogrenim == 0)
                {
                    return 0.10;
                }
                else if (Ustogrenim == 1)
                {
                    return 0.30;
                }
                else if (Ustogrenim == 2)
                {
                    return 0.35;
                }
                else if (Ustogrenim == 3)
                {
                    return 0.05;
                }
                else
                {
                    return 0.15;
                }


            }
            set { Ustogrenim = Convert.ToInt32(value); }
        }
        public double ydbdil
        {
            get
            {
                if (Ydbdil == 0)
                {
                    return 0.20;
                }
                else if (Ydbdil == 1)
                {
                    return 0.20;
                }
                else
                {
                    return 0.05;
                }

            }
            set { Ydbdil = Convert.ToInt32(value); }
        }
        public double yoneticilikgorevi
        {
            get
            {
                if(Yoneticilikgorevi==0)
                {
                    return 0.50;
                }
                else if(Yoneticilikgorevi==1)
                {
                    return 0.75;
                }
                else if(Yoneticilikgorevi==2)
                {
                    return 0.85;
                }
                else if(Yoneticilikgorevi==3)
                {
                    return 1.00;
                }
                else if(Yoneticilikgorevi==4)
                {
                    return 0.40;
                }
                else {                
                    return 0.60;
                }
            }
            set { Yoneticilikgorevi = Convert.ToInt32(value); }
        }
        public double ailedurum
        {
            get
            {
                return Ailedurum;
            }
            set { Ailedurum = Convert.ToInt32(value); }
        }
        public double calisilanil
        {
            get
            {
                if (Calisilanil == 0)
                {
                    return 0.15;
                }
                else if (Calisilanil == 1)
                {
                    return 0.10;
                }
                else if (Calisilanil == 2)
                {
                    return 0.10;
                }
                else if (Calisilanil == 3)
                {
                    return 0.05;
                }
                else if (Calisilanil == 4)
                {
                    return 0.05;
                }
                else
                {
                    return 0.03;
                }
            }

            set { Calisilanil = Convert.ToInt32(value); }
        }

        public double Salary1
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }
    }
}
