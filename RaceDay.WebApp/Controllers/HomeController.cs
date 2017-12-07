using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaceDay.Contracts.Service;
using RaceDay.Client;
using RaceDay.WebApp.Models;
using System.Threading.Tasks;
using AutoMapper;
using RaceDay.WebApp.App_Start;

namespace RaceDay.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRaceService _raceService;
        private IBetService _betService;
        private IMapper _mapper; 

        public HomeController(IRaceService raceService, IBetService betService, IMapper mapper)
        {
            _raceService = raceService;
            _betService = betService;
            _mapper = mapper;
        }

        
        public async Task<ActionResult> Index()
        {
            var racesDto = await _raceService.GetAll(Constants.UserName);
            var races = _mapper.Map<List<RaceModel>>(racesDto.Data);
            var bets = await _betService.GetAll(Constants.UserName);

            if (races != null)
            {
                
                foreach (var race in races)
                {
                    var raceBets = bets.Data.Where(x => x.RaceId == race.Id).Select(r=>r);
                    var totalBets = raceBets.Sum(r => r.Stake);
                    race.TotalBets = totalBets;

                    foreach (var horse in race.Horses)
                    {
                        var horseBets = raceBets.Where(x => x.HorseId == horse.Id).Select(h => h);
                        horse.Bets = Mapper.Map<List<BetModel>>(horseBets);
                        if (horse.TotalBetAmount > 0)
                        {
                            horse.TotalAmoutPayout = horse.TotalBetAmount * horse.Odds;
                        }
                    }
                }
            }

            return View(races);
        }

        
    }
}