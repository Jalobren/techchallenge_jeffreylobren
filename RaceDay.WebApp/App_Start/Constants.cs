using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RaceDay.WebApp.App_Start
{
    public class Constants
    {
        public static string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["api:username"];
            }
        }
    }
}