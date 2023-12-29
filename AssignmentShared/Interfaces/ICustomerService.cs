namespace AssignmentShared.Interfaces;

public interface ICustomerService
{
    bool AddToList(ICustomer customer);
    IEnumerable<ICustomer> GetAllFromList();
}
