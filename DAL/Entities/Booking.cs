using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime BookingDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
