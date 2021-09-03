using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DAL.Repositories
{
    // Customer Interface By: Anuj 
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomerById(Customer customer);
        bool IsLoginCustomer(string CUSTOMER_ID,string CUSTOMER_PASSWORD);
        void ApplyLoan(LoanDetails loandetails);
        string CheckLoanStatus(string CUSTOMER_ID);
    }
}
