using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase
{
    public class MicrosoftSQL
    {
        //SqlConnection conn = new SqlConnection();
        public static SqlConnection conn = null; 
        public void ConnectionOpen()
        {
            conn = new SqlConnection("Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True");
            conn.Open();
        }

        public void ConnectionClose()
        {
            conn.Close();

        }

    }
}
