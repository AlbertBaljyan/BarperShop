using BLL.Dto;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Queries
{
    public static class BarberExtension
    {
        public static async Task<List<BarberDto>> GetAllBarbersAsync(this IQueryable<Barber> query)
        {
            return await query
                .AsNoTracking()
                .Select(b => new BarberDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Photo = b.Photo,
                    Level = b.Level.ToString()
                })
                .ToListAsync();
        }

        public static IQueryable<BarberDetailsDto> GetByBarberId(this IQueryable<Barber> query, int id)
        {
            return query
                .Where(b => b.Id == id)
                .Select(b => new BarberDetailsDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    BIO = b.BIO,
                    Photo = b.Photo,
                    Level = b.Level.ToString(),

                    WeeklySchedule = b.Schedule.Select(s => new ScheduleDto
                    {
                        DayOfWeek = s.DayOfWeek,
                        StartTime = s.StartTime,
                        EndTime = s.EndTime
                    }).ToList(),

                    ScheduleExceptions = b.ScheduleExceptions.Select(e => new ScheduleExceptionDto
                    {
                        Date = e.Date,
                        IsCancelled = e.IsCancelled,
                        StartTime = e.StartTime,
                        EndTime = e.EndTime
                    }).ToList(),

                    Bookings = b.Bookings.Select(bk => new BookingDto
                    {
                        Id = bk.Id,
                        ClientName = bk.User.FirstName,
                        Date = bk.BookingDate,
                        ServiceName = bk.Service.Name
                    }).ToList()
                });
        }

    }
}