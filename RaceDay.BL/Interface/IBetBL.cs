﻿using RaceDay.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.BL.Interface
{
    public interface IBetBL
    {
        decimal GetTotalAmount();
    }
}
