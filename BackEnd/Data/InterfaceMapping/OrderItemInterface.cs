using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface OrderItemInterface
    {
        IEnumerable<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(long orderItemId);
        OrderItem CreateNewOrderItem(OrderItemReadDto orderItem);
        OrderItem UpdateOrderItem(OrderItemReadDto orderItem);
        bool DeleteOrderItem(long orderItemId);
        List<OrderItem> CreateListOfOrderItems(List<OrderItemReadDto> orderItems);
        List<OrderItem> GetAllByOrderId(long orderId);
    }
}