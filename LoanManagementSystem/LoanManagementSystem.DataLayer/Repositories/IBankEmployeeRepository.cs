using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DAL.Repositories
{
    // Bank Employee Interface By: Arjoo 
    public interface IBankEmployeeRepository
    {
        bool IsLoginBankEmployee(string EmpId,string EmpPassword);
        List<Customer> ViewCustomers();
        Customer SearchCustomerById(string CUSTOMER_ID);
        void DeleteCustomerById(string CUSTOMER_ID);
        bool IsLoanApproved(string CUSTOMER_ID);
    }
}
