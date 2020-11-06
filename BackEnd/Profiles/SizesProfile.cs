using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Profiles
{
    public class SizesProfile : Profile
    {
        public SizesProfile()
        {
            CreateMap<Size, SizeReadDto>();
            CreateMap<SizeReadDto, Size>();
        }
    }
}