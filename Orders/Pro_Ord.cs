using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public abstract class PROD_ORDS
    {
        private int _Order_Number;
        public int Order_Number
        {
            get { return _Order_Number; }
            set { }
        }

        private string _Product_Name;
        public string Product_Name
        {
            get { return _Product_Name; }
            set { }
        }

        private int _Product_Quantity;
        public int Product_Quantity
        {
            get { return _Product_Quantity; }
            set { }
        }

        private int _Product_Buy_Price;
        public int Product_Buy_Price
        {
            get { return _Product_Buy_Price; }
            set { }
        }

        private int _Product_Sell_Price;
        public int Product_Sell_Price
        {
            get { return _Product_Sell_Price; }
            set { }
        }

        private int _Product_Category;
        public int Product_Category
        {
            get { return _Product_Category; }
            set { }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { }
        }

        private int _Gain;
        public int Gain
        {
            get { return _Gain; }
            set { }
        }

        //ürün açıklaması
    }

    public class Product: PROD_ORDS
    {

    }

    public class Orders : PROD_ORDS
    {

    }

}
