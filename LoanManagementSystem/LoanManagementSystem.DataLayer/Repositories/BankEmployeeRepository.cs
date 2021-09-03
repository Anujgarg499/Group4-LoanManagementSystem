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
    public class BankEmployeeRepository : IBankEmployeeRepository
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DHE93BQG\SQLEXPRESS;Initial Catalog=LoanManagementSystem;Integrated Security=True");
        SqlCommand command = null;
        public void DeleteCustomerById(string CUSTOMER_ID)
        {
            try
            {
                command = new SqlCommand("DeleteCustomerById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                connection.Open(); //open connnection
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool IsLoanApproved(string CUSTOMER_ID)
        {
            throw new NotImplementedException();
        }
        public bool IsLoginBankEmployee(string EmpId, string EmpPassword)
        {
            try
            {
                bool loginsuccessful = false;
                command = new SqlCommand("IsLoginEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@EmpId", EmpId);
                command.Parameters.AddWithValue("@EmpPassword", EmpPassword);
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
                        DOB = dr["DOB"].ToString()               

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
            try
            {
                List<Customer> customers = null;
                command = new SqlCommand("ViewCustomers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                }; 
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    customers = new List<Customer>();
                    while (dr.Read())
                    {
                        customers.Add(new Customer()
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
                        });
                    }
                }
                return customers;
            }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
{
    connection.Close();
}
        }
    }
}
