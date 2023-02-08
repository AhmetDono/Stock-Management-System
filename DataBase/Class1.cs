using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    public class MicrosoftSQL
    {
        public SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "#your database key";
            return conn;
        }

        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True");
            baglan.Open();
            return baglan;
        }

        public SqlConnection baglantı_kes()
        {
            SqlConnection baglan_kes = new SqlConnection("Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True");
            baglan_kes.Close();
            return baglan_kes;
        }

    }

}
