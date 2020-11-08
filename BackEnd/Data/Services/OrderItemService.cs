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

            List<OrderItem> currentOrderItems = GetAllByOrderId(orderId);
            List<OrderItem> currentOrderItemsToReturn = currentOrderItems.Intersect(mappedOrderItems).ToList();
            List<OrderItem> currentOrderItemsToDelete = currentOrderItems.Except(mappedOrderItems).ToList();
            List<OrderItem> NewOrderItemsToAdd = (List<OrderItem>)mappedOrderItems.Except(currentOrderItems).ToList();
            List<OrderItem> orderItemsToReturn = currentOrderItemsToReturn;

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
                orderItemsToReturn.Add(newOrderItem);
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

            foreach (OrderItem orderItemToReturn in orderItemsToReturn)
            {
                price = price + orderItemToReturn.Item.Price;
                if (orderItemToReturn.Item.ItemTypeId == 5)
                {
                    tax = +Math.Round((orderItemToReturn.Item.Price * Convert.ToDecimal(0.0575) + tax) * 100) / 100;
                }

            }

            order.TotalPrice = (price + tax);
            order.Tax = tax;
            order.UserModified = "Update Order";
            order.DateModified = DateTime.Now;

            _db.Update(order);
            _db.SaveChanges();
            return orderItemsToReturn;
        }
    }
}