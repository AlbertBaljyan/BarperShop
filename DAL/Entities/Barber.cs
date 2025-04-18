﻿using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{

    public class Barber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
        public BarberLevel Level { get; set; }

        public ICollection<BarberSchedule> Schedule { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public ICollection<BarberScheduleException> ScheduleExceptions { get; set; } // добавлено
    }

}
