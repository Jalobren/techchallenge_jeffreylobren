using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Dto;


namespace RaceDay.Contracts.Service
{
    public interface ICustomerService
    {
        Task<ApiResponse<List<CustomerDto>>> GetAll(string customerName);
    }
}
