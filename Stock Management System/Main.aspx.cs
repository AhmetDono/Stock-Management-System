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
        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        DataTable dtlb = new DataTable();

        //Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {   //load gridview on page_load
                //open connection
                returnConn.baglantı();
                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();
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

        //Save data
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Product_Name.Text == "" || Product_Quantity.Text == "" || Product_Buy_Price.Text == "" || Product_Buy_Sell.Text == "" || Product_Category.Text == "")
                {
                    Saved_Or_Not_label.Text = "No value can be left null";
                }

                else
                {
                    if (Product_Name.Text.Length > 50 || Product_Category.Text.Length > 50)
                    {
                        Saved_Or_Not_label.Text = "Product Name Or Product Category Name can't be more than 50 letter";
                    }

                    else if (int.Parse(Product_Quantity.Text) <= 0 || int.Parse(Product_Buy_Price.Text) <= 0 || int.Parse(Product_Buy_Sell.Text) <= 0)
                    {
                        Saved_Or_Not_label.Text = "Product Quantity/Buy Price/Sell Price can't be equal or less than 0";
                    }

                    else
                    {
                        returnConn.baglantı();
                        string query = "INSERT INTO PRODUCT_TABLE(PRODUCT_NAME,PRODUCT_QUANTITY,PRODUCT_BUY_PRICE,PRODUCT_SELL_PRICE,PRODUCT_CATEGORY) VALUES (@PRODUCT_NAME,@PRODUCT_QUANTITY, @PRODUCT_BUY_PRICE,@PRODUCT_SELL_PRICE,@PRODUCT_CATEGORY)";

                        SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                        command.Parameters.Add("@PRODUCT_NAME", Product_Name.Text);
                        command.Parameters.Add("@PRODUCT_QUANTITY", int.Parse(Product_Quantity.Text));
                        command.Parameters.Add("@PRODUCT_BUY_PRICE", int.Parse(Product_Buy_Price.Text));
                        command.Parameters.Add("@PRODUCT_SELL_PRICE", int.Parse(Product_Buy_Sell.Text));
                        command.Parameters.Add("@PRODUCT_CATEGORY", Product_Category.Text);
                        command.ExecuteNonQuery();

                        //databind
                        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
                        sqlData.Fill(dtlb);
                        Product_Grid.DataSource = dtlb;
                        Product_Grid.DataBind();
                        returnConn.baglantı_kes();

                        //clear textbox
                        ClearInputs(Page.Controls);

                        Saved_Or_Not_label.Text = "successfully saved";

                    }
                }
            }
            catch (FormatException)
            {
                Saved_Or_Not_label.Text = "Invalid Value";
            }

        }

        //delete
        protected void Product_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Product_Grid.DataKeys[e.RowIndex].Values[0]);
            String query = "DELETE FROM PRODUCT_TABLE WHERE ID='" + ID + "' ";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Deleted');", true);
                Product_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        //edit
        protected void Product_Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            returnConn.baglantı();
            Product_Grid.EditIndex = e.NewEditIndex;

            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
            DataTable dtlb = new DataTable();
            sqlData.Fill(dtlb);
            Product_Grid.DataSource = dtlb;
            Product_Grid.DataBind();
            returnConn.baglantı_kes();
        }

        //update
        protected void Product_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Product_Grid.DataKeys[e.RowIndex].Values[0]);
            string product_name = ((TextBox)Product_Grid.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int product_quantity = int.Parse(((TextBox)Product_Grid.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            int product_buy_price = int.Parse(((TextBox)Product_Grid.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            int product_sell_price = int.Parse(((TextBox)Product_Grid.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            string product_category = ((TextBox)Product_Grid.Rows[e.RowIndex].Cells[5].Controls[0]).Text;

            string query = "UPDATE PRODUCT_TABLE SET PRODUCT_NAME='" + product_name + "',PRODUCT_QUANTITY='" + product_quantity + "',PRODUCT_BUY_PRICE='" + product_buy_price + "',PRODUCT_SELL_PRICE='" + product_sell_price + "',PRODUCT_CATEGORY='" + product_category + "' WHERE ID='" + ID + "'";

            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Updated');", true);
                Product_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        //cancel edit
        protected void Product_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            returnConn.baglantı();
            Product_Grid.EditIndex = -1;
            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE", returnConn.baglantı());
            sqlData.Fill(dtlb);
            Product_Grid.DataSource = dtlb;
            Product_Grid.DataBind();
            returnConn.baglantı_kes();
        }
    }
}