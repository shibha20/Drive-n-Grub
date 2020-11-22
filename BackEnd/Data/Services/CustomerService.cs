using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
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
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customer GetCustomerById( long customerId)
        {
            return _db.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public Customer CreateNewCustomer(CustomerReadDto customer)
        {
            var newCustomer = new Customer{
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CustomerEmail = customer.CustomerEmail,
                CustomerPassword = customer.CustomerPassword,
                IsGuest = customer.IsGuest,
                UserEntered = "Create Customer",
                DateEntered = DateTime.Now
            };
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            customer.CustomerId = newCustomer.CustomerId;
            return GetCustomerById(customer.CustomerId);
        }

        public Customer UpdateCustomer(CustomerReadDto customer)
        {
            if(customer.CustomerId == 0)
            {
                CreateNewCustomer(customer);
            }
            else{
                var updateCustomer = new Customer{
                    CustomerName = customer.CustomerName,
                    PhoneNumber = customer.PhoneNumber,
                    CustomerEmail = customer.CustomerEmail,
                    CustomerPassword = customer.CustomerPassword,
                    IsGuest = customer.IsGuest,
                    UserModified = "Update Customer",
                    DateModified = DateTime.Now
                };
                _db.Customers.Add(updateCustomer);
                _db.SaveChanges();
            }
            return GetCustomerById(customer.CustomerId);
        }

        public bool DeleteCustomer( long customerId)
        {
            Customer customer = GetCustomerById(customerId);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return true;
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            return _db.Customers.FirstOrDefault(x => x.CustomerEmail == email && x.CustomerPassword == password);
        }

        public bool ValidateCustomer(string email)
        {
            Customer customer = _db.Customers.FirstOrDefault(x => x.CustomerEmail == email && x.DateDeleted == null);
            if(customer!=null)
            {
                return true;
            }
            return false;        
        }
    }
}