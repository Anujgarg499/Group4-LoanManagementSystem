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
        public void DeleteCustomerById(string CUSTOMER_ID)
        {
            repository.DeleteCustomerById(CUSTOMER_ID);
        }
        public List<Customer> ViewCustomers()
        {
            List<Customer> customers = repository.ViewCustomers();
            return customers;
        }
    }
}
