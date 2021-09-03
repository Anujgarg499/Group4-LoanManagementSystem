using System;
using System.Collections.Generic;
using LoanManagementSystem.BAL;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.UI
{
    class Program
    {
        // Structure of UI By: Anuj Garg
        static void Main(string[] args)
        {
            CustomerService customerservice = new CustomerService();
            EmployeeService employeeservice = new EmployeeService();
            try
            {
                do
                {
                    // Starting of the Application Menu
                    Console.WriteLine("1. Customer");
                    Console.WriteLine("2. Bank Employee");                    
                    Console.WriteLine("3.Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                // This is for Customer Section
                                Console.WriteLine("1. Register Customer");
                                Console.WriteLine("2. Login");                                
                                Console.WriteLine("3. Exit");
                                Console.WriteLine("Enter your choice: ");
                                int Customerchoice = int.Parse(Console.ReadLine());
                                switch (Customerchoice)
                                {
                                    case 1:
                                        {
                                            // Register part implemented By: Anuj Garg
                                            Customer customer = new Customer();
                                            Console.WriteLine("Enter Customer Username: ");
                                            customer.CUSTOMER_ID = Console.ReadLine();
                                            Console.WriteLine("Enter Customer First Name: ");
                                            customer.FIRST_NAME = Console.ReadLine();
                                            Console.WriteLine("Enter Customer Last Name: ");
                                            customer.LAST_NAME = Console.ReadLine();
                                            Console.WriteLine("Enter Password: ");
                                            customer.CUSTOMER_PASSWORD = Console.ReadLine();
                                            Console.WriteLine("Enter Address: ");
                                            customer.ADDRESS = Console.ReadLine();
                                            Console.WriteLine("Enter Pan Number: ");
                                            customer.PAN_NUMBER = Console.ReadLine();
                                            Console.WriteLine("Enter Aadhar Number: ");
                                            customer.AADHAR_NUMBER = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Contact Number: ");
                                            customer.CONTACT_NUMBER = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Email Id: ");
                                            customer.EMAIL = Console.ReadLine();
                                            Console.WriteLine("Enter DOB: ");
                                            customer.DOB = Console.ReadLine();                                            
                                            customer.CREDIT_LIMIT = 500000;
                                            customer.LAST_UPDATED_CREDIT_DATE = DateTime.Now;
                                            customerservice.AddCustomer(customer);
                                            Console.WriteLine("Customer Registration Successful..");
                                        }
                                        break;
                                    case 2:
                                        {
                                            // After Login Section
                                            Console.WriteLine("Enter Customer Username: ");
                                            string CUSTOMER_ID= Console.ReadLine();
                                            Console.WriteLine("Enter Password: ");
                                            string CUSTOMER_PASSWORD = Console.ReadLine();
                                            bool checklogin = customerservice.IsLoginCustomer(CUSTOMER_ID,CUSTOMER_PASSWORD);
                                            if (checklogin == true)
                                            {                                               
                                                Console.WriteLine("1. Apply For Loan");
                                                Console.WriteLine("2. Check Status");
                                                Console.WriteLine("3. Update Customer Details");
                                                Console.WriteLine("4. Exit");
                                                Console.WriteLine("Enter your choice: ");
                                                int Customerchoice1 = int.Parse(Console.ReadLine());
                                                switch (Customerchoice1)
                                                {
                                                    case 1:
                                                        {
                                                            // Apply For Loan Part to be implemented here
                                                            LoanDetails loanDetails = new LoanDetails();
                                                            Console.Write("Enter Customer Username:");
                                                            loanDetails.CUSTOMER_ID = Console.ReadLine();
                                                            Console.WriteLine("Enter type of loan(Home Loan, Vehicle Loan, Educational Loan)");
                                                            loanDetails.LOAN_TYPE = Console.ReadLine();
                                                            Console.Write("Enter Loan Amount:");
                                                            loanDetails.LOAN_AMOUNT = decimal.Parse(Console.ReadLine());
                                                            Console.Write("Enter Tenure:");
                                                            loanDetails.TENURE = decimal.Parse(Console.ReadLine());
                                                            loanDetails.EmpId = "Akash35";
                                                            loanDetails.LOAN_APPROVED_DATE = DateTime.Now;
                                                            loanDetails.LOAN_STATUS = "Pending";
                                                            loanDetails.DISPERSAL_DATE = DateTime.Now;
                                                            loanDetails.INTEREST_RATE = 7;
                                                            loanDetails.EMI_START_DATE = DateTime.Now;
                                                            loanDetails.EMI_END_DATE = DateTime.Now;
                                                            loanDetails.EMI_AMOUNT = 1500;
                                                            loanDetails.CREDIT_LIMIT = 200000;
                                                            loanDetails.LAST_UPDATED_CREDIT_DATE = DateTime.Now;
                                                            loanDetails.CUSTOMER_ASSET_ID = 3;
                                                            customerservice.ApplyLoan(loanDetails);
                                                            Console.WriteLine("Loan Application Submitted Sucessfully.");
                                                        }
                                                        break;
                                                    case 2:
                                                        {
                                                            // Check Status Part
                                                            Console.WriteLine("Enter Customer Username: ");
                                                            string customerid = Console.ReadLine();
                                                            string status = customerservice.CheckLoanStatus(CUSTOMER_ID);
                                                            Console.WriteLine($"Loan Status is : {status}");
                                                        }
                                                        break;
                                                    case 3:
                                                        {
                                                            // Update Customer Part By: Arjoo                                                          
                                                            Customer customer = new Customer();
                                                            //getting values from user
                                                            Console.WriteLine("Enter Customer Username: ");
                                                            customer.CUSTOMER_ID = Console.ReadLine();
                                                            Console.Write("Enter First Name:");
                                                            customer.FIRST_NAME = Console.ReadLine();
                                                            Console.Write("Enter Last Name:");
                                                            customer.LAST_NAME = Console.ReadLine();
                                                            Console.Write("Enter Address:");
                                                            customer.ADDRESS = Console.ReadLine();
                                                            Console.Write("Enter PAN Number:");
                                                            customer.PAN_NUMBER = Console.ReadLine();
                                                            Console.Write("Enter Aadhar Number:");
                                                            customer.AADHAR_NUMBER = decimal.Parse(Console.ReadLine());
                                                            Console.Write("Enter Contact Number:");
                                                            customer.CONTACT_NUMBER = decimal.Parse(Console.ReadLine());
                                                            Console.Write("Enter Email:");
                                                            customer.EMAIL = Console.ReadLine();
                                                            Console.Write("Enter Date Of Birth:");
                                                            customer.DOB = Console.ReadLine();
                                                            customerservice.UpdateCustomerById(customer);
                                                            Console.WriteLine("Customer Details Updated Successfully.");
                                                        }
                                                        break;
                                                    case 4:
                                                        {
                                                            Environment.Exit(0); //exit application
                                                        }
                                                        break;
                                                    default:
                                                        {
                                                            Console.WriteLine("Invalid Choice");
                                                        }
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Login Failed.");
                                            }
                                        }
                                        break;
                                      case 3:
                                        {
                                            Environment.Exit(0); //exit application
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid Choice");
                                        }
                                        break;
                                }
                            }
                            break;
                        case 2:
                            {
                                // This is for Employee Section
                                Console.WriteLine("1. Login");
                                Console.WriteLine("2. Exit");                                
                                Console.WriteLine("Enter your choice: ");
                                int Employeechoice = int.Parse(Console.ReadLine());
                                switch (Employeechoice)
                                {
                                    case 1:
                                        {
                                            // After Login Section
                                            Console.WriteLine("Enter Employee Username: ");
                                            string EmpId = Console.ReadLine();
                                            Console.WriteLine("Enter Password: ");
                                            string EmpPassword = Console.ReadLine();
                                            bool checklogin = employeeservice.IsLoginBankEmployee(EmpId,EmpPassword);
                                            if (checklogin == true)
                                            {
                                                do
                                                {
                                                    Console.WriteLine("1. Loan Processing ");
                                                    Console.WriteLine("2. View Customers");                                                    
                                                    Console.WriteLine("3. Search Customer");
                                                    Console.WriteLine("4. Delete Customers");
                                                    Console.WriteLine("5. Exit");
                                                    Console.WriteLine("Enter your choice: ");
                                                    int Customerchoice1 = int.Parse(Console.ReadLine());
                                                    switch (Customerchoice1)
                                                    {
                                                        case 1:
                                                            {
                                                                // Loan Processing Part to be implemented here
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                // View Customers part By: Anuj Garg
                                                                List<Customer> customers = employeeservice.ViewCustomers();
                                                                if (customers != null)
                                                                {
                                                                    foreach (var customer in customers)
                                                                    {
                                                                        Console.WriteLine($"Customer Username:{customer.CUSTOMER_ID} First Name:{customer.FIRST_NAME} Last Name:{customer.LAST_NAME} {customer.CUSTOMER_PASSWORD} Address:{customer.ADDRESS} PAN Number:{customer.PAN_NUMBER} AADHAR Number:{customer.AADHAR_NUMBER} Contact Number:{customer.CONTACT_NUMBER} Email:{customer.EMAIL} DOB:{customer.DOB}");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No Customers available.");
                                                                }
                                                            }
                                                            break;                                                        
                                                        case 3:
                                                            {
                                                                // Search Customer Part By: Arjoo
                                                                Console.WriteLine("Enter Customer Username to be Searched:");
                                                                string CUSTOMER_ID = Console.ReadLine();
                                                                Customer customer = employeeservice.SearchCustomerById(CUSTOMER_ID);
                                                                if (customer != null)
                                                                {
                                                                    Console.WriteLine($"First Name:{customer.FIRST_NAME} Last Name:{customer.LAST_NAME} Address:{customer.ADDRESS} PAN Number:{customer.PAN_NUMBER} Aadhar Number:{customer.AADHAR_NUMBER} Contact Number:{customer.CONTACT_NUMBER} Email:{customer.EMAIL} DOB:{customer.DOB}");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Invalid User Name");
                                                                }
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                // Delete Customer Part By: Anuj Garg
                                                                Console.WriteLine("Enter Customer Username: ");
                                                                string CUSTOMER_ID = Console.ReadLine();
                                                                employeeservice.DeleteCustomerById(CUSTOMER_ID);
                                                                Console.WriteLine("Employee Deleted Successfully.");
                                                            }
                                                            break;
                                                        case 5:
                                                            {
                                                                Environment.Exit(0); //exit application
                                                            }
                                                            break;
                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid Choice");
                                                            }
                                                            break;
                                                    }

                                                } while (true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Login Failed.");
                                            }
                                        }
                                        break;                                    
                                    case 2:
                                        {
                                            Environment.Exit(0); //exit application
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid Choice");
                                        }
                                        break;
                                }
                            }
                            break;                        
                        case 3:
                            {
                                Environment.Exit(0); //exit application
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                            }
                            break;
                    }
                } while (true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
