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
        void DeleteCustomerById(string CUSTOMER_ID, decimal LOAN_ACC_Number);
        void LoanApproval(string CUSTOMER_ID,string EmpId);
        void LoanRejection(string CUSTOMER_ID, string EmpId,decimal LOAN_ACC_Number);
        List<PendingCustomers> ViewPendingCustomers();
        List<PendingCustomers> ViewPendingandRejectedCustomers();
        bool CheckCriteria(string CUSTOMER_ID);
    }
}
