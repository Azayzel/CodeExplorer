using DAL.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerRepository
    {
        public static string oradb = "Data Source=localhost:1521;Persist Security Info=True;User ID = JOSH; Password=T3ch@dmin;";

        /// <summary>
        /// Get a list of Customers from Db
        /// </summary>
        public static void GetCustomers()
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            string sql = " select * from DEMO_Customers";
            OracleCommand cmd = new OracleCommand(sql, conn)
            {
                CommandType = System.Data.CommandType.Text
            };
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var obj = dr.GetValue(1);

                Console.WriteLine(obj.ToString());
            }
        }

        /// <summary>
        /// Get Order and Customer Data from supplied date to now
        /// </summary>
        /// <param name="daysAgo"></param>
        public static List<CustomerAndOrder> GetPreviousOrders(string daysAgo)
        {
           

                 OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            // Get All Properties and rename Customer_ID from Customer table to avoid duplicates for C# Model
            string sqlQuery = String.Format(@" SELECT DEMO_Orders.ORDER_ID, DEMO_Orders.CUSTOMER_ID,DEMO_Orders.ORDER_TOTAL, DEMO_Orders.ORDER_TIMESTAMP, DEMO_CUSTOMERS.CUSTOMER_ID AS CUST_CUSTOMER_ID, 
                                                      DEMO_CUSTOMERS.CUST_FIRST_NAME, DEMO_CUSTOMERS.CUST_LAST_NAME, DEMO_CUSTOMERS.CUST_STREET_ADDRESS1, DEMO_CUSTOMERS.CUST_STREET_ADDRESS2, 
                                                      DEMO_CUSTOMERS.CUST_CITY, DEMO_CUSTOMERS.CUST_STATE, DEMO_CUSTOMERS.CUST_POSTAL_CODE, DEMO_CUSTOMERS.PHONE_NUMBER1,DEMO_CUSTOMERS.PHONE_NUMBER2, 
                                                      DEMO_CUSTOMERS.CREDIT_LIMIT, DEMO_CUSTOMERS.CUST_EMAIL
                                                FROM DEMO_Orders
                                                INNER JOIN DEMO_Customers ON DEMO_Orders.Customer_ID=DEMO_Customers.Customer_ID
                                                Where ORDER_TIMESTAMP > ((SYSDATE -{0}))"
                                        , daysAgo);

            OracleCommand cmd = new OracleCommand(sqlQuery, conn)
            {
                CommandType = System.Data.CommandType.Text
            };
            //OracleDataReader dr = cmd.ExecuteReader();
            using(OracleDataReader dr = cmd.ExecuteReader())
            {
                List<CustomerAndOrder> custAndOrders = DataReaderMapToList<CustomerAndOrder>(dr);
                return custAndOrders;
            }
           
        }

        /// <summary>
        /// Reader Data from DataReader and Map to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static List<T> DataReaderMapToList<T>(OracleDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj,  dr[prop.Name], null);

                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message + e.StackTrace + e.InnerException);
                        }
                    }
                    list.Add(obj);
                }
                return list;
        }
    }
}
