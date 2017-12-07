using AutoMapper;
using RaceDay.Contracts.Dto;
using RaceDay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceDay.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CustomerDto, Customer>()
                    .ForMember(dest => dest.Bets, opt => opt.Ignore());
                config.CreateMap<Customer, CustomerDto>();

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}