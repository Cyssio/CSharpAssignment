using AssignmentShared.Interfaces;

namespace AssignmentShared.Models;

public class Customer : ICustomer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}
