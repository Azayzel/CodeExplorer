using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CustomerAndOrder
    {
        public int ORDER_ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int ORDER_TOTAL { get; set; }
        public DateTime ORDER_TIMESTAMP { get; set; }
        public int CUST_CUSTOMER_ID { get; set; }
        public string CUST_FIRST_NAME { get; set; }
        public string CUST_LAST_NAME { get; set; }
        public string CUST_STREET_ADDRESS1 { get; set; }
        public string CUST_STREET_ADDRESS2 { get; set; }
        public string CUST_CITY { get; set; }
        public string CUST_STATE { get; set; }
        public string CUST_POSTAL_CODE { get; set; }
        public string PHONE_NUMBER1 { get; set; }
        public string PHONE_NUMBER2 { get; set; }
        public int CREDIT_LIMIT { get; set; }
        public string CUST_EMAIL { get; set; }
    }
}
