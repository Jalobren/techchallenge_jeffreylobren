using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceDay.Contracts.Dto.Enums;

namespace RaceDay.Contracts.Dto
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Status { get; set; }
        public RaceStatusEnum StatusEnum { get; set; }
        public List<HorseDto> Horses { get; set; }
    }
}
