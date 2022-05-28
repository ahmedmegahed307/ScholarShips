using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InterjectionDTO
{
    public class SavedPostingDTO : BaseDTO, IDTO
    {
        public int UserId { get; set; }
        public int PostingId { get; set; }
        public string Message { get; set; }
    }
}
