using System;
using System.Collections.Generic;
using LoanManagementSystem.BAL;
using LoanManagementSystem.Entities;
using LoanManagementSystem.BAL.Validations;

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
                                            try
                                            {
                                                // Register part implemented By: Anuj Garg
                                                Customer customer = new Customer();
                                                do
                                                {
                                                    Console.Write("Enter Customer Username(Username must be 3 character long can contain[A-Z,a-z,0-9]): ");
                                                    string input = Console.ReadLine();

                                                    if (Validation.ValidateUsername(input))
                                                    {
                                                        customer.CUSTOMER_ID = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid username please try again");
                                                } while (true);
                                                //customer.CUSTOMER_ID = Console.ReadLine();
                                                Console.Write("Enter Customer First Name: ");
                                                customer.FIRST_NAME = Console.ReadLine();
                                                Console.Write("Enter Customer Last Name: ");
                                                customer.LAST_NAME = Console.ReadLine();
                                                do
                                                {
                                                    Console.Write("Enter Password(Password must be 6 digit long can contain[a-z,0-9,@#$%^&+=]): ");
                                                    string input = Console.ReadLine();

                                                    if (Validation.ValidatePassword(input))
                                                    {
                                                        customer.CUSTOMER_PASSWORD = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid password please try again");
                                                } while (true);

                                                Console.Write("Enter Address: ");
                                                customer.ADDRESS = Console.ReadLine();
                                                do
                                                {
                                                    Console.Write("Enter Pan Number(Ex. abcde1234z): ");
                                                    string input = Console.ReadLine();

                                                    if (Validation.ValidatePAN(input))
                                                    {
                                                        customer.PAN_NUMBER = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid PAN please try again");
                                                } while (true);
                                                do
                                                {
                                                    Console.WriteLine("Enter Aadhar Number(Must 12 digit long): ");
                                                    decimal input = decimal.Parse(Console.ReadLine());

                                                    if (Validation.ValidateAadhar(input))
                                                    {
                                                        customer.AADHAR_NUMBER = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid aadhar number please try again");
                                                } while (true);
                                                do
                                                {
                                                    Console.Write("Enter Contact Number(Must have 10 digit length): ");
                                                    decimal input = decimal.Parse(Console.ReadLine());

                                                    if (Validation.ValidateContactNumber(input))
                                                    {
                                                        customer.CONTACT_NUMBER = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid contact number please try again");
                                                } while (true);
                                                do
                                                {
                                                    Console.Write("Enter Email Id: ");
                                                    string input = Console.ReadLine();

                                                    if (Validation.ValidateEmail(input))
                                                    {
                                                        customer.EMAIL = input;
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Invalid email please try again");
                                                } while (true);
                                                Console.WriteLine("Enter Date Of Birth(DD-MM-YYYY): ");
                                                customer.DOB = Console.ReadLine();
                                                customer.CREDIT_LIMIT = 500000;
                                                customer.LAST_UPDATED_CREDIT_DATE = DateTime.Now;
                                                customerservice.AddCustomer(customer);
                                                Console.WriteLine("Customer Registration Successful..");
                                            }catch(Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
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
                                                            try
                                                            {
                                                                // Apply For Loan Part to be implemented here
                                                                LoanDetails loanDetails = new LoanDetails();
                                                                //Console.Write("Enter Customer Username:");
                                                                //loanDetails.CUSTOMER_ID = Console.ReadLine();
                                                                do
                                                                {
                                                                    Console.Write("Enter Customer Username(Username must be 3 character long can contain[A-Z,a-z,0-9]): ");
                                                                    string input = Console.ReadLine();

                                                                    if (Validation.ValidateUsername(input))
                                                                    {
                                                                        loanDetails.CUSTOMER_ID = input;
                                                                        break;
                                                                    }
                                                                    else
                                                                        Console.WriteLine("Invalid username please try again");
                                                                } while (true);
                                                                Console.WriteLine("Enter type of loan(1.Home Loan\n2.Vehicle Loan\n3.Educational Loan)");
                                                                int type = int.Parse(Console.ReadLine());
                                                                switch (type)
                                                                {
                                                                    case 1:
                                                                        loanDetails.LOAN_TYPE = "Home Loan";
                                                                        loanDetails.INTEREST_RATE = 7;
                                                                        break;
                                                                    case 2:
                                                                        loanDetails.LOAN_TYPE = "Vehicle Loan";
                                                                        loanDetails.INTEREST_RATE = 8;
                                                                        break;
                                                                    case 3:
                                                                        loanDetails.LOAN_TYPE = "Educational Loan";
                                                                        loanDetails.INTEREST_RATE = 6;
                                                                        break;

                                                                }
                                                                //loanDetails.LOAN_TYPE = Console.ReadLine();
                                                                Console.Write("Enter Loan Amount:");
                                                                loanDetails.LOAN_AMOUNT = decimal.Parse(Console.ReadLine());
                                                                Console.Write("Enter Tenure:");
                                                                loanDetails.TENURE = decimal.Parse(Console.ReadLine());                                                                
                                                                customerservice.ApplyLoan(loanDetails);
                                                                Console.WriteLine("Loan Application Submitted Sucessfully.");
                                                            }catch(Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                            }
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
                                                            do
                                                            {
                                                                Console.Write("Enter Customer Username(Username must be 3 character long can contain[A-Z,a-z,0-9]): ");
                                                                string input = Console.ReadLine();

                                                                if (Validation.ValidateUsername(input))
                                                                {
                                                                    customer.CUSTOMER_ID = input;
                                                                    break;
                                                                }
                                                                else
                                                                    Console.WriteLine("Invalid username please try again");
                                                            } while (true);
                                                            Console.Write("Enter First Name:");
                                                            customer.FIRST_NAME = Console.ReadLine();
                                                            Console.Write("Enter Last Name:");
                                                            customer.LAST_NAME = Console.ReadLine();
                                                            Console.Write("Enter Address:");
                                                            customer.ADDRESS = Console.ReadLine();                                                                                                                        
                                                            do
                                                            {
                                                                Console.Write("Enter Pan Number(Ex. abcde1234z): ");
                                                                string input = Console.ReadLine();

                                                                if (Validation.ValidatePAN(input))
                                                                {
                                                                    customer.PAN_NUMBER = input;
                                                                    break;
                                                                }
                                                                else
                                                                    Console.WriteLine("Invalid PAN please try again");
                                                            } while (true);
                                                            do
                                                            {
                                                                Console.WriteLine("Enter Aadhar Number(Must 12 digit long): ");
                                                                decimal input = decimal.Parse(Console.ReadLine());

                                                                if (Validation.ValidateAadhar(input))
                                                                {
                                                                    customer.AADHAR_NUMBER = input;
                                                                    break;
                                                                }
                                                                else
                                                                    Console.WriteLine("Invalid aadhar number please try again");
                                                            } while (true);
                                                            do
                                                            {
                                                                Console.Write("Enter Contact Number(Must have 10 digit length): ");
                                                                decimal input = decimal.Parse(Console.ReadLine());

                                                                if (Validation.ValidateContactNumber(input))
                                                                {
                                                                    customer.CONTACT_NUMBER = input;
                                                                    break;
                                                                }
                                                                else
                                                                    Console.WriteLine("Invalid contact number please try again");
                                                            } while (true);
                                                            do
                                                            {
                                                                Console.Write("Enter Email Id: ");
                                                                string input = Console.ReadLine();

                                                                if (Validation.ValidateEmail(input))
                                                                {
                                                                    customer.EMAIL = input;
                                                                    break;
                                                                }
                                                                else
                                                                    Console.WriteLine("Invalid email please try again");
                                                            } while (true);
                                                            Console.Write("Enter Date Of Birth(DD-MM-YYYY): ");
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
                                                    Console.WriteLine("4. Delete Pending Customers");
                                                    Console.WriteLine("5. Exit");
                                                    Console.WriteLine("Enter your choice: ");
                                                    int Customerchoice1 = int.Parse(Console.ReadLine());
                                                    switch (Customerchoice1)
                                                    {
                                                        case 1:
                                                            {
                                                                // Loan Processing Part to be implemented here
                                                                List<PendingCustomers> pendingcustomers = employeeservice.ViewPendingCustomers();
                                                                if (pendingcustomers != null)
                                                                {
                                                                    foreach (var customer in pendingcustomers)
                                                                    {
                                                                        Console.WriteLine($"Customer Username:{customer.CUSTOMER_ID} Loan Account Number:{customer.LOAN_ACC_NUMBER} First Name:{customer.FIRST_NAME} Last Name:{customer.LAST_NAME} Status:{customer.LOAN_STATUS}");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No Customers available.");
                                                                }
                                                                Console.WriteLine("Enter Customer Username: ");
                                                                string CUSTOMER_ID = Console.ReadLine();
                                                                Console.WriteLine("Enter Customer Loan Account Number: ");
                                                                decimal Loanaccount = decimal.Parse(Console.ReadLine());
                                                                Console.WriteLine("Enter Employee Username: ");
                                                                string Emp_Id = Console.ReadLine();
                                                                if (employeeservice.CheckCriteria(CUSTOMER_ID))
                                                                {
                                                                    employeeservice.LoanRejection(CUSTOMER_ID,EmpId,Loanaccount);
                                                                    Console.WriteLine($"After Reviewing Criteria Loan of Customer Username:{CUSTOMER_ID} is Rejected");
                                                                }
                                                                else
                                                                {
                                                                    employeeservice.LoanApproval(CUSTOMER_ID, EmpId);
                                                                    Console.WriteLine($"After Reviewing Criteria Loan of Customer Username{CUSTOMER_ID} is Approved");                                                                    
                                                                }
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
                                                                        Console.WriteLine($"Customer Username:{customer.CUSTOMER_ID} First Name:{customer.FIRST_NAME} Last Name:{customer.LAST_NAME} Address:{customer.ADDRESS} PAN Number:{customer.PAN_NUMBER} AADHAR Number:{customer.AADHAR_NUMBER} Contact Number:{customer.CONTACT_NUMBER} Email:{customer.EMAIL} DOB:{customer.DOB}");
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
