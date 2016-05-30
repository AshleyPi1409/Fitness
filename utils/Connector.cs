using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fitness.utils
{
    class Connector
    {
        public static SqlConnection getConnection()
        {
            String data= "ASHLEY-PC\\SQLEXPRESS";
            String name = "FitnessManager";
            String user = "sa";
            String pass = "123456";

            return ConnectDB.GetDataConnection(data,name,user,pass);
        }
    }
}
