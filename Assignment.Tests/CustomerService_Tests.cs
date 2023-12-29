using AssignmentShared.Interfaces;
using AssignmentShared.Models;
using AssignmentShared.Services;

namespace Assignment.Tests;

public class CustomerService_Tests
{
    [Fact]
    public void AddOneCustomerToCustomerList_ThenReturnTrue()
    {
        // Arrange

        ICustomer customer = new Customer { FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        ICustomerService customerService = new CustomerService();

        // Act

        bool result = customerService.AddToList(customer);

        // Assert

        Assert.True(result);
    }

    [Fact]
    public void GetAllCustomersFromCustomerList_ThenReturnList()
    {
        // Arrange

        ICustomerService customerService = new CustomerService();
        ICustomer customer = new Customer { FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        customerService.AddToList(customer);


        // Act
        IEnumerable<ICustomer> result = customerService.GetAllFromList();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        ICustomer returnedCustomer = result.FirstOrDefault()!;
        Assert.Equal(1, returnedCustomer.Id);
    }
}
