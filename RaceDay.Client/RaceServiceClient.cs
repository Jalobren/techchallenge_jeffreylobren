using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Service;
using RaceDay.Contracts.Dto;


namespace RaceDay.Client
{
    public class RaceServiceClient : WebApiClient, IRaceService
    {
        public async Task<ApiResponse<List<RaceDto>>> GetAll(string customerName)
        {
            var relPath = "GetRaces?name=yourName" + customerName;
            return await GetAsync<List<RaceDto>>(relPath);
        }
    }
}
