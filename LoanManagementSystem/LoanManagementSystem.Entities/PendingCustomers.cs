using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Entities
{
    public class PendingCustomers
    {
        public string CUSTOMER_ID { get; set; }
        public decimal LOAN_ACC_NUMBER { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string LOAN_STATUS { get; set; }
    }
}
