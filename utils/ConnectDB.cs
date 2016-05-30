using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fitness.utils
{
    class ConnectDB
    {
        public static SqlConnection GetDataConnection(String datasource, String name, String username, String pass)
        {
            String connectionString = "Data Source=" + datasource + ";Initial Catalog=" + name + ";User ID=" + username + ";Password=" + pass;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
