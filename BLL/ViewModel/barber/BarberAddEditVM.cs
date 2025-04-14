using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModel.booking;
using BLL.ViewModel.schedule;
using DAL.Enum;

namespace BLL.ViewModel
{
    public class BarberAddEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BarberLevel Level { get; set; } // Уровень барбера, например: "Junior", "Senior", "Master"
        public List<BarberScheduleVM> Schedule { get; set; } // Связь с расписанием барбера
        public List<BookingVM> Bookings { get; set; } // Список записей на услуги
    }
}
