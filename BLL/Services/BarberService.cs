using BLL.ViewModel;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class BarberService : IBarberService
    {
        private readonly IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;  // Инжекция репозитория через DI
        }

        // Получить всех барберов
        public Task<IEnumerable<Barber>> GetAllAsync()
        {
            return _barberRepository.GetAllAsync();  // Делегируем вызов репозиторию
        }

        // Получить барбера по ID
        public Task<Barber> GetByIdAsync(int id)
        {
            return _barberRepository.GetByIdAsync(id);  // Делегируем вызов репозиторию
        }

        // Добавить нового барбера
        public Task CreateAsync(Barber barber)
        {
            return _barberRepository.AddAsync(barber);  // Делегируем вызов репозиторию
        }

        // Обновить барбера
        public Task UpdateAsync(Barber barber)
        {
            return _barberRepository.UpdateAsync(barber);  // Делегируем вызов репозиторию
        }

        // Удалить барбера
        public Task DeleteAsync(int id)
        {
            return _barberRepository.DeleteAsync(id);  // Делегируем вызов репозиторию
        }
    }

}

