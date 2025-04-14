using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Booking>> GetAllAsync() => _repository.GetAllAsync();
        public Task<IEnumerable<Booking>> GetByUserIdAsync(int userId) => _repository.GetByUserIdAsync(userId);
        public Task<Booking> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Booking booking) => _repository.AddAsync(booking);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }

}
