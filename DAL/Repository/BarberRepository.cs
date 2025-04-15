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



        // Получение барбера по ID
        public async Task<Barber> GetForUpdateAsync(int id)
        {
            return await _context.Barbers
                .Include(b => b.Schedule)  // Включаем расписание
                .Include(b => b.Bookings)  // Включаем записи
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Добавление нового барбера
        public async Task CreateBarberAsync(Barber barber)
        {
            await _context.Barbers.AddAsync(barber);

        }

        // Обновление барбера
        public async Task UpdateBarberAsync(Barber barber)
        {
            var entiti = _context.Barbers.FirstOrDefault(b => b.Id == barber.Id);
            if (entiti != null)
            {
                entiti.BIO = barber.BIO;
                entiti.Photo = barber.Photo;
                entiti.Schedule = barber.Schedule;
                entiti.Level = barber.Level;
            }
                _context.Barbers.Update(barber);
            }

            // Удаление барбера по ID
            public async Task DeleteAsync(int id)
            {
                var barber = await _context.Barbers.FindAsync(id);
                if (barber != null)
                {
                    _context.Barbers.Remove(barber);
                    
                }
            }
        }
    }


