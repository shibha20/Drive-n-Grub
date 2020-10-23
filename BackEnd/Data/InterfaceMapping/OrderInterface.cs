using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface OrderInterface
    {
        IEnumerable<Order> GetAllOrders(BackEndContext backEndContext);
        Order GetOrderById(BackEndContext backEndContext, long orderId);
        Order CreateNewOrder(BackEndContext backEndContext,Order order);
        Order UpdateOrder(BackEndContext backEndContext, Order order);
        bool DeleteOrder(BackEndContext backEndContext, long orderId);
    }
}