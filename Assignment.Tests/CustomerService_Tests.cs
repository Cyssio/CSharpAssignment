using AssignmentShared.Interfaces;
using AssignmentShared.Models;
using AssignmentShared.Services;
using Moq;
using Newtonsoft.Json;

namespace Assignment.Tests;

public class CustomerService_Tests
{
    [Fact]
    public void AddOneCustomerToCustomerList_ThenReturnTrue()
    {
        // Arrange

        ICustomer customer = new Customer { FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        
        var mockFileService = new Mock<IFileService>();
        
        ICustomerService customerService = new CustomerService(mockFileService.Object);

        // Act

        bool result = customerService.AddToList(customer);

        // Assert

        Assert.True(result);
    }

    [Fact]
    public void GetAllCustomersFromCustomerList_ThenReturnList()
    {
        // Arrange

        var customers = new List<ICustomer>
        {
            new Customer { Id = 1, FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" }
        };
        string json = JsonConvert.SerializeObject(customers, Formatting.None, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContentFromFile(It.IsAny<string>())).Returns(json);
        
        ICustomerService customerService = new CustomerService(mockFileService.Object);


        // Act
        IEnumerable<ICustomer> result = customerService.GetAllFromList();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        ICustomer returnedCustomer = result.FirstOrDefault()!;
        Assert.Equal(1, returnedCustomer.Id);
    }

    [Fact]

    public void GetCustomerById_WhenValidId_ReturnsCustomer()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        var customerService = new CustomerService(mockFileService.Object);
        var customerId = 1;
        var customer = new Customer { Id = 1, FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        customerService.AddToList(customer);

        // Act
        var result = customerService.GetCustomerById(customerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customerId, result.Id);

    }

    [Fact]
    public void DeleteCustomerByEmail_WhenValidEmail_DeletesCustomer()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        var customerService = new CustomerService(mockFileService.Object);

        var customer = new Customer { Id = 1, FirstName = "Mattias", LastName = "Kasto", PhoneNumber = "071234-56-78", Email = "mattias@domain.com", Address = "Örebro" };
        customerService.AddToList(customer);

        var emailToDelete = "mattias@domain.com";

        // Act
        var deletionResult = customerService.DeleteCustomerByEmail(emailToDelete);

        // Assert
        Assert.True(deletionResult, $"Customer with email '{emailToDelete}' should have been deleted.");
    }
}
