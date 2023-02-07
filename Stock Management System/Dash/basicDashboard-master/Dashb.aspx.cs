using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Stock_Management_System.Dash.basicDashboard_master.images
{
    public partial class Dashb : System.Web.UI.Page
    {
        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        DataTable dtlb = new DataTable();
        DataTable dtlb_orders = new DataTable();

        //return order row number
        public int return_of_number(string table_name)
        {
            returnConn.baglantı();
            string query = $"SELECT COUNT(*) FROM {table_name};";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int count = Convert.ToInt32(command.ExecuteScalar());
            returnConn.baglantı_kes();
            return count;
        }

        //return total gain
        public int return_gain()
        {
            int total_gain=0;
            int number_of_orders=return_of_number("ORDER_TABLE");
            for (int i = 1; i <= number_of_orders; i++)
            {
                returnConn.baglantı();
                string query = $"Select ORDER_PRODUCT_GAIN From(Select Row_Number() Over(Order By ORDER_NUMBER) As RowNum, *From ORDER_TABLE) t2 Where RowNum = {i}";
                SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                int firs_value = int.Parse(dr.GetValue(0).ToString());
                total_gain = total_gain + firs_value;
            }
            returnConn.baglantı_kes();
            return total_gain;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {   //load gridview on page_load
                //open connection
                returnConn.baglantı();
                //databind product
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();
                //databind orders
                SqlDataAdapter sqlData_orders = new SqlDataAdapter("SELECT * FROM ORDER_TABLE", returnConn.baglantı());
                sqlData_orders.Fill(dtlb_orders);
                Orders_Grid.DataSource = dtlb_orders;
                Orders_Grid.DataBind();

                Customer_Count.Text= return_of_number("CUSTOMER_TABLE").ToString();
                Supplier_Count.Text = return_of_number("SUPPLIER_TABLE").ToString();
                Sales_Count.Text = return_of_number("ORDER_TABLE").ToString();
                Total_Gain.Text = return_gain().ToString();
                returnConn.baglantı_kes();
            }
        }

        protected void Update_Sales_Click(object sender, EventArgs e)
        {
            Sales_Count.Text = return_of_number("ORDER_TABLE").ToString();
        }

        protected void Update_Gain_Click(object sender, EventArgs e)
        {

        }

        protected void Update_Supplier_Click(object sender, EventArgs e)
        {
            Supplier_Count.Text = return_of_number("SUPPLIER_TABLE").ToString();
        }

        protected void Update_Customer_Click(object sender, EventArgs e)
        {
            Customer_Count.Text = return_of_number("CUSTOMER_TABLE").ToString();
        }
    }
}