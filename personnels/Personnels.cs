using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personnels
{

    public abstract class PERSONNELS //kendisinden üretilemiyor
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { }
        }

        private string _SurName;
        public string SurName
        {
            get { return _SurName; }
            set { }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { }
        }

        private uint _Phone;
        public uint Phone
        {
            get { return _Phone; }
            set { }
        }

        private string _Mail;
        public string Mail
        {
            get { return _Mail; }
            set { }
        }

        private char _Gender;
        public char Gender
        {
            get { return _Gender; }
            set { }
        }

    }


    public class Admin: PERSONNELS
    {
    }

    public class Employee: PERSONNELS
    {
    }

}
