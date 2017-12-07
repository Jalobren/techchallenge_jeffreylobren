using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Service;
using RaceDay.Contracts.Dto;

namespace RaceDay.Client
{
    public class CustomerServiceClient : WebApiClient, ICustomerService
    {
        public async Task<ApiResponse<List<CustomerDto>>> GetAll(string customerName)
        {
            var relPath = "GetCustomers?name=" + customerName;
            return await GetAsync<List<CustomerDto>>(relPath);
        }
    }

}
