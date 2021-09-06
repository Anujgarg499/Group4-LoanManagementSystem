using System;
using System.Collections.Generic;
using LoanManagementSystem.BAL;
using LoanManagementSystem.Entities;
using LoanManagementSystem.BAL.Validations;
using System.Data.SqlClient;

namespace LoanManagementSystem.UI
{
    class Program
    {
        // Implementation of UI By: Anuj Garg,Arjoo
        static void Main(string[] args)
        {
            CustomerService customerservice = new CustomerService();
            EmployeeService employeeservice = new EmployeeService();
            try
            {
                do
                {
                    // Start of the Application
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("                   MAIN MENU                                    ");
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("1. Customer");
                    Console.WriteLine("2. Bank Employee");
                    Console.WriteLine("3.Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            {
                                // Customer Section
                                Console.WriteLine();
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("                   CUSTOMER MENU                                ");
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("1. Register Customer");
                                Console.WriteLine("2. Login");
                                Console.WriteLine("3. Exit");
                                Console.Write("Enter your choice: ");
                                int Customerchoice = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                switch (Customerchoice)
                                {
                                    case 1:
                                        {
                                            // For Registring Customer
                                            try
                                            {
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
                                                    Console.Write("Enter Aadhar Number(Must 12 digit long): ");
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
                                                    Console.Write("Enter Email Id(Ex. example@gmail.com): ");
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
                                                customer.CREDIT_LIMIT = 500000;
                                                customer.LAST_UPDATED_CREDIT_DATE = DateTime.Now;
                                                customerservice.AddCustomer(customer);
                                                Console.WriteLine("Customer Registration Successful..");
                                                Console.WriteLine();
                                            }
                                            catch (SqlException exception)
                                            {
                                                Console.WriteLine("The Customer with this Customer Username is already present. Try with different customerId");
                                            }
                                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                                        }
                                        break;
                                    case 2:
                                        {
                                            // Login Part of Customer
                                            Console.Write("Enter Customer Username: ");
                                            string CUSTOMER_ID = Console.ReadLine();
                                            Console.Write("Enter Password: ");
                                            string CUSTOMER_PASSWORD = Console.ReadLine();
                                            bool checklogin = customerservice.IsLoginCustomer(CUSTOMER_ID, CUSTOMER_PASSWORD);
                                            if (checklogin == true)
                                            {
                                                do
                                                {
                                                    Console.WriteLine("Customer Login Successful.");
                                                    Console.WriteLine();
                                                    Console.WriteLine("1. Apply For Loan");
                                                    Console.WriteLine("2. Check Status");
                                                    Console.WriteLine("3. Update Customer Details");
                                                    Console.WriteLine("4. Exit");
                                                    Console.Write("Enter your choice: ");
                                                    int Customerchoice1 = int.Parse(Console.ReadLine());
                                                    Console.WriteLine();
                                                    switch (Customerchoice1)
                                                    {
                                                        case 1:
                                                            {
                                                                // Apply for Loan Section
                                                                try
                                                                {
                                                                    LoanDetails loanDetails = new LoanDetails();
                                                                    loanDetails.CUSTOMER_ID = CUSTOMER_ID;
                                                                    Console.WriteLine("Select type of loan\n1.Home Loan\n2.Vehicle Loan\n3.Educational Loan");
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
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Choice");
                                                                            }
                                                                            break;
                                                                    }
                                                                    Console.Write("Enter Loan Amount:");
                                                                    loanDetails.LOAN_AMOUNT = decimal.Parse(Console.ReadLine());
                                                                    Console.Write("Enter Tenure:");
                                                                    loanDetails.TENURE = decimal.Parse(Console.ReadLine());
                                                                    customerservice.ApplyLoan(loanDetails);
                                                                    Console.WriteLine("Loan Application Submitted Sucessfully.");
                                                                    Console.WriteLine();
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while submitting Loan Application.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                // Check For Loan Status
                                                                try
                                                                {
                                                                    string status = customerservice.CheckLoanStatus(CUSTOMER_ID);
                                                                    Console.WriteLine($"Loan Status is : {status}");
                                                                    Console.WriteLine();
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Checking Loan Status.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 3:
                                                            {
                                                                // Updating Customer Details Section
                                                                try
                                                                {
                                                                    Customer customer = new Customer();
                                                                    customer.CUSTOMER_ID = CUSTOMER_ID;
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
                                                                        Console.Write("Enter Aadhar Number(Must 12 digit long): ");
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
                                                                        Console.Write("Enter Email Id(Ex. example@gmail.com): ");
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
                                                                    Console.WriteLine();
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Updating Customer Details.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                Environment.Exit(0);
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
                                                Console.WriteLine();
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            Environment.Exit(0);
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
                                // Employee Section
                                Console.WriteLine();
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("                   EMPLOYEE MENU                                ");
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("1. Login");
                                Console.WriteLine("2. Exit");
                                Console.Write("Enter your choice: ");
                                int Employeechoice = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                switch (Employeechoice)
                                {
                                    case 1:
                                        {
                                            // Employee Login 
                                            Console.WriteLine();
                                            Console.Write("Enter Employee Username: ");
                                            string EmpId = Console.ReadLine();
                                            Console.Write("Enter Password: ");
                                            string EmpPassword = Console.ReadLine();
                                            bool checklogin = employeeservice.IsLoginBankEmployee(EmpId, EmpPassword);
                                            if (checklogin == true)
                                            {
                                                Console.WriteLine("Employee Login Successful.");
                                                do
                                                {
                                                    // Employee Menu after Login
                                                    Console.WriteLine();
                                                    Console.WriteLine("1. Loan Processing ");
                                                    Console.WriteLine("2. View Customers");
                                                    Console.WriteLine("3. Search Customer");
                                                    Console.WriteLine("4. Delete Customers");
                                                    Console.WriteLine("5. Exit");
                                                    Console.Write("Enter your choice: ");
                                                    int Customerchoice1 = int.Parse(Console.ReadLine());
                                                    Console.WriteLine();
                                                    switch (Customerchoice1)
                                                    {
                                                        case 1:
                                                            {
                                                                // Loan Processing Section
                                                                try
                                                                {
                                                                    List<PendingCustomers> pendingcustomers = employeeservice.ViewPendingCustomers();
                                                                    if (pendingcustomers != null)
                                                                    {
                                                                        foreach (var customer in pendingcustomers)
                                                                        {
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                            Console.WriteLine($"Customer Username:{customer.CUSTOMER_ID}\nLoan Account Number:{customer.LOAN_ACC_NUMBER}\nFirst Name:{customer.FIRST_NAME}\nLast Name:{customer.LAST_NAME}\nStatus:{customer.LOAN_STATUS}");
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("No Customers available.");
                                                                        break;
                                                                    }
                                                                    Console.Write("Enter Customer Username: ");
                                                                    string CUSTOMER_ID = Console.ReadLine();
                                                                    Console.Write("Enter Customer Loan Account Number: ");
                                                                    decimal Loanaccount = decimal.Parse(Console.ReadLine());
                                                                    if (employeeservice.CheckCriteria(CUSTOMER_ID))
                                                                    {
                                                                        employeeservice.LoanRejection(CUSTOMER_ID, EmpId, Loanaccount);
                                                                        Console.WriteLine($"After Reviewing Criteria Loan of Customer Username:{CUSTOMER_ID} is Rejected");
                                                                        Console.WriteLine();
                                                                    }
                                                                    else
                                                                    {
                                                                        employeeservice.LoanApproval(CUSTOMER_ID, EmpId);
                                                                        Console.WriteLine($"After Reviewing Criteria Loan of Customer Username:{CUSTOMER_ID} is Approved");
                                                                        Console.WriteLine();
                                                                    }
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Processing Customer Loan.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 2:
                                                            {
                                                                // View Customer Section
                                                                try
                                                                {
                                                                    List<Customer> customers = employeeservice.ViewCustomers();
                                                                    if (customers != null)
                                                                    {
                                                                        foreach (var customer in customers)
                                                                        {
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                            Console.WriteLine($"Customer Username:{customer.CUSTOMER_ID}\nFirst Name:{customer.FIRST_NAME}\nLast Name:{customer.LAST_NAME}\nAddress:{customer.ADDRESS}\nPAN Number:{customer.PAN_NUMBER}\nAADHAR Number:{customer.AADHAR_NUMBER}\nContact Number:{customer.CONTACT_NUMBER}\nEmail:{customer.EMAIL}\nDOB:{customer.DOB}");
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("No Customers available.");
                                                                    }
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Viewing Customer Details.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 3:
                                                            {
                                                                // Search By Customer Username Section
                                                                try
                                                                {
                                                                    Console.Write("Enter Customer Username to be Searched:");
                                                                    string CUSTOMER_ID = Console.ReadLine();
                                                                    Console.WriteLine();
                                                                    Customer customer = employeeservice.SearchCustomerById(CUSTOMER_ID);
                                                                    if (customer != null)
                                                                    {
                                                                        Console.WriteLine("----------------------------------------------------------------");
                                                                        Console.WriteLine($"First Name:{customer.FIRST_NAME}\nLast Name:{customer.LAST_NAME}\nAddress:{customer.ADDRESS}\nPAN Number:{customer.PAN_NUMBER}\nAadhar Number:{customer.AADHAR_NUMBER}\nContact Number:{customer.CONTACT_NUMBER}\nEmail:{customer.EMAIL}\nDOB:{customer.DOB}");
                                                                        Console.WriteLine("----------------------------------------------------------------");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Invalid User Name");
                                                                    }
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Searching Customer Details.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 4:
                                                            {
                                                                // Deleting Customer Section
                                                                try
                                                                {
                                                                    List<PendingCustomers> pendingcustomers = employeeservice.ViewPendingandRejectedCustomers();
                                                                    if (pendingcustomers != null)
                                                                    {
                                                                        foreach (var customer1 in pendingcustomers)
                                                                        {
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                            Console.WriteLine($"Customer Username:{customer1.CUSTOMER_ID}\nLoan Account Number:{customer1.LOAN_ACC_NUMBER}\nFirst Name:{customer1.FIRST_NAME}\nLast Name:{customer1.LAST_NAME}\nStatus:{customer1.LOAN_STATUS}");
                                                                            Console.WriteLine("----------------------------------------------------------------");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("No Customers available.");
                                                                        break;
                                                                    }
                                                                    Console.Write("Enter Customer Username: ");
                                                                    string CUSTOMER_ID = Console.ReadLine();
                                                                    Console.Write("Enter Customer Loan Account Number: ");
                                                                    decimal Loanaccount = decimal.Parse(Console.ReadLine());
                                                                    Customer customer = employeeservice.SearchCustomerById(CUSTOMER_ID);
                                                                    if (customer != null)
                                                                    {
                                                                        employeeservice.DeleteCustomerById(CUSTOMER_ID, Loanaccount);
                                                                        Console.WriteLine("Customer Deleted Successfully.");
                                                                        Console.WriteLine();
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Invalid Customer Username.");
                                                                    }
                                                                }
                                                                catch (SqlException exception)
                                                                {
                                                                    Console.WriteLine("Something went wrong while Deleting Customer.");
                                                                }
                                                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                                                            }
                                                            break;
                                                        case 5:
                                                            {
                                                                Environment.Exit(0);
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
                                                Console.WriteLine();
                                            }
                                        }
                                        break;
                                    case 2:
                                        {
                                            Environment.Exit(0);
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
                                Environment.Exit(0);
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
