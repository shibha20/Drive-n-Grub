using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface CustomerInterface
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(long customerId);
        Customer GetByEmailAndPassword(string email, string password);
        Customer CreateNewCustomer(CustomerReadDto customer);
        Customer UpdateCustomer(CustomerReadDto customer);
        bool DeleteCustomer(long customerId);
    }
}