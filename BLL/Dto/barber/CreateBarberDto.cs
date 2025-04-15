using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class CreateBarberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
        public BarberLevel Level { get; set; }
        public List<ScheduleDto> Schedule { get; set; } // Расписание, которое нужно будет добавить
    }

}
