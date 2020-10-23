using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class OrderService : OrderInterface
    {
        private readonly BackEndContext _db;
        public OrderService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Order> GetAllOrders(BackEndContext backEnd)
        {
            return _db.Orders.ToList();
        }

        public Order GetOrderById(BackEndContext backEnd, long orderId)
        {
            return _db.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public Order CreateNewOrder(BackEndContext backEnd,Order order)
        
        {
            backEnd.Orders.Add(order);
            backEnd.SaveChanges();
            return GetOrderById(backEnd, order.OrderId);
        }

        public Order UpdateOrder(BackEndContext backEnd, Order order)
        {
            backEnd.Orders.Add(order);
            backEnd.SaveChanges();
            return GetOrderById(backEnd, order.OrderId);
        }

        public bool DeleteOrder(BackEndContext backEnd, long orderId)
        {
            Order order = GetOrderById(backEnd, orderId);
            backEnd.Orders.Remove(order);
            backEnd.SaveChanges();
            return true;
        }
    }
}