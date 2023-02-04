using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Stock_Management_System
{
    public partial class Orders : System.Web.UI.Page
    {
        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        DataTable dtlb = new DataTable();
        DataTable dtlb_customer = new DataTable();
        DataTable dtlb_product = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                returnConn.baglantı();
                SqlDataAdapter sqlData_Customer = new SqlDataAdapter("SELECT CONCAT(ID,' ',CUSTOMER_NAME) as IdAndName, ID FROM CUSTOMER_TABLE", returnConn.baglantı());
                sqlData_Customer.Fill(dtlb_customer);
                Select_Customer_Dropdown.DataSource= dtlb_customer;
                Select_Customer_Dropdown.DataBind();
                Select_Customer_Dropdown.DataTextField = "IdAndName";
                Select_Customer_Dropdown.DataValueField = "ID";
                Select_Customer_Dropdown.DataBind();

                SqlDataAdapter sqlData_Product = new SqlDataAdapter("SELECT CONCAT(ID,' ',PRODUCT_NAME) as IdAndName_Prod, ID FROM PRODUCT_TABLE", returnConn.baglantı());
                    sqlData_Product.Fill(dtlb_product);
                Select_Product_Dropdown.DataSource = dtlb_product;
                Select_Product_Dropdown.DataBind();
                Select_Product_Dropdown.DataTextField = "IdAndName_Prod";
                Select_Product_Dropdown.DataValueField = "ID";
                Select_Product_Dropdown.DataBind();

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM ORDER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Orders_Grid.DataSource = dtlb;
                Orders_Grid.DataBind();
                returnConn.baglantı_kes();

            }
        }

        protected void Select_Customer_Button_Click(object sender, EventArgs e)
        {
            returnConn.baglantı();
            //w5 = Select_Product.SelectedItem.Value;
            string query = $"SELECT * FROM CUSTOMER_TABLE WHERE ID={Select_Customer_Dropdown.SelectedValue}";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Customer_Name.Text = dr.GetValue(1).ToString();
                Customer_Address.Text = dr.GetValue(2).ToString();
                Customer_Gender.Text = dr.GetValue(3).ToString();
                Customer_Phone.Text = dr.GetValue(4).ToString();
                Customer_Mail.Text = dr.GetValue(5).ToString();
            }

        }

        protected void Select_Product_Button_Click(object sender, EventArgs e)
        {
            returnConn.baglantı();
            //w5 = Select_Product.SelectedItem.Value;
            string query = $"SELECT * FROM Product_TABLE WHERE ID={Select_Product_Dropdown.SelectedValue}";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                Product_Name.Text = dr.GetValue(1).ToString();
                Product_Quantity.Text = dr.GetValue(2).ToString();
                Product_Buy_Price.Text = dr.GetValue(3).ToString();
                Product_Sell_Price.Text = dr.GetValue(4).ToString();
                Product_Category.Text = dr.GetValue(5).ToString();
            }
        }
    }
}