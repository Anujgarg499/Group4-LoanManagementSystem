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
    }
}
