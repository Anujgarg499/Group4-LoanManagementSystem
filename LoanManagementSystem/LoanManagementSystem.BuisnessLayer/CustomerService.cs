using System;
using LoanManagementSystem.DAL.Repositories;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.BAL
{
    public class CustomerService
    {
        CustomerRepository repository = null;
        // Invoking Constructor
        public CustomerService()
        {
            try
            {
                repository = new CustomerRepository();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking Add Customer from DAL
        public void AddCustomer(Customer customer)
        {
            try
            {
                repository.AddCustomer(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking Update Customer from DAL
        public void UpdateCustomerById(Customer customer)
        {
            try
            {
                repository.UpdateCustomerById(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking IsLoginCustomer checking
        public bool IsLoginCustomer(string CUSTOMER_ID, string CUSTOMER_PASSWORD)
        {
            try
            {
                bool check = repository.IsLoginCustomer(CUSTOMER_ID, CUSTOMER_PASSWORD);
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
        // Invoking Apply Loan
        public void ApplyLoan(LoanDetails loandetails)
        {
            try
            {
                repository.ApplyLoan(loandetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Invoking CheckLoanStatus
        public string CheckLoanStatus(string CUSTOMER_ID)
        {
            try
            {
                string loanstatus = repository.CheckLoanStatus(CUSTOMER_ID);
                return loanstatus;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
