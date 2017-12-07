using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Service;
using RaceDay.Contracts.Dto;

namespace RaceDay.Client
{
    public class BetServiceClient : WebApiClient, IBetService
    {
        public async Task<ApiResponse<List<BetDto>>> GetAll(string customerName)
        {
            var relPath = "GetBetsV2?name=" + customerName;
            return await GetAsync<List<BetDto>>(relPath);
        }
    }
}
