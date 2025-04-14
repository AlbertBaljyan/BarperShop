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
        public static Barber GetById(this DbSet<Barber> db, int Id)
        {
            return db.Include(b=>b.Bookings).Include(b=>b.Schedule).FirstOrDefault(b => b.Id == Id);
        }
        public static List<Barber> GetAll(this DbSet<Barber> db)
        {

            return db.Include(a => a.Schedule)
                            .Include(a => a.Bookings)
                            .OrderBy(b=>b.Level)
                            .ToList();

        }
    }
}
