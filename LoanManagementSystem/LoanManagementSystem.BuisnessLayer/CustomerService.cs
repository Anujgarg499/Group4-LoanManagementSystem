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
    }
}
