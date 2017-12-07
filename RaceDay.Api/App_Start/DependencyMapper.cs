using AutoMapper;
using Ninject.Modules;
using RaceDay.BL.Implementation;
using RaceDay.BL.Interface;
using RaceDay.Client;
using RaceDay.Entity.Interfaces;
using RaceDay.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceDay.Api.App_Start
{
    public class DependencyMapper : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICustomerBL>().To<CustomerBL>();
            this.Bind<IBetBL>().To<BetBL>();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            this.Bind<ICustomerBetRepository>().To<CustomerBetRepository>();
            this.Bind<IMapper>().ToMethod(AutoMapperConfig.AutoMapper).InSingletonScope();
        }


    }
}