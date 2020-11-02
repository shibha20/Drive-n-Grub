using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class OrderItemService : OrderItemInterface
    {
        private readonly BackEndContext _db;
        public OrderItemService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<OrderItem> GetAllOrderItems(BackEndContext backEnd)
        {
            return _db.OrderItems.ToList();
        }

        public OrderItem GetOrderItemById(BackEndContext backEnd, long orderItemId)
        {
            return _db.OrderItems.FirstOrDefault(x => x.OrderItemId == orderItemId);
        }

        public OrderItem CreateNewOrderItem(BackEndContext backEnd,OrderItem orderItem)
        {
            backEnd.OrderItems.Add(orderItem);
            backEnd.SaveChanges();
            return GetOrderItemById(backEnd, orderItem.OrderItemId);
        }

        public OrderItem UpdateOrderItem(BackEndContext backEnd, OrderItem orderItem)
        {
            backEnd.OrderItems.Add(orderItem);
            backEnd.SaveChanges();
            return GetOrderItemById(backEnd, orderItem.OrderItemId);
        }

        public bool DeleteOrderItem(BackEndContext backEnd, long orderItemId)
        {
            OrderItem orderItem = GetOrderItemById(backEnd, orderItemId);
            backEnd.OrderItems.Remove(orderItem);
            backEnd.SaveChanges();
            return true;
        }
    }
}