using DAL.Enum;
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
        public BarberLevel Level { get; set; } // Уровень барбера, например: "Junior", "Senior", "Master"
        public ICollection<BarberSchedule> Schedule { get; set; } // Связь с расписанием барбера
        public ICollection<Booking> Bookings { get; set; } // Список записей на услуги
    }
}
