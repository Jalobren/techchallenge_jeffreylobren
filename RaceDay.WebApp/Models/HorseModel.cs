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
        public decimal TotalBetAmount
        {
            get
            {
                if (Bets != null)
                {
                    Decimal totalBetAmount = 0;
                    Bets.ForEach(x => totalBetAmount += x.Stake);
                    return totalBetAmount;
                }
                return 0;
            }        
        }

        public decimal TotalAmoutPayout { get; set; }

    }
}