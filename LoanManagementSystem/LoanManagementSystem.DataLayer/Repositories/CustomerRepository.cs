using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
		SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DHE93BQG\SQLEXPRESS;Initial Catalog=LoanManagementSystem;Integrated Security=True");
		SqlCommand command = null;
		public void AddCustomer(Customer customer)
        {
			try
			{
				command = new SqlCommand("AddCustomer", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", customer.CUSTOMER_ID);
				command.Parameters.AddWithValue("@FIRST_NAME", customer.FIRST_NAME);
				command.Parameters.AddWithValue("@LAST_NAME", customer.LAST_NAME);
                command.Parameters.AddWithValue("@CUSTOMER_PASSWORD", customer.CUSTOMER_PASSWORD);
                command.Parameters.AddWithValue("@ADDRESS", customer.ADDRESS);
				command.Parameters.AddWithValue("@PAN_NUMBER", customer.PAN_NUMBER);
				command.Parameters.AddWithValue("@AADHAR_NUMBER", customer.AADHAR_NUMBER);
				command.Parameters.AddWithValue("@CONTACT_NUMBER", customer.CONTACT_NUMBER);
				command.Parameters.AddWithValue("@EMAIL", customer.EMAIL);
				command.Parameters.AddWithValue("@DOB", customer.DOB);
                command.Parameters.AddWithValue("@CREDIT_LIMIT", customer.CREDIT_LIMIT);
                command.Parameters.AddWithValue("@LAST_UPDATED_CREDIT_DATE", customer.LAST_UPDATED_CREDIT_DATE);
                connection.Open(); //open connnection
				command.ExecuteNonQuery();
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

        public bool IsLoginCustomer(string CUSTOMER_ID, string CUSTOMER_PASSWORD)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerById(Customer customer)
        {
            try
            {
                command = new SqlCommand("UpdateCustomer", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@FIRST_NAME", customer.FIRST_NAME);
                command.Parameters.AddWithValue("@LAST_NAME", customer.LAST_NAME);
                command.Parameters.AddWithValue("@ADDRESS", customer.ADDRESS);
                command.Parameters.AddWithValue("@PAN_NUMBER", customer.PAN_NUMBER);
                command.Parameters.AddWithValue("@AADHAR_NUMBER", customer.AADHAR_NUMBER);
                command.Parameters.AddWithValue("@CONTACT_NUMBER", customer.CONTACT_NUMBER);
                command.Parameters.AddWithValue("@EMAIL", customer.EMAIL);
                command.Parameters.AddWithValue("@DOB", customer.DOB);                
                connection.Open(); //open connnection
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
