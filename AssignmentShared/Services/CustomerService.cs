using AssignmentShared.Interfaces;
using AssignmentShared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AssignmentShared.Services;

public class CustomerService : ICustomerService
{
    private readonly IFileService _fileService;

    public CustomerService(IFileService fileService)
    {
        _fileService = fileService;

    }

    private readonly string _filePath = @"c:\VS-Projects\customers.json";
    private List<ICustomer> _customerList = [];



    public bool AddToList(ICustomer customer)
    {
        try
        {
            customer.Id = _customerList.Count + 1;
            _customerList.Add(customer);


            var json = JsonConvert.SerializeObject(_customerList, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
            });

            _fileService.SaveToFile(_filePath, json);

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<ICustomer> GetAllFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _customerList = JsonConvert.DeserializeObject<List<ICustomer>>(content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                })!;
            }

            return _customerList;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ICustomer GetCustomerById(int customerId)
    {
        try
        {
            var customer = _customerList.FirstOrDefault(c => c.Id == customerId);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public bool DeleteCustomerByEmail(string email)
    {
        try
        {
            // Find the customer with the matching email
            var customerToRemove = _customerList.FirstOrDefault(c => c.Email == email);

            if (customerToRemove != null)
            {
                _customerList.Remove(customerToRemove);

                // Update the JSON file after removing the customer
                var json = JsonConvert.SerializeObject(_customerList, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                });

                _fileService.SaveToFile(_filePath, json);

                Console.WriteLine("Customer deleted successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Customer not found");
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
