using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BarberShopDB _context;

        public BookingRepository(BarberShopDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
            => await _context.Bookings.Include(b => b.Barber).Include(b => b.Service).ToListAsync();

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
            => await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Barber)
                .Include(b => b.Service)
                .ToListAsync();

        public async Task<Booking> GetByIdAsync(int id)
            => await _context.Bookings.Include(b => b.Barber).Include(b => b.Service).FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }


}
