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

        string connectionString = "Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True";

        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable dtlb = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                sqlcon = returnConn.getConnection();
                sqlcon.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", sqlcon);
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();

            }
        }

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

            else if (Convert.ToInt64(Customer_Phone.Text) < 1000000000 || Convert.ToInt64(Customer_Phone.Text) > 999999999)
            {
                Saved_Or_Not_label.Text = "Phone number must be 10 digits";
            }

            else if (Customer_Join_Date.GetType() != typeof(DateTime))
            {
                DateTime enteredDate = DateTime.Parse(Customer_Join_Date.Text);
                DateTime a = enteredDate;

                //sqlcon=conn
                sqlcon = returnConn.getConnection();
                sqlcon.Open();
                String query = "INSERT INTO CUSTOMER_TABLE(CUSTOMER_NAME,CUSTOMER_ADDRESS,CUSTOMER_GENDER,CUSTOMER_PHONE,CUSTOMER_MAIL,CUSTOMER_JOIN_DATE) VALUES (@CUSTOMER_NAME,@CUSTOMER_ADDRESS,@CUSTOMER_GENDER,@CUSTOMER_PHONE,@SCUSTOMER_MAIL,@CUSTOMER_JOIN_DATE)";

                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.Add("@CUSTOMER_NAME",    Customer_Name.Text);
                command.Parameters.Add("@CUSTOMER_ADDRESS", Customer_Address.Text);
                //sorun var çöz
                command.Parameters.Add("@CUSTOMER_GENDER", Customer_Gender.SelectedItem.Value);
                command.Parameters.Add("@CUSTOMER_PHONE", Convert.ToInt64(Customer_Phone.Text));
                command.Parameters.Add("@SCUSTOMER_MAIL", Customer_Maıl.Text);
                command.Parameters.Add("@CUSTOMER_JOIN_DATE", enteredDate);
                command.ExecuteNonQuery();

                //databind tekrardan
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM CUSTOMER_TABLE", sqlcon);
                sqlData.Fill(dtlb);
                Customer_Grid.DataSource = dtlb;
                Customer_Grid.DataBind();
            }
            else
            {
                //???
            }
        }
    }
}