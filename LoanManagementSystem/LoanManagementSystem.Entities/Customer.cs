using System;

namespace LoanManagementSystem.Entities
{
    public class Customer
    {
        // Getting and Setting Customer Entities Details
        public string CUSTOMER_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string CUSTOMER_PASSWORD { get; set; }
        public string ADDRESS { get; set; }
        public string PAN_NUMBER { get; set; }
        public decimal AADHAR_NUMBER { get; set; }
        public decimal CONTACT_NUMBER { get; set; }
        public string EMAIL { get; set; }
        public string DOB { get; set; }
        public decimal CREDIT_LIMIT { get; set; }
        public DateTime LAST_UPDATED_CREDIT_DATE { get; set; }
    }
}
