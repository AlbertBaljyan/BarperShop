using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Queries
{
    public static class BarberScheduleExtension
    {
        public static BarberSchedule GetById(this DbSet<BarberSchedule> db, int Id)
        {
            return db.FirstOrDefault(b => b.Id == Id);
        }
        public static List<BarberSchedule> GetAll(this DbSet<BarberSchedule> db)
        {

            return db.ToList();

        }
    }
}
