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
        Task<Barber> GetForUpdateAsync(int id);         // Получить барбера по ID
        Task CreateBarberAsync(Barber barber);              // Добавить нового барбера
        Task UpdateBarberAsync(Barber barber);           // Обновить барбера
        Task DeleteAsync(int id);                  // Удалить барбера по ID
    }

}
