using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Entities
{
    // Loan Details Entity By: Arjoo
    public class LoanDetails
    {
        public decimal LOAN_ACC_NUMBER { get; set; }
        public decimal LOAN_AMOUNT { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string EmpId { get; set; }
        public string LOAN_TYPE { get; set; }
        public DateTime LOAN_APPROVED_DATE { get; set; }
        public string LOAN_STATUS { get; set; }
        public DateTime DISPERSAL_DATE { get; set; }
        public decimal INTEREST_RATE { get; set; }
        public decimal TENURE { get; set; }
        public DateTime EMI_START_DATE { get; set; }
        public DateTime EMI_END_DATE { get; set; }
        public decimal EMI_AMOUNT { get; set; }
        public decimal CREDIT_LIMIT { get; set; }
        public DateTime LAST_UPDATED_CREDIT_DATE { get; set; }
        public decimal CUSTOMER_ASSET_ID { get; set; }
    }
}
