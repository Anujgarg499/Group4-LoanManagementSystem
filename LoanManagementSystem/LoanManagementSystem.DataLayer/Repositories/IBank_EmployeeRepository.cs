using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DataLayer.Repositories
{
    public interface IBank_EmployeeRepository
    {
        bool IsLoginBankEmployee(Bank_Employee bank_Employee);
        List<Customer> ViewCustomers();
        Customer SearchCustomerById(string CUSTOMER_ID);
        void DeleteCustomerById(string CUSTOMER_ID);
        bool IsLoanApproved(string CUSTOMER_ID);
    }
}
