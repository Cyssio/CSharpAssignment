using AssignmentShared.Interfaces;
using AssignmentShared.Models;
using AssignmentShared.Services;

namespace Assignment;

internal class MenuService
{
    public void ShowMainMenu()
    {
        IFileService fileService = new FileService(); 
        ICustomerService customerService = new CustomerService(fileService);

        while (true)
        {
            Console.WriteLine("---- Customer Manager Menu ----");
            Console.WriteLine();
            Console.WriteLine($"{"1.", -3} Add a Customer");
            Console.WriteLine($"{"2.",-3} View All Customers");
            Console.WriteLine($"{"3.",-3} Find a Customer by ID");
            Console.WriteLine($"{"4.",-3} Delete a Customer by Email");
            Console.WriteLine($"{"5.",-3} Exit Application");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    AddCustomer(customerService);
                    break;
                case "2":
                    ViewAllCustomers(customerService);
                    break;
                case "3":
                    FindCustomerById(customerService);
                    break;
                case "4":
                    DeleteCustomerByEmail(customerService);
                    break;
                case "5":
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear(); 
        }
    }

    private void AddCustomer(ICustomerService customerService)
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter your email address: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        string phoneNumber = Console.ReadLine()!;

        Console.Write("Enter address: ");
        string address = Console.ReadLine()!;

        ICustomer newCustomer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address
        };

        bool addedSuccessfully = customerService.AddToList(newCustomer);

        if (addedSuccessfully)
        {
            Console.WriteLine("Customer was added successfully!");
        }
        else
        {
            Console.WriteLine("System failed to add the customer. The customer might already exist. Please try again.");
        }
    }

    private void ViewAllCustomers(ICustomerService customerService)
    {
        Console.WriteLine("Viewing all customers in the list...");
        var customers = customerService.GetAllFromList();
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: <{customer.Email}>");
        }
    }

    private void FindCustomerById(ICustomerService customerService)
    {
        Console.Write("Enter the ID of the customer you search for: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            var customer = customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                Console.WriteLine($"Customer found - ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: <{customer.Email}>, Phone number: {customer.PhoneNumber}, Adress: {customer.Address}");
            }
            else
            {
                Console.WriteLine("Unfortunately the customer you're searching for couldn't be found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
        }
    }

    private void DeleteCustomerByEmail(ICustomerService customerService)
    {
        Console.Write("Enter the Email of the customer you want to delete: ");
        string email = Console.ReadLine()!;

        bool deletionResult = customerService.DeleteCustomerByEmail(email);

        if (deletionResult)
        {
            Console.WriteLine("Customer was deleted successfully!");
        }
        else
        {
            Console.WriteLine("Sorry the deletion failed. The customer was not able to be found.");
        }
    }
}
