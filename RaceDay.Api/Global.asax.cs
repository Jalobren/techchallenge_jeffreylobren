using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ninject;
using System.Reflection;

namespace RaceDay.Api
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly(),
                Assembly.Load("RaceDay.BL"),
                Assembly.Load("RaceDay.Entity"),
                Assembly.Load("RaceDay.Contracts"));
            return kernel;
        }
    }
}
