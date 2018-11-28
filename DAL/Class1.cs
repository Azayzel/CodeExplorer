using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Oracle.DataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DAL
    {

        public class CustomerRepository
        {
            public static string oradb = "Data Source=(DESCRIPTION="
                 + "(ADDRESS=(PROTOCOL=TCP)(HOST=ORASRVR)(PORT=1521))"
                 + "(CONNECT_DATA=(SERVICE_NAME=ORCL)));"
                 + "User Id=JOSH;Password=T3ch@dmin;";

            /// <summary>
            /// Get a list of Customers from Db
            /// </summary>
            public static void GetCustomers()
            {
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();

                string sql = " select d* from customers";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var obj = dr.GetValue(1);

                    Console.WriteLine(obj.ToString());
                }
            }

        }
    }

}
