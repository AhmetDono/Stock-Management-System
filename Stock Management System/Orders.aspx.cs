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

        //page load
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

        //clear textbox
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }

        //return gain and sell price first value
        public int Return_First_Value(int a)
        {
            returnConn.baglantı();
            string query = $"SELECT * FROM Product_TABLE WHERE ID={Select_Product_Dropdown.SelectedValue}";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            int firs_value = int.Parse(dr.GetValue(a).ToString());
            returnConn.baglantı_kes();
            return firs_value;
        }

        //select customer
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

        //select product
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

        //save order
        protected void Save_Order_Click(object sender, EventArgs e)
        {

            try
            {
                if (Customer_Address.Text == "")
                {
                    Saved_Or_Not_label.Text = "No value can be left null";
                }
                if (int.Parse(Product_Quantity.Text) <= 0 || int.Parse(Product_Sell_Price.Text) <= 0)
                {
                    Saved_Or_Not_label.Text = "Quantity rr Sell Price can't be zero or less than zero";
                }
                else if (Return_First_Value(2) < int.Parse(Product_Quantity.Text) || int.Parse(Product_Buy_Price.Text) >= int.Parse(Product_Sell_Price.Text))
                {
                    Saved_Or_Not_label.Text = "Quantity can't be morde than stock quantity or Sell Price can't be less than buy price ";
                }
                else
                {
                    returnConn.baglantı();
                    string query = "INSERT INTO ORDER_TABLE(ORDER_CUSTOMER_NAME,ORDER_CUSTOMER_ADDRESS,ORDER_CUSTOMER_CONTACT,ORDER_PRODUCT_NAME,ORDER_PRODUCT_QUANTITY,ORDER_PRODUCT_BUY_PRICE,ORDER_PRODUCT_SELL_PRICE,ORDER_PRODUCT_CATEGORY,ORDER_PRODUCT_GAIN) VALUES (@ORDER_CUSTOMER_NAME,@ORDER_CUSTOMER_ADDRESS, @ORDER_CUSTOMER_CONTACT,@ORDER_PRODUCT_NAME,@ORDER_PRODUCT_QUANTITY,@ORDER_PRODUCT_BUY_PRICE,@ORDER_PRODUCT_SELL_PRICE,@ORDER_PRODUCT_CATEGORY,@ORDER_PRODUCT_GAIN)";

                    SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                    command.Parameters.Add("@ORDER_CUSTOMER_NAME", Customer_Name.Text);
                    command.Parameters.Add("@ORDER_CUSTOMER_ADDRESS", Customer_Address.Text);
                    command.Parameters.Add("@ORDER_CUSTOMER_CONTACT", Customer_Mail.Text + Customer_Phone.Text);
                    command.Parameters.Add("@ORDER_PRODUCT_NAME", Product_Name.Text);
                    command.Parameters.Add("@ORDER_PRODUCT_QUANTITY", int.Parse(Product_Quantity.Text));
                    command.Parameters.Add("@ORDER_PRODUCT_BUY_PRICE", int.Parse(Product_Buy_Price.Text));
                    command.Parameters.Add("@ORDER_PRODUCT_SELL_PRICE", int.Parse(Product_Sell_Price.Text));
                    command.Parameters.Add("@ORDER_PRODUCT_CATEGORY", Product_Category.Text);
                    command.Parameters.Add("@ORDER_PRODUCT_GAIN", int.Parse(Product_Quantity.Text) * (int.Parse(Product_Sell_Price.Text) - int.Parse(Product_Buy_Price.Text)));
                    command.ExecuteNonQuery();

                    //databind
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM ORDER_TABLE", returnConn.baglantı());
                    sqlData.Fill(dtlb);
                    Orders_Grid.DataSource = dtlb;
                    Orders_Grid.DataBind();
                    returnConn.baglantı_kes();

                    //clear textbox
                    ClearInputs(Page.Controls);

                    Saved_Or_Not_label.Text = "Order Successfully Saved";
                }
            }
            catch (FormatException)
            {
                Saved_Or_Not_label.Text = "Invalid Value";
            }

        }

        //delete data
        protected void Orders_Grid_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            returnConn.baglantı();
            int ORDER_NUMBER = Convert.ToInt32(Orders_Grid.DataKeys[e.RowIndex].Values[0]);
            String query = "DELETE FROM ORDER_TABLE WHERE ORDER_NUMBER='" +ORDER_NUMBER+ "' ";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Deleted');", true);
                Orders_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM ORDER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Orders_Grid.DataSource = dtlb;
                Orders_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }
    }
}