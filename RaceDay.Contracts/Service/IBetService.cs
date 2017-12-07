using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Dto;


namespace RaceDay.Contracts.Service
{
    public interface IBetService
    {
        Task<ApiResponse<List<BetDto>>> GetAll(string customerName);
    }
}
