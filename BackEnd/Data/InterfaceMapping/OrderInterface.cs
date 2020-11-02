using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface OrderInterface
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(long orderId);
        Order CreateNewOrder(OrderReadDto order);
        Order UpdateOrder(OrderReadDto order);
        bool DeleteOrder(long orderId);
    }
}