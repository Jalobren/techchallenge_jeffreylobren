using RaceDay.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceDay.WebApp.Models
{
    public class HorseModel : HorseDto
    {
        public List<BetModel> Bets { get; set; }
        public int TotalNumberOfBets
        {
            get
            {
                if (Bets != null)
                {
                    return Bets.Count();
                }
                return 0;
            }
        }
        public decimal ToalPayOut
        {
            get
            {
                if (Bets != null)
                {
                    Decimal totalPayout = 0;
                    Bets.ForEach(x => totalPayout += (x.Stake * Odds));
                    return totalPayout;

                }
                return 0;
            }        
        }

    }
}