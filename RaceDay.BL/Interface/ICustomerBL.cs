using RaceDay.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.BL.Interface
{
    public interface ICustomerBL
    {
        List<CustomerDto> GetAll();
        int GetTotalBets(int customerId);
        decimal GetTotalAmountBets(int customerId);
        List<CustomerDto> GetAllAtRisk();
    }
}
