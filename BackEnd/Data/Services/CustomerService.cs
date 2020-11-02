using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class CustomerService : CustomerInterface
    {
        private readonly BackEndContext _db;
        public CustomerService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Customer> GetAllCustomers(BackEndContext backEnd)
        {
            return _db.Customers.ToList();
        }

        public Customer GetCustomerById(BackEndContext backEnd, long customerId)
        {
            return _db.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public Customer CreateNewCustomer(BackEndContext backEnd,Customer customer)
        {
            backEnd.Customers.Add(customer);
            backEnd.SaveChanges();
            return GetCustomerById(backEnd, customer.CustomerId);
        }

        public Customer UpdateCustomer(BackEndContext backEnd, Customer customer)
        {
            backEnd.Customers.Add(customer);
            backEnd.SaveChanges();
            return GetCustomerById(backEnd, customer.CustomerId);
        }

        public bool DeleteCustomer(BackEndContext backEnd, long customerId)
        {
            Customer customer = GetCustomerById(backEnd, customerId);
            backEnd.Customers.Remove(customer);
            backEnd.SaveChanges();
            return true;
        }

        public Customer GetByEmailAndPassword(BackEndContext backEndContext, string email, string password)
        {
            return _db.Customers.FirstOrDefault(x => x.CustomerEmail == email && x.CustomerPassword == password);
        }

        public bool ValidateCustomer(string email)
        {
            Customer customer = _db.Customers.FirstOrDefault(x => x.CustomerEmail == email);
            if(customer!=null)
            {
                return true;
            }
            return false;        
        }
    }
}