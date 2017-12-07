using AutoMapper;
using RaceDay.Contracts.Dto;
using RaceDay.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceDay.WebApp.App_Start
{
    public class AutoMapperConfig
    { 
        public static IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<HorseDto, HorseModel>()
                    .ForMember(dest=> dest.Bets, opt => opt.Ignore())
                    .ForMember(dest => dest.TotalNumberOfBets, opt => opt.Ignore())
                    .ForMember(dest => dest.TotalAmoutPayout, opt => opt.Ignore())
                    .ForMember(dest => dest.TotalBetAmount, opt => opt.Ignore());
                config.CreateMap<RaceDto, RaceModel>()
                    .ForMember(dest => dest.TotalBets, opt => opt.Ignore());
                config.CreateMap<BetDto, BetModel>();
            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}