﻿namespace AssignmentShared.Interfaces;

public interface ICustomer
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; } 
    string? PhoneNumber { get; set; }
    string Email { get; set; }
    string Address { get; set; } 

}
