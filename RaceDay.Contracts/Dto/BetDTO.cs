using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.Contracts.Dto
{
    public class BetDto
    {
        public int CustomerId { get; set; }
        public int HorseId { get; set; }
        public int RaceId { get; set; }
        public decimal Stake { get; set; }
    }
}
