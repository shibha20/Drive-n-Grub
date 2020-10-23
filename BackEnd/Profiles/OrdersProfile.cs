using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderReadDto>();
        }
    }
}