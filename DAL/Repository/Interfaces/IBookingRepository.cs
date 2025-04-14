using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
        Task<Booking> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        Task DeleteAsync(int id);
    }

}
