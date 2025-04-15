using BLL.Dto;
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
        Task<List<BarberDto>> GetAllBarbersAsync();   // Получить всех барберов
        Task<Barber> GetForUpdateAsync(int id);         // Получить барбера по ID
        Task<BarberDetailsDto> GetByBarberIdAsync(int id);         // Получить барбера по ID
        Task CreateAsync(CreateBarberDto barber);           // Создать нового барбера
        Task UpdateAsync(CreateBarberDto barber);           // Обновить барбера
        Task DeleteAsync(int id);                  // Удалить барбера
    }

}
