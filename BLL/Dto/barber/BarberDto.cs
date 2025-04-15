using DAL.Entities;
using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{

    public class BarberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo {  get; set; }
        public string Level { get; set; }  // можно использовать ToString() для BarberLevel, если это перечисление
    }

}

