using RaceDay.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.Entity.Repositories
{
    public class CustomerBetRepository : ICustomerBetRepository
    {
        internal RaceDayContext _context;

        public CustomerBetRepository(RaceDayContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomerAtRisk()
        {
            var customers = _context.Bets
               .Join(_context.Customers,
                  bet => bet.CustomerId,
                  cust => cust.Id,
                  (bet, cust) => new { Bet = bet, Cust = cust })
               .Where(x => x.Bet.Stake > 200).Select(c => c.Cust).ToList();

            if (customers != null)
            {
                return customers;
            }
            return null;
        }
    }
}
