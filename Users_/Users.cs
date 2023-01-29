using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_
{

    public abstract class USERS
    {
        private string _Customer_Supplier_Name;
        public string Customer_Supplier_Name
        {
            get { return _Customer_Supplier_Name; }
            set { }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { }
        }

        private char _Gender;
        public char Gender
        {
            get { return _Gender; }
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

        private DateTime _Join_Date;
        public DateTime Join_Date
        {
            get { return _Join_Date; }
            set { }
        }


    }

    public class Customer: USERS
    {
    }

    public class Supplier: USERS
    {
    }


}
