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
		// For SQl Connection
		SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DHE93BQG\SQLEXPRESS;Initial Catalog=LoanManagementSystem;Integrated Security=True");
		SqlCommand command = null;
		// For Adding Customer By:Sonali
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
		// To Check Customer Login By: Sonali
        public bool IsLoginCustomer(string CUSTOMER_ID, string CUSTOMER_PASSWORD)
        {
			try
			{
				bool loginsuccessful = false;
				command = new SqlCommand("IsLoginCustomer", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
				command.Parameters.AddWithValue("@CUSTOMER_PASSWORD", CUSTOMER_PASSWORD);
				connection.Open(); //open connnection
				SqlDataReader dr = command.ExecuteReader();
				loginsuccessful = dr.HasRows;
				return loginsuccessful;
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
		// For Updating Customer By:Hari
        public void UpdateCustomerById(Customer customer)
        {
            try
            {
                command = new SqlCommand("UpdateCustomerById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
				//passing value to query-paramenters
				command.Parameters.AddWithValue("@CUSTOMER_ID", customer.CUSTOMER_ID);
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
		public void ApplyLoan(LoanDetails loandetails)
        {
            try
            {
                command = new SqlCommand("ApplyLoan", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters                
                command.Parameters.AddWithValue("@LOAN_AMOUNT", loandetails.LOAN_AMOUNT);
                command.Parameters.AddWithValue("@CUSTOMER_ID", loandetails.CUSTOMER_ID);
                command.Parameters.AddWithValue("@EmpId", loandetails.EmpId);
                command.Parameters.AddWithValue("@LOAN_TYPE", loandetails.LOAN_TYPE);
                command.Parameters.AddWithValue("@LOAN_APPROVED_DATE", loandetails.LOAN_APPROVED_DATE);
                command.Parameters.AddWithValue("@LOAN_STATUS", loandetails.LOAN_STATUS);
                command.Parameters.AddWithValue("@DISPERSAL_DATE", loandetails.DISPERSAL_DATE);
                command.Parameters.AddWithValue("@INTEREST_RATE", loandetails.INTEREST_RATE);
                command.Parameters.AddWithValue("@TENURE", loandetails.TENURE);
                command.Parameters.AddWithValue("@EMI_START_DATE", loandetails.EMI_START_DATE);
                command.Parameters.AddWithValue("@EMI_END_DATE", loandetails.EMI_END_DATE);
                command.Parameters.AddWithValue("@EMI_AMOUNT", loandetails.EMI_AMOUNT);
                command.Parameters.AddWithValue("@CREDIT_LIMIT", loandetails.CREDIT_LIMIT);
                command.Parameters.AddWithValue("@LAST_UPDATED_CREDIT_DATE", loandetails.LAST_UPDATED_CREDIT_DATE);
                command.Parameters.AddWithValue("@CUSTOMER_ASSET_ID", loandetails.CUSTOMER_ASSET_ID);
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
		public string CheckLoanStatus(string CUSTOMER_ID)
        {
            try
            {
                string status = "";                
                command = new SqlCommand("CheckStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                connection.Open(); //open connnection
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    status = dr["LOAN_STATUS"].ToString();                
                }
                return status;
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
	}
}
