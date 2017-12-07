using RaceDay.BL.Interface;
using RaceDay.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RaceDay.Api.Controllers
{
    [RoutePrefix("api/bet")]
    public class BetController : ApiController
    {
        private readonly IBetBL _betBL;
        public BetController(IBetBL betBL)
        {
            _betBL = betBL;
        }

        [Route("getAll/TotalAmount")]
        public decimal GetAllTotalAmountBets()
        {
            return _betBL.GetTotalAmount();
        }

       
    }
}
