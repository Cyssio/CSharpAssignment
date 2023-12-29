using AssignmentShared.Interfaces;
using System.Diagnostics;

namespace AssignmentShared.Services;

public class CustomerService : ICustomerService
{
    private readonly List<ICustomer> _customerList = [];



    public bool AddToList(ICustomer customer)
    {
        try
        {
            customer.Id = _customerList.Count + 1;

            _customerList.Add(customer);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<ICustomer> GetAllFromList()
    {
        try
        {
            return _customerList;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
