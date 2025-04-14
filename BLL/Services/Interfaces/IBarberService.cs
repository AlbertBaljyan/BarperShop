using BLL.ViewModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBarberService
    {
        Task<IEnumerable<Barber>> GetAllAsync();   // Получить всех барберов
        Task<Barber> GetByIdAsync(int id);         // Получить барбера по ID
        Task CreateAsync(Barber barber);           // Создать нового барбера
        Task UpdateAsync(Barber barber);           // Обновить барбера
        Task DeleteAsync(int id);                  // Удалить барбера
    }

}
