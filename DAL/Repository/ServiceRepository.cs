using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{                                                               //тут сервисы который предлогает барбершоп
    public class ServiceRepository : IServiceRepository
    {
        private readonly BarberShopDB _context;

        public ServiceRepository(BarberShopDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
            => await _context.Services.Include(s => s.Prices).ToListAsync();

        public async Task<Service> GetByIdAsync(int id)
        {
          var entity=  await _context.Services.Include(s => s.Prices).FirstOrDefaultAsync(s => s.Id == id);
            return entity;
        }


        public async Task AddAsync(Service service)
        {
            _context.Services.Add(service);
              await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
               await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Services.FindAsync(id);
            if (entity != null)
            {
                _context.Services.Remove(entity);
                    await _context.SaveChangesAsync();
            }
        }
    }

}
