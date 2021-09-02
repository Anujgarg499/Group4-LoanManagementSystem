using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DataLayer.Repositories
{
    class Bank_EmployeeRepository : IBank_EmployeeRepository
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DHE93BQG\SQLEXPRESS;Initial Catalog=LoanManagementSystem;Integrated Security=True");
        SqlCommand command = null;
        public void DeleteCustomerById(string CUSTOMER_ID)
        {
            throw new NotImplementedException();
        }

        public bool IsLoanApproved(string CUSTOMER_ID)
        {
            throw new NotImplementedException();
        }

        public bool IsLoginBankEmployee(Bank_Employee bank_Employee)
        {
            throw new NotImplementedException();
        }

        public Customer SearchCustomerById(string CUSTOMER_ID)
        {
            try
            {
                Customer customer = null;
                command = new SqlCommand("SearchCustomerById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                connection.Open(); //open connnection
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    customer = new Customer()
                    {

                        CUSTOMER_ID = dr["CUSTOMER_ID"].ToString(),
                        FIRST_NAME = dr["FIRST_NAME"].ToString(),
                        LAST_NAME = dr["LAST_NAME"].ToString(),
                        ADDRESS = dr["ADDRESS"].ToString(),
                        PAN_NUMBER = dr["PAN_NUMBER"].ToString(),
                        AADHAR_NUMBER = (decimal)dr["AADHAR_NUMBER"],
                        CONTACT_NUMBER = (decimal)dr["CONTACT_NUMBER"],
                        EMAIL = dr["EMAIL"].ToString(),
                        DOB = dr["DOB"].ToString(),
                        CREDIT_LIMIT = (decimal)dr["CREDIT_LIMIT"],
                        LAST_UPDATED_CREDIT_DATE = (DateTime)dr["CREDIT_LIMIT"]

                    };
                }
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Customer> ViewCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
