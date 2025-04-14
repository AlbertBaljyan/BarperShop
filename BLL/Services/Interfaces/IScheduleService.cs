using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBarberScheduleService
    {
        Task<IEnumerable<BarberSchedule>> GetByBarberIdAsync(int barberId);
        Task<BarberSchedule> GetByIdAsync(int id);
        Task CreateAsync(BarberSchedule schedule);
        Task UpdateAsync(BarberSchedule schedule);
        Task DeleteAsync(int id);
    }

}
