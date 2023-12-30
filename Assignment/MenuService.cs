using AssignmentShared.Interfaces;
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
            Console.WriteLine("1. Add a Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Find Customer by ID");
            Console.WriteLine("4. Delete Customer by Email");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    // Add a Customer
                    AddCustomer(customerService);
                    break;
                case "2":
                    // View All Customers
                    ViewAllCustomers(customerService);
                    break;
                case "3":
                    // Find Customer by ID
                    FindCustomerById(customerService);
                    break;
                case "4":
                    // Delete Customer by Email
                    DeleteCustomerByEmail(customerService);
                    break;
                case "5":
                    // Exit
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear(); // Clear the console for the next iteration
        }
    }

    private void AddCustomer(ICustomerService customerService)
    {
        // Implement code to add a customer here
        Console.WriteLine("Adding a customer...");
        // Example: Prompt user for details and call AddToList method
    }

    private void ViewAllCustomers(ICustomerService customerService)
    {
        // Implement code to view all customers here
        Console.WriteLine("Viewing all customers...");
        var customers = customerService.GetAllFromList();
        // Example: Display each customer in the console
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
        }
    }

    private void FindCustomerById(ICustomerService customerService)
    {
        // Implement code to find a customer by ID here
        Console.Write("Enter customer ID: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            var customer = customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                Console.WriteLine($"Customer found - ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
        }
    }

    private void DeleteCustomerByEmail(ICustomerService customerService)
    {
        // Implement code to delete a customer by email here
        Console.Write("Enter customer email: ");
        string email = Console.ReadLine()!;

        bool deletionResult = customerService.DeleteCustomerByEmail(email);

        if (deletionResult)
        {
            Console.WriteLine("Customer deleted successfully");
        }
        else
        {
            Console.WriteLine("Deletion failed or customer not found");
        }
    }
}
