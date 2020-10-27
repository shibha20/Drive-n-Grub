using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    public class OrderItemService : OrderItemInterface
    {
        private readonly BackEndContext _db;
        public OrderItemService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            return _db.OrderItems.ToList();
        }

        public OrderItem GetOrderItemById(long orderItemId)
        {
            return _db.OrderItems.FirstOrDefault(x => x.OrderItemId == orderItemId);
        }

        public OrderItem CreateNewOrderItem(OrderItemReadDto orderItem)
        {
            var newOrderItem = new OrderItem{
                UserEntered = "Create OrderItem",
                DateEntered = DateTime.Now
            };
            _db.OrderItems.Add(newOrderItem);
            _db.SaveChanges();
            orderItem.OrderItemId = newOrderItem.OrderItemId;
            return GetOrderItemById(orderItem.OrderItemId);
        }

        public OrderItem UpdateOrderItem(OrderItemReadDto orderItem)
        {
            if(orderItem.OrderItemId == 0)
            {
                CreateNewOrderItem(orderItem);
            }
            else{
                var updateOrderItem = new OrderItem{
                    UserModified = "Update OrderItem",
                    DateModified = DateTime.Now
                };
                _db.OrderItems.Add(updateOrderItem);
                _db.SaveChanges();
            }
            return GetOrderItemById(orderItem.OrderItemId);
        }

        public bool DeleteOrderItem(long orderItemId)
        {
            OrderItem orderItem = GetOrderItemById(orderItemId);
            _db.OrderItems.Remove(orderItem);
            _db.SaveChanges();
            return true;
        }
    }
}