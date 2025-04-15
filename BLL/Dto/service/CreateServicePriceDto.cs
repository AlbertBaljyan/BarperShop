using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class CreateServicePriceDto
    {
        public BarberLevel Level { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }

}
