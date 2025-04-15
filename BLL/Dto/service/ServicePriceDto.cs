using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class ServicePriceDto
    {
        public string Level { get; set; }         // "Junior", "Senior", "Master"
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }

}
