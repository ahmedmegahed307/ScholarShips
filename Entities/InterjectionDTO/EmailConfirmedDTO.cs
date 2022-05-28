using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InterjectionDTO
{
    public class EmailConfirmedDTO : BaseDTO, IDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmedCode { get; set; }
        public DateTime FinishDate { get; set; }


    }
}
