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
        protected void Page_Load(object sender, EventArgs e)
        {
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM PRODUCT_TABLE",conn);
                DataTable dtlb = new DataTable();
                sqlData.Fill(dtlb);
                Product_Grid.DataSource = dtlb;
                Product_Grid.DataBind();

            }

        }

        //kayıt butonu
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Product_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Product_Grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}