namespace AssignmentShared.Interfaces;

public interface ICustomerService
{
    bool AddToList(ICustomer customer);
    IEnumerable<ICustomer> GetAllFromList();
    ICustomer GetCustomerById(int customerId);
    bool DeleteCustomerByEmail (string email);
}
