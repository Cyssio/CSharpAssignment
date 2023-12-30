namespace AssignmentShared.Interfaces;

public interface ICustomerService
{
    /// <summary>
    /// Adds one customer to list
    /// </summary>
    /// <param name="customer">Refers to the customer and all the info in them</param>
    /// <returns>Return true if added customer to list, else return false if failed</returns>
    bool AddToList(ICustomer customer);


    /// <summary>
    /// Brings up all the customers in the list
    /// </summary>
    /// <returns>Returns customerList if customers are added to the list, else returns null</returns>
    IEnumerable<ICustomer> GetAllFromList();


    /// <summary>
    /// Gets one customers info by id
    /// </summary>
    /// <param name="customerId">Refers to the customerId that the customer has</param>
    /// <returns>Returns the chosen customer, else returns null</returns>
    ICustomer GetCustomerById(int customerId);


    /// <summary>
    /// Deleting a customer by their email
    /// </summary>
    /// <param name="email">Enter email as a string</param>
    /// <returns>Returns true if customer is deleted, else returns false</returns>
    bool DeleteCustomerByEmail (string email);
}
