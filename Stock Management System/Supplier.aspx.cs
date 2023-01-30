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
    public partial class Supplier : System.Web.UI.Page
    {
        string connectionString = "Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True";

        DataBase.MicrosoftSQL returnConn = new DataBase.MicrosoftSQL();
        SqlConnection sqlcon = new SqlConnection();
        DataTable dtlb = new DataTable();

        //SAYFA AÇILIŞINDA TABLOYU YÜKLEME
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                sqlcon = returnConn.getConnection();
                sqlcon.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", sqlcon);
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Supplier_Grid.DataSource = dtlb;
                Supplier_Grid.DataBind();

            }
        }

        protected void Supplier_Name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Save_Supplier_Click(object sender, EventArgs e)
        {
            if (Supplier_Name.Text=="" || Supplier_Address.Text=="" || Supplier_Mail.Text=="" || Supplier_Phone.Text=="" || Supplier_Join_Date.Text=="")
            {
                Saved_Or_Not_label.Text = "No value can be left null";
            }

            else
            {
                if (Supplier_Name.Text.Length > 50 || Supplier_Address.Text.Length > 200 || Supplier_Mail.Text.Length > 50)
                {
                    Saved_Or_Not_label.Text = "Supplier Name Supplier Mail can't be more than 50 letter and Supplier Adress can't be more than 200 letter";
                }
                                                              
                else if (Convert.ToInt64(Supplier_Phone.Text) > 10000000000 || Convert.ToInt64(Supplier_Phone.Text) < 999999999)
                {
                    Saved_Or_Not_label.Text = "Phone number must be 10 digits";
                }
                else if (Supplier_Join_Date.GetType() != typeof(DateTime))
                {
                    DateTime enteredDate = DateTime.Parse(Supplier_Join_Date.Text);
                    DateTime a = enteredDate;

                    //sqlcon=conn
                    sqlcon = returnConn.getConnection();
                    sqlcon.Open();
                    String query = "INSERT INTO SUPPLIER_TABLE(SUPPLIER_NAME,SUPPLIER_ADDRESS,SUPPLIER_PHONE,SUPPLIER_MAIL,SUPPLIER_JOIN_DATE) VALUES (@SUPPLIER_NAME, @SUPPLIER_ADDRESS, @SUPPLIER_PHONE,@SUPPLIER_MAIL,@SUPPLIER_JOIN_DATE)";

                    SqlCommand command = new SqlCommand(query,sqlcon);
                    command.Parameters.Add("@SUPPLIER_NAME", Supplier_Name.Text);
                    command.Parameters.Add("@SUPPLIER_ADDRESS", Supplier_Address.Text);
                    command.Parameters.Add("@SUPPLIER_PHONE",Convert.ToInt64(Supplier_Phone.Text));
                    command.Parameters.Add("@SUPPLIER_MAIL", Supplier_Mail.Text);
                    command.Parameters.Add("@SUPPLIER_JOIN_DATE", enteredDate);
                    command.ExecuteNonQuery();

                    //databind tekrardan
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM SUPPLIER_TABLE", sqlcon);
                    sqlData.Fill(dtlb);
                    Supplier_Grid.DataSource = dtlb;
                    Supplier_Grid.DataBind();
                }
                else
                {
                    //???
                }
            }
        }
    }
}