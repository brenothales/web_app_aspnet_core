using System;
using AutoMapper;
using WebAppAspnetcore.Data.Entities;
using WebAppAspnetcore.ViewModels;

namespace WebAppAspnetcore.Data
{
	public class DuctchMappingProfile : Profile
    {
        public DuctchMappingProfile()
        {
            CreateMap<Order, OrderViewModels>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}
