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
    public partial class Main : System.Web.UI.Page
    {
        string connectionString = "Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True";

        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable dtlb = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                sqlcon = returnConn.getConnection();
                sqlcon.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE",sqlcon);
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();

            }

        }

        //kayıt butonu
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (Product_Name.Text=="" || Product_Quantity.Text=="" || Product_Buy_Price.Text=="" || Product_Buy_Sell.Text=="" || Product_Category.Text=="" )
            {
                Saved_Or_Not_label.Text = "No value can be left null";
            }

            else
            {
                if (Product_Name.Text.Length>50 || Product_Category.Text.Length>50 )
                {
                    Saved_Or_Not_label.Text = "Product Name Or Product Category Name can't be more than 50 letter";
                }

                else if (int.Parse(Product_Quantity.Text)<=0 || int.Parse(Product_Buy_Price.Text)<=0 || int.Parse(Product_Buy_Sell.Text)<=0)
                {
                    Saved_Or_Not_label.Text = "Product Quantity/Buy Price/Sell Price can't be equal or less than 0";
                }

                else
                {   
                    //sqlcon=conn
                    sqlcon = returnConn.getConnection();
                    sqlcon.Open();
                    cmd = new SqlCommand("INSERT INTO PRODUCT_TABLE(PRODUCT_NAME,PRODUCT_QUANTITY,PRODUCT_BUY_PRICE,PRODUCT_SELL_PRICE,PRODUCT_CATEGORY) VALUES('" + Product_Name.Text + "' ,'" + int.Parse(Product_Quantity.Text) + "' ,'" + int.Parse(Product_Buy_Price.Text) + "' ,'" + int.Parse(Product_Buy_Sell.Text) + "' ,'" + Product_Category.Text + "' )", sqlcon);
                    cmd.ExecuteNonQuery();

                    //databind tekrardan
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", sqlcon);
                    sqlData.Fill(dtlb);
                    Product_Grid.DataSource = dtlb;
                    Product_Grid.DataBind();

                    Product_Name.Text = "";
                    Product_Quantity.Text = "";
                    Product_Buy_Price.Text = "";
                    Product_Buy_Sell.Text = "";
                    Product_Category.Text = "";
                    Saved_Or_Not_label.Text = "successfully saved";

                }
            }

        }

        protected void Product_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Product_Grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}