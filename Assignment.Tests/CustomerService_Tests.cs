using AssignmentShared.Interfaces;
using AssignmentShared.Models;
using AssignmentShared.Services;

namespace Assignment.Tests;

public class CustomerService_Tests
{
    [Fact]
    public void AddToListShould_AddOneCustomerToCustomerList_ThenReturnTrue()
    {
        // Arrange

        ICustomer customer = new Customer { FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        ICustomerService customerService = new CustomerService();

        // Act

        bool result = customerService.AddToList(customer);

        // Assert

        Assert.True(result);
    }
    
}
