using AutoMapper;
using Ninject.Modules;
using RaceDay.Client;
using RaceDay.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceDay.WebApp.App_Start
{
    public class DependencyMapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICustomerService>().To<CustomerServiceClient>();
            this.Bind<IRaceService>().To<RaceServiceClient>();
            this.Bind<IBetService>().To<BetServiceClient>();
            this.Bind<IMapper>().ToMethod(AutoMapperConfig.AutoMapper).InSingletonScope();
        }

        
    }
}