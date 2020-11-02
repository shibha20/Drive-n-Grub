using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface OrderItemInterface
    {
        IEnumerable<OrderItem> GetAllOrderItems(BackEndContext backEndContext);
        OrderItem GetOrderItemById(BackEndContext backEndContext, long orderItemId);
        OrderItem CreateNewOrderItem(BackEndContext backEndContext,OrderItem orderItem);
        OrderItem UpdateOrderItem(BackEndContext backEndContext, OrderItem orderItem);
        bool DeleteOrderItem(BackEndContext backEndContext, long orderItemId);
    }
}