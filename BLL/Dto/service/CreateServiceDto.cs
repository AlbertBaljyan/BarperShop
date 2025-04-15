using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class CreateServiceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateServicePriceDto> Prices { get; set; }
    }

}
