using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class BarberShopDB : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public BarberShopDB(DbContextOptions<BarberShopDB> opt) : base(opt)
        {

        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<BarberSchedule> BarberSchedules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePrice> ServicePrices { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
