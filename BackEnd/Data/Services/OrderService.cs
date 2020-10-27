using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    public class OrderService : OrderInterface
    {
        private readonly BackEndContext _db;
        public OrderService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders.ToList();
        }

        public Order GetOrderById(long orderId)
        {
            return _db.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public Order CreateNewOrder(OrderReadDto order)
        {
            var newOrder = new Order{
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalPrice,
                Tax = order.Tax,
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
                var updateOrder = new Order{
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    TotalPrice = order.TotalPrice,
                    Tax = order.Tax,
                    UserModified = "Update Order",
                    DateModified = DateTime.Now
                };
                _db.Orders.Add(updateOrder);
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
    }
}