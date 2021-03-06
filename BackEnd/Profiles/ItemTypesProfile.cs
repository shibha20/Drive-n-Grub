using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Profiles
{
    public class ItemTypesProfile : Profile
    {
        public ItemTypesProfile()
        {
            CreateMap<ItemType, ItemTypeReadDto>();
            CreateMap<ItemTypeReadDto, ItemType>();
        }
    }
}