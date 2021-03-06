using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class OrderService : OrderInterface
    {
        private readonly BackEndContext _db;
        private readonly StatusTypeInterface _statusType;
        private readonly CustomerInterface _customer;
        public OrderService(BackEndContext db, StatusTypeInterface statusType, CustomerInterface customer)
        {
            _db = db;
            _statusType = statusType;
            _customer = customer;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders.ToList();
        }

        public Order GetOrderById(long orderId)
        {
            return _db.Orders.
                Include(x => x.OrderItems)
                .FirstOrDefault(x => x.OrderId == orderId);
        }

        public Order CreateNewOrder(OrderReadDto order)
        {
            var newOrder = new Order{
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalPrice,
                Tax = order.Tax,
                Discount = order.Discount,
                StatusTypeId = order.StatusTypeId,
                UserEntered = "Create Order",
                DateEntered = DateTime.Now
            };
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
            order.OrderId = newOrder.OrderId;
            return GetOrderById(order.OrderId);
        }

        public Order UpdateOrder(OrderReadDto order)
        {

            if(order.OrderId == 0)
            {
                CreateNewOrder(order);
            }
            else{
                Order updateOrder = GetOrderById(order.OrderId);

                updateOrder.OrderId = order.OrderId;
                updateOrder.CustomerId = order.CustomerId;
                updateOrder.TotalPrice = order.TotalPrice;
                updateOrder.Tax = order.Tax;
                updateOrder.Discount = order.Discount;
                updateOrder.StatusTypeId = order.StatusTypeId;
                updateOrder.DateModified = DateTime.Now;
                updateOrder.UserModified = "Admin";


                _db.Update(updateOrder);
                _db.SaveChanges();
            }
            return GetOrderById(order.OrderId);
        }

        public bool DeleteOrder(long orderId)
        {
            Order order = GetOrderById(orderId);
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }

        public List<Order> GetAllTodaysOpenOrders()
        {
            var date = DateTime.Today.ToShortDateString();
            List<Order> orders = _db.Orders
                .ToList();
            List<Order> ordersToReturn = new List<Order>();
            foreach (Order order in orders)
            {
                if(order.DateEntered.ToShortDateString() == date && order.TotalPrice.ToString() != "0.00")
                {
                    order.Customer = _customer.GetCustomerById(order.CustomerId);
                    order.StatusType = _statusType.GetStatusTypeById(order.StatusTypeId);
                    ordersToReturn.Add(order);
                }
            }

            return ordersToReturn;

        }

    }
}