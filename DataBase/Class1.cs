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
            conn.ConnectionString = "Data Source=LAPTOP-0A9SGIVO\\SQLEXPRESS;Initial Catalog='Stock Management Systems';Integrated Security=True";
            return conn;
        }

    }

}
