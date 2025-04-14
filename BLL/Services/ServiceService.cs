using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;

        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Service>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Service> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Service service) => _repository.AddAsync(service);
        public Task UpdateAsync(Service service) => _repository.UpdateAsync(service);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }

}
