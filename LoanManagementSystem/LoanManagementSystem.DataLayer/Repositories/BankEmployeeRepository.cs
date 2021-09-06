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

        // For Checking Criteria By: Sahithi
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
                SqlDataReader datareader = command.ExecuteReader();
                isEligible = datareader.HasRows;
                return isEligible;
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

        // For Deleting Customer By:Anuj Garg
        public void DeleteCustomerById(string CUSTOMER_ID, decimal LOAN_ACC_Number)
        {
            try
            {
                command = new SqlCommand("DeleteCustomerById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing value to query-paramenters
                command.Parameters.AddWithValue("@CUSTOMER_ID", CUSTOMER_ID);
                command.Parameters.AddWithValue("@LOAN_ACC_Number", LOAN_ACC_Number);
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
                SqlDataReader datareader = command.ExecuteReader();
                loginsuccessful = datareader.HasRows;
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

        // For Loan Approval By: Arjoo
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // For Loan Rejection By: Anuj Garg
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
            catch (Exception)
            {
                throw;
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
                SqlDataReader datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    datareader.Read();
                    customer = new Customer()
                    {

                        CUSTOMER_ID = datareader["CUSTOMER_ID"].ToString(),
                        FIRST_NAME = datareader["FIRST_NAME"].ToString(),
                        LAST_NAME = datareader["LAST_NAME"].ToString(),
                        ADDRESS = datareader["ADDRESS"].ToString(),
                        PAN_NUMBER = datareader["PAN_NUMBER"].ToString(),
                        AADHAR_NUMBER = (decimal)datareader["AADHAR_NUMBER"],
                        CONTACT_NUMBER = (decimal)datareader["CONTACT_NUMBER"],
                        EMAIL = datareader["EMAIL"].ToString(),
                        DOB = datareader["DOB"].ToString()               

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
                SqlDataReader datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    customers = new List<Customer>();
                    while (datareader.Read())
                    {
                        customers.Add(new Customer()
                        {
                            CUSTOMER_ID = datareader["CUSTOMER_ID"].ToString(),
                            FIRST_NAME = datareader["FIRST_NAME"].ToString(),
                            LAST_NAME = datareader["LAST_NAME"].ToString(),
                            ADDRESS = datareader["ADDRESS"].ToString(),
                            PAN_NUMBER = datareader["PAN_NUMBER"].ToString(),
                            AADHAR_NUMBER = (decimal)datareader["AADHAR_NUMBER"],
                            CONTACT_NUMBER = (decimal)datareader["CONTACT_NUMBER"],
                            EMAIL = datareader["EMAIL"].ToString(),
                            DOB = datareader["DOB"].ToString(),                            
                        });
                    }
                }
                return customers;
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

        // For Viewing Pending Customers Details By: Anuj Garg, Arjoo
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
                SqlDataReader datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    customers = new List<PendingCustomers>();
                    while (datareader.Read())
                    {
                        customers.Add(new PendingCustomers()
                        {
                            CUSTOMER_ID = datareader["CUSTOMER_ID"].ToString(),
                            LOAN_ACC_NUMBER = (decimal)datareader["LOAN_ACC_NUMBER"],
                            FIRST_NAME = datareader["FIRST_NAME"].ToString(),
                            LAST_NAME = datareader["LAST_NAME"].ToString(),
                            LOAN_STATUS= datareader["LOAN_STATUS"].ToString()
                        });
                    }
                }
                return customers;
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

        // For Viewing Pending and Rejected Customers Details By: Sonali,Hari
        public List<PendingCustomers> ViewPendingandRejectedCustomers()
        {
            try
            {
                List<PendingCustomers> customers = null;
                command = new SqlCommand("ViewPendingandRejectedCustomers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    customers = new List<PendingCustomers>();
                    while (datareader.Read())
                    {
                        customers.Add(new PendingCustomers()
                        {
                            CUSTOMER_ID = datareader["CUSTOMER_ID"].ToString(),
                            LOAN_ACC_NUMBER = (decimal)datareader["LOAN_ACC_NUMBER"],
                            FIRST_NAME = datareader["FIRST_NAME"].ToString(),
                            LAST_NAME = datareader["LAST_NAME"].ToString(),
                            LOAN_STATUS = datareader["LOAN_STATUS"].ToString()
                        });
                    }
                }
                return customers;
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
