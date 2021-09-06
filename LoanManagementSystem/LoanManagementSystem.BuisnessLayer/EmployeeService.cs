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
        // Invoking Constructor
        public EmployeeService()
        {
            try
            {
                repository = new BankEmployeeRepository();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking DeleteCustomerById
        public void DeleteCustomerById(string CUSTOMER_ID, decimal LOAN_ACC_Number)
        {
            try
            {
                repository.DeleteCustomerById(CUSTOMER_ID, LOAN_ACC_Number);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking ViewCustomers
        public List<Customer> ViewCustomers()
        {
            try
            {
                List<Customer> customers = repository.ViewCustomers();
                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking SearchCustomerById
        public Customer SearchCustomerById(string CUSTOMER_ID)
        {
            try
            {
                Customer customer = repository.SearchCustomerById(CUSTOMER_ID);
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking IsLoginBankEmployee
        public bool IsLoginBankEmployee(string EmpId, string EmpPassword)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking ViewPendingCustomers
        public List<PendingCustomers> ViewPendingCustomers()
        {
            try
            {
                List<PendingCustomers> pendingcustomers = repository.ViewPendingCustomers();
                return pendingcustomers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking ViewPendingandRejectedCustomers
        public List<PendingCustomers> ViewPendingandRejectedCustomers()
        {
            try
            {
                List<PendingCustomers> pendingandrejectedcustomers = repository.ViewPendingandRejectedCustomers();
                return pendingandrejectedcustomers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking CheckCriteria
        public bool CheckCriteria(string CUSTOMER_ID)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking LoanApproval
        public void LoanApproval(string CUSTOMER_ID, string EmpId)
        {
            try
            {
                repository.LoanApproval(CUSTOMER_ID, EmpId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking LoanRejection
        public void LoanRejection(string CUSTOMER_ID, string EmpId, decimal LOAN_ACC_Number)
        {
            try
            {
                repository.LoanRejection(CUSTOMER_ID, EmpId, LOAN_ACC_Number);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
