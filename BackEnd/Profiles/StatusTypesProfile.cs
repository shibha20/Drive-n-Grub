using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Profiles
{
    public class StatusTypesProfile : Profile
    {
        public StatusTypesProfile()
        {
            CreateMap<StatusType, StatusTypeReadDto>();
            CreateMap<StatusTypeReadDto, StatusType>();
        }
    }
}
