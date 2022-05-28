using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InterjectionDTO
{
    public class UniversityDTO : BaseDTO, IDTO
    {
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
       
    }
}
