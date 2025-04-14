using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IBarberRepository
    {
        Task<IEnumerable<Barber>> GetAllAsync();    // Получить всех барберов
        Task<Barber> GetByIdAsync(int id);         // Получить барбера по ID
        Task AddAsync(Barber barber);              // Добавить нового барбера
        Task UpdateAsync(Barber barber);           // Обновить барбера
        Task DeleteAsync(int id);                  // Удалить барбера по ID
    }

}
