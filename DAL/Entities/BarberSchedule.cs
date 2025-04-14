using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BarberSchedule
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public DayOfWeek DayOfWeek { get; set; } // День недели (Понедельник, Вторник и т.д.)
        public TimeSpan StartTime { get; set; } // Время начала работы
        public TimeSpan EndTime { get; set; } // Время окончания работы
    }
}
