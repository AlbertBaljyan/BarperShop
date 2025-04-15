using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BarberScheduleException
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public DateTime Date { get; set; }

        public bool IsCancelled { get; set; } // если true — не работает в этот день

        public TimeSpan? StartTime { get; set; } // можно задать особое время
        public TimeSpan? EndTime { get; set; }
    }

}
