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
        // For Sql Connection
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-DHE93BQG\SQLEXPRESS;Initial Catalog=LoanManagementSystem;Integrated Security=True");
        SqlCommand command = null;

        public bool CheckCriteria(string CUSTOMER_ID)
        {
            try
            {
                bool isEligible = false;
                command = new SqlCommand("CheckCriteria", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                connection.Open(); //open connnection
                command.ExecuteNonQuery();
                SqlDataReader dr = command.ExecuteReader();
                isEligible = dr.HasRows;
                return isEligible;
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

        // For Deleting Customer By:Anuj Garg
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
                
        // To check Employee Login By: Amulya
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

        public void LoanApproval(string CUSTOMER_ID, string EmpId)
        {
            try
            {
                command = new SqlCommand("LoanApproval", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                command.Parameters.AddWithValue("@EmpId", EmpId);
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

        public void LoanRejection(string CUSTOMER_ID, string EmpId, decimal LOAN_ACC_Number)
        {
            try
            {
                command = new SqlCommand("LoanRejection", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                command.Parameters.AddWithValue("@EmpId", EmpId);
                command.Parameters.AddWithValue("@LOAN_ACC_Number", LOAN_ACC_Number);
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

        // To Search Customer By Id By: Arjoo
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
        // To View All the Customers By: Sahithi
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

        public List<PendingCustomers> ViewPendingCustomers()
        {
            try
            {
                List<PendingCustomers> customers = null;
                command = new SqlCommand("ViewPendingCustomers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    customers = new List<PendingCustomers>();
                    while (dr.Read())
                    {
                        customers.Add(new PendingCustomers()
                        {
                            CUSTOMER_ID = dr["CUSTOMER_ID"].ToString(),
                            LOAN_ACC_NUMBER = (decimal)dr["LOAN_ACC_NUMBER"],
                            FIRST_NAME = dr["FIRST_NAME"].ToString(),
                            LAST_NAME = dr["LAST_NAME"].ToString(),
                            LOAN_STATUS=dr["LOAN_STATUS"].ToString()
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
