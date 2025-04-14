using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopClient.Models
{
    public class BarberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public string Photo { get; set; }
        public string Level { get; set; }
    }

}
