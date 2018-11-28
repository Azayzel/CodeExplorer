using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Utilities
{
    public class DbActions
    {
        /// <summary>
        /// Get All Customers in Db
        /// </summary>
        public static void GetCustomers()
        {
            DAL.CustomerRepository.GetCustomers();
        }

        /// <summary>
        /// Access DAL and retrieve Customer And Order Information from supplied days ago
        /// Defaults to 30 days ago
        /// </summary>
        /// <param name="daysAgo"></param>
        /// <returns></returns>
        public static List<CustomerAndOrder> GetPreviousOrders(string daysAgo = "30")
        {
            List<CustomerAndOrder> custAndOrders = DAL.CustomerRepository.GetPreviousOrders(daysAgo);
            return custAndOrders;
        }
    }
}
