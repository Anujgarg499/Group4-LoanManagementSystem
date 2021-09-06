using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.DAL.Repositories;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.BAL
{
    public class EmployeeService
    {
        BankEmployeeRepository repository = null;
        public EmployeeService()
        {
            repository = new BankEmployeeRepository();
        }
        public void DeleteCustomerById(string CUSTOMER_ID, decimal LOAN_ACC_Number)
        {
            repository.DeleteCustomerById(CUSTOMER_ID,LOAN_ACC_Number);
        }
        public List<Customer> ViewCustomers()
        {
            List<Customer> customers = repository.ViewCustomers();
            return customers;
        }
        public Customer SearchCustomerById(string CUSTOMER_ID)
        {
            Customer customer =repository.SearchCustomerById(CUSTOMER_ID);
            return customer;
        }
        public bool IsLoginBankEmployee(string EmpId, string EmpPassword)
        {
            bool check = repository.IsLoginBankEmployee(EmpId, EmpPassword);
            if (check == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<PendingCustomers> ViewPendingCustomers()
        {
            List<PendingCustomers> pendingcustomers = repository.ViewPendingCustomers();
            return pendingcustomers;
        }
        public List<PendingCustomers> ViewPendingandRejectedCustomers()
        {
            List<PendingCustomers> pendingandrejectedcustomers = repository.ViewPendingandRejectedCustomers();
            return pendingandrejectedcustomers;
        }
            public bool CheckCriteria(string CUSTOMER_ID)
        {
            bool isEligible = repository.CheckCriteria(CUSTOMER_ID);
            if (isEligible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LoanApproval(string CUSTOMER_ID, string EmpId)
        {
            repository.LoanApproval(CUSTOMER_ID, EmpId);
        }
        public void LoanRejection(string CUSTOMER_ID, string EmpId, decimal LOAN_ACC_Number)
        {
            repository.LoanRejection(CUSTOMER_ID,EmpId,LOAN_ACC_Number);
        }
    }
}
