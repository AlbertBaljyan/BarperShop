using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{/// <summary>
 /// тут рассписание барберов
 /// </summary>
    public class BarberScheduleRepository : IBarberScheduleRepository
    {
        private readonly BarberShopDB _context;

        public BarberScheduleRepository(BarberShopDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarberSchedule>> GetByBarberIdAsync(int barberId)
            => await _context.BarberSchedules
                .Where(s => s.BarberId == barberId)
                .ToListAsync();

        public async Task<BarberSchedule> GetByIdAsync(int id)
            => await _context.BarberSchedules.FindAsync(id);

        public async Task AddAsync(BarberSchedule schedule)
        {
            _context.BarberSchedules.Add(schedule);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BarberSchedule schedule)
        {
            _context.BarberSchedules.Update(schedule);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var schedule = await _context.BarberSchedules.FindAsync(id);
            if (schedule != null)
            {
                _context.BarberSchedules.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }
    }


}
