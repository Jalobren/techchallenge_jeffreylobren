using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RaceDay.Contracts.Dto.Enums;
using RaceDay.Contracts.Dto;

namespace RaceDay.WebApp.Models
{
    public class RaceModel : RaceDto
    {
        public new List<HorseModel> Horses { get; set; }
        public decimal TotalBets { get; set; }
    }
}