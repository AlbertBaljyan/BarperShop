﻿using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ServicePrice
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public BarberLevel Level { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }

}
