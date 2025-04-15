using BLL.Dto;
using BLL.Queries;
using DAL;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUOW _uow;
        private readonly BarberShopDB _context;
        public BarberService(IBarberRepository barberRepository, BarberShopDB context, IUOW uow)
        {
            _context = context;
            _barberRepository = barberRepository;  // Инжекция репозитория через DI
            _uow = uow;
        }

        public async Task CreateAsync(CreateBarberDto barber)
        {
            var entity = new Barber()
            {
                Name = barber.Name,
                Photo = barber.Photo,
                Level = barber.Level,
                BIO = barber.BIO,
                Schedule = barber.Schedule.Select(bs => new BarberSchedule()
                {
                    DayOfWeek = bs.DayOfWeek,
                }).ToList(),
            };
            await _barberRepository.CreateBarberAsync(entity);
            _uow.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _barberRepository.DeleteAsync(id);
            _uow?.Save();
        }

        // Получить всех барберов
        public async Task<List<BarberDto?>> GetAllBarbersAsync()
        {
            return await _context.Barbers.GetAllBarbersAsync();  // Делегируем вызов репозиторию
        }

        // Получить барбера по ID

        public async Task<BarberDetailsDto?> GetByBarberIdAsync(int id)
        {
            return await _context.Barbers
                .Include(b => b.Schedule)
                .Include(b => b.ScheduleExceptions)
                .Include(b => b.Bookings).ThenInclude(b => b.Service)
                .GetByBarberId(id)
                .FirstOrDefaultAsync();
        }

        public async Task<Barber> GetForUpdateAsync(int id)
        {
            return await _barberRepository.GetForUpdateAsync(id);

            
        }

        public async Task UpdateAsync(CreateBarberDto barber)
        {
            var model =  await GetForUpdateAsync(barber.Id);
            model.BIO=barber.BIO;
            model.Level=barber.Level;
            model.Name=barber.Name; 
            model.Photo=barber.Photo;
            model.Schedule=barber.Schedule.Select(bs=>new BarberSchedule()
            {
                DayOfWeek=bs.DayOfWeek,
                StartTime=bs.StartTime,
                EndTime=bs.EndTime,
            }).ToList();
           _barberRepository.UpdateBarberAsync(model);
            _uow.Save();
            
        }
    }

 

}








