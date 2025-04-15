using BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class BarberDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
        public string Level { get; set; }

        public List<ScheduleDto> WeeklySchedule { get; set; }
        public List<ScheduleExceptionDto> ScheduleExceptions { get; set; }

        public List<BookingDto> Bookings { get; set; }
    }

}
