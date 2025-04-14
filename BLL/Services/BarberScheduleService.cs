using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BarberScheduleService : IBarberScheduleService
    {
        private readonly IBarberScheduleRepository _repository;

        public BarberScheduleService(IBarberScheduleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<BarberSchedule>> GetByBarberIdAsync(int barberId)
            => _repository.GetByBarberIdAsync(barberId);

        public Task<BarberSchedule> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task CreateAsync(BarberSchedule schedule)
            => _repository.AddAsync(schedule);

        public Task UpdateAsync(BarberSchedule schedule)
            => _repository.UpdateAsync(schedule);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);
    }

}
