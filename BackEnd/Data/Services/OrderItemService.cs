using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class OrderItemService : OrderItemInterface
    {
        private readonly BackEndContext _db;
        private readonly OrderInterface _order;
        private readonly ItemInterface _item;
        private readonly IMapper _mapper;
        public OrderItemService(BackEndContext db, OrderInterface order, ItemInterface item, IMapper mapper)
        {
            _db = db;
            _order = order;
            _item = item;
            _mapper = mapper;
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

        public List<OrderItem> GetAllByOrderId(long orderId)
        {
            return _db.OrderItems
                .Include(x => x.Item)
                    .ThenInclude(p => p.Size)
                .Where(x => x.OrderId == orderId).ToList();
        }

        public List<OrderItem> CreateListOfOrderItems(List<OrderItemReadDto> orderItems)
        {
            decimal price = 0;
            decimal tax = 0;
            var orderId = orderItems.FirstOrDefault(x => x.OrderId != null).OrderId;
            Order order = _order.GetOrderById(orderId);

            List<OrderItem> mappedOrderItems = _mapper.Map<List<OrderItem>>(orderItems);
            List<long> orderItemIds = mappedOrderItems.Select(x => x.OrderItemId).ToList();
            List<OrderItem> currentOrderItems = GetAllByOrderId(orderId);
            List<OrderItem> NewOrderItemsToAdd = mappedOrderItems.Where(x => x.OrderItemId == 0).ToList();
            List<OrderItem> currentOrderItemsToDelete = currentOrderItems.Where(x => !orderItemIds.Contains(x.OrderItemId)).ToList();

            foreach (OrderItem orderItem in NewOrderItemsToAdd)
            {

                OrderItem newOrderItem = new OrderItem
                {
                    OrderId = orderItem.OrderId,
                    ItemId = orderItem.ItemId,
                    Order = order,
                    Item = _item.GetItemById(orderItem.ItemId),
                    UserEntered = "Create OrderItem",
                    DateEntered = DateTime.Now
                };
                _db.OrderItems.Add(newOrderItem);
                _db.SaveChanges();
                orderItem.OrderItemId = newOrderItem.OrderItemId;
            }

            foreach (OrderItem orderItem in currentOrderItemsToDelete)
            {
                var currentOrderItem = new OrderItem
                {
                    OrderId = orderItem.OrderId,
                    ItemId = orderItem.ItemId,
                    Order = order,
                    Item = _item.GetItemById(orderItem.ItemId),
                    UserDeleted = "OrderItemService",
                    DateDeleted = DateTime.Now
                };
                _db.OrderItems.Remove(currentOrderItem);
                _db.SaveChanges();
            }

            return mappedOrderItems;
        }
    }
}