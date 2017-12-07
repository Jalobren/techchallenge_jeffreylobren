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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerBL _customerBL;
        public CustomerController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }
        public IEnumerable<CustomerDto> Get()
        {
            return _customerBL.GetAll();
        }

        [Route("get/{id}/TotalBets")]
        public int GetTotalBets(int id)
        {
            return _customerBL.GetTotalBets(id);
        }

        [Route("get/{id}/TotalAmountBets")]
        public decimal GetTotalAmountBets(int id)
        {
            return _customerBL.GetTotalAmountBets(id);
        }

        [Route("getAll/AtRisk")]
        public List<CustomerDto> GetAllAtRisk()
        {
            return _customerBL.GetAllAtRisk();
        }


    }
}
