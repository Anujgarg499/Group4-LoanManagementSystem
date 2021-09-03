using System;
using LoanManagementSystem.BAL;
using LoanManagementSystem.Entities;

namespace LoanManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService service = new CustomerService();
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
                                            // Register part to be implemented here
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
                                            Console.WriteLine("Enter Loan Amount: ");
                                            customer.CREDIT_LIMIT = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Tenure Date: ");
                                            customer.LAST_UPDATED_CREDIT_DATE = DateTime.Parse(Console.ReadLine());
                                            service.AddCustomer(customer);
                                            Console.WriteLine("Customer Registration Successful..");
                                        }
                                        break;
                                    case 2:
                                        {
                                            // After Login Section
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
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        // Check Status Part
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        // Update Customer Part
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
                                            Console.WriteLine("1. Loan Processing ");
                                            Console.WriteLine("2. View Customers");
                                            Console.WriteLine("3. Update Customers");
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
                                                        // View Customers part
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        // Update Customer Part
                                                    }
                                                    break;
                                                case 4:
                                                    {
                                                        // Delete Customer Part
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
