using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface CustomerInterface
    {
        IEnumerable<Customer> GetAllCustomers(BackEndContext backEndContext);
        Customer GetCustomerById(BackEndContext backEndContext, long customerId);
        Customer GetByEmailAndPassword(BackEndContext backEndContext, string email, string password);
        Customer CreateNewCustomer(BackEndContext backEndContext,Customer customer);
        Customer UpdateCustomer(BackEndContext backEndContext, Customer customer);
        bool DeleteCustomer(BackEndContext backEndContext, long customerId);
        bool ValidateCustomer(string email);
    }
}