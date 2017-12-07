using RaceDay.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Dto;
using RaceDay.Entity.Interfaces;
using RaceDay.Entity;

namespace RaceDay.BL.Implementation
{

    public class BetBL : IBetBL
    {
        private readonly IRepository<Bet> _betRepositoy;

        public BetBL(IRepository<Bet> betRepository)
        {
            _betRepositoy = betRepository;
        }

        public decimal GetTotalAmount()
        {
            var bets = _betRepositoy.All();
            if (bets != null)
            {
                return bets.Sum(x => x.Stake);
            }
            return 0;
        }
    }
}
