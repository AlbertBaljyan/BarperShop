using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ServicePrice> Prices { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
