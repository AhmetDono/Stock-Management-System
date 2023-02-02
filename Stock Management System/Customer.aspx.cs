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
    public partial class Customer : System.Web.UI.Page
    {

        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        SqlConnection sqlcon = new SqlConnection();
        DataTable dtlb = new DataTable();

        //pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {   //load gridview on page_load
                //open connection
                returnConn.baglantı();
                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        //save data
        protected void Save_Click(object sender, EventArgs e)
        {
            if (Customer_Name.Text == "" || Customer_Address.Text == "" || Customer_Gender.Text == "" || Customer_Maıl.Text == "")
            {
                Saved_Or_Not_label.Text = "No value can be left null";
            }

            else if (Customer_Name.Text.Length>50 || Customer_Address.Text.Length>200 ||Customer_Maıl.Text.Length>50)
            {
                Saved_Or_Not_label.Text = "Name can't be more than 50 letter and Address can't be more than 200 letter";
            }

            else if (Convert.ToInt64(Customer_Phone.Text) > 10000000000 || Convert.ToInt64(Customer_Phone.Text) < 999999999)
            {
                Saved_Or_Not_label.Text = "Phone number must be 10 digits";
            }

            else if (Customer_Join_Date.GetType() != typeof(DateTime))
            {
                //sql connection
                returnConn.baglantı();
                DateTime enteredDate = DateTime.Parse(Customer_Join_Date.Text);
                DateTime a = enteredDate;

                string query = "INSERT INTO CUSTOMER_TABLE(CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_GENDER,CUSTOMER_PHONE,CUSTOMER_MAIL,CUSTOMER_JOIN_DATE) VALUES (@CUSTOMER_NAME,@CUSTOMER_ADDRESS,@CUSTOMER_GENDER,@CUSTOMER_PHONE,@SCUSTOMER_MAIL,@CUSTOMER_JOIN_DATE)";

                SqlCommand command = new SqlCommand(query, returnConn.baglantı());
                command.Parameters.Add("@CUSTOMER_NAME",    Customer_Name.Text);
                command.Parameters.Add("@CUSTOMER_ADDRESS", Customer_Address.Text);
                //sorun var çöz
                command.Parameters.Add("@CUSTOMER_GENDER", Customer_Gender.SelectedItem.Value);
                command.Parameters.Add("@CUSTOMER_PHONE", Convert.ToInt64(Customer_Phone.Text));
                command.Parameters.Add("@SCUSTOMER_MAIL", Customer_Maıl.Text);
                command.Parameters.Add("@CUSTOMER_JOIN_DATE", enteredDate);
                command.ExecuteNonQuery();

                //databind tekrardan
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();
                returnConn.baglantı_kes();
            }
            else
            {
                //buraya hiç girmeyecek
            }
        }

        protected void Customer_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Customer_Grid.DataKeys[e.RowIndex].Values[0]);
            String query = "DELETE FROM CUSTOMER_TABLE WHERE ID='" + ID + "' ";
            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Deleted');", true);
                Customer_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        protected void Customer_Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            returnConn.baglantı();
            Customer_Grid.EditIndex = e.NewEditIndex;

            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
            DataTable dtlb = new DataTable();
            sqlData.Fill(dtlb);
            Customer_Grid.DataSource = dtlb;
            Customer_Grid.DataBind();
            returnConn.baglantı_kes();
        }

        protected void Customer_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            returnConn.baglantı();
            int ID = Convert.ToInt32(Customer_Grid.DataKeys[e.RowIndex].Values[0]);
            string customer_name = ((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string customer_address= ((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            char customer_gender = Convert.ToChar(((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            long customer_phone = Convert.ToInt64(((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            string customer_mail = ((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            DateTime customer_join_date = DateTime.Parse(((TextBox)Customer_Grid.Rows[e.RowIndex].Cells[6].Controls[0]).Text);

            string query = "UPDATE CUSTOMER_TABLE SET CUSTOMER_NAME='" + customer_name + "',CUSTOMER_ADDRESS='" + customer_address + "',CUSTOMER_GENDER='" + customer_gender + "',CUSTOMER_PHONE='" + customer_phone + "',CUSTOMER_MAIL='" + customer_mail + "',CUSTOMER_JOIN_DATE='" + customer_join_date + "' WHERE ID='" + ID + "'";

            SqlCommand command = new SqlCommand(query, returnConn.baglantı());
            int t = command.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Data Has Updated');", true);
                Customer_Grid.EditIndex = -1;

                //databind
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();
                returnConn.baglantı_kes();
            }
        }

        protected void Customer_Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            returnConn.baglantı();
            Customer_Grid.EditIndex = -1;
            //databind
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", returnConn.baglantı());
            sqlData.Fill(dtlb);
            Customer_Grid.DataSource = dtlb;
            Customer_Grid.DataBind();
            returnConn.baglantı_kes();
        }
    }
}