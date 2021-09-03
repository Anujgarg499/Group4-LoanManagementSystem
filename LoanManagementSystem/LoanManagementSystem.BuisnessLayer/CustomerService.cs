using System;
using LoanManagementSystem.DAL.Repositories;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.BAL
{
    public class CustomerService
    {
        CustomerRepository repository = null;
        public CustomerService()
        {
            repository = new CustomerRepository();
        }
        // Invoking Add Customer from DAL
        public void AddCustomer(Customer customer)
        {
            repository.AddCustomer(customer);
        }
        // Invoking Update Customer from DAL
        public void UpdateCustomerById(Customer customer)
        {
            repository.UpdateCustomerById(customer);
        }
        // Invoking IsLoginCustomer checking
        public bool IsLoginCustomer(string CUSTOMER_ID, string CUSTOMER_PASSWORD)
        {
            bool check = repository.IsLoginCustomer(CUSTOMER_ID,CUSTOMER_PASSWORD);
            if (check == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Invoking Apply Loan
        public void ApplyLoan(LoanDetails loandetails)
        {
            repository.ApplyLoan(loandetails);
        }
        public string CheckLoanStatus(string CUSTOMER_ID)
        {
            string loanstatus = repository.CheckLoanStatus(CUSTOMER_ID);
            return loanstatus;
        }
    }
}
