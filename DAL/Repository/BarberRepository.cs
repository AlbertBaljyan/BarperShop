using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BarberRepository : IBarberRepository
    {
        private readonly BarberShopDB _context;

        public BarberRepository(BarberShopDB context)
        {
            _context = context;
        }

        // Получение всех барберов
        public async Task<IEnumerable<Barber>> GetAllAsync()
        {
            return await _context.Barbers
                .Include(b => b.Schedule)  // Включаем расписание барбера
                .Include(b => b.Bookings)  // Включаем записи барбера
                .ToListAsync();
        }

        // Получение барбера по ID
        public async Task<Barber> GetByIdAsync(int id)
        {
            return await _context.Barbers
                .Include(b => b.Schedule)  // Включаем расписание
                .Include(b => b.Bookings)  // Включаем записи
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Добавление нового барбера
        public async Task AddAsync(Barber barber)
        {
            await _context.Barbers.AddAsync(barber);
           await _context.SaveChangesAsync();
        }

        // Обновление барбера
        public async Task UpdateAsync(Barber barber)
        {
            _context.Barbers.Update(barber);
            await _context.SaveChangesAsync();
        }

        // Удаление барбера по ID
        public async Task DeleteAsync(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber != null)
            {
                _context.Barbers.Remove(barber);
               await _context.SaveChangesAsync();
            }
        }
    }
}
    
