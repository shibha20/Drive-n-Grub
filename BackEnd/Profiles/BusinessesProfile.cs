using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Profiles
{
    public class BusinessesProfile : Profile
    {
        public BusinessesProfile()
        {
            CreateMap<Business, BusinessReadDto>();
            CreateMap<BusinessReadDto, Business>();
        }
    }
}