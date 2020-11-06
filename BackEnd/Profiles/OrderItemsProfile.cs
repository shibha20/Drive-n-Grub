using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Profiles
{
    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItem, OrderItemReadDto>();
            CreateMap<OrderItemReadDto, OrderItem>();
        }
    }
}