using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Entities
{
    public class Bank_Employee
    {
        // Getting and Setting Employee Entities Details
        public string EmpId { get; set; } 
        public string EmpName { get; set; }
        public decimal CONTACT_NUMBER { get; set; }
        public string EMAIL { get; set; }
        public string EMP_TYPE { get; set; }
    }
}
