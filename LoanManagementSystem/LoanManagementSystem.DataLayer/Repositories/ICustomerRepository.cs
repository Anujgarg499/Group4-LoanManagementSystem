using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomerById(Customer customer);
        bool IsLoginCustomer(Customer customer);
    }
}
