using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User : IdentityUser<int>
    {
        public ICollection<Booking> Bookings { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
