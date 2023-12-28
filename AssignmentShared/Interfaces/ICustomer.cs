namespace AssignmentShared.Interfaces;

public interface ICustomer
{
    string FirstName { get; set; }
    string LastName { get; set; } 
    int PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; } 

}
