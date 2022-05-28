using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.InterjectionDTO
{
    public class EventDTO : BaseDTO, IDTO
    {
        public int UserId { get; set; }
        public string EventTitle { get; set; }
        public string EventRemark { get; set; }
        public string? EventPhotoPath { get; set; }
        public int ImagePathId { get; set; }
        public DateTime DeadLine { get; set; }
        public int CreateEvent { get; set; }
        public DateTime? UpdateDeadLine { get; set; }
        public int? UpdateEvent { get; set; }
        public string EventImage { get; set; }
        public string EventImagePath { get; set; }

       

        public UserDTO ApplicationUsers { get; set; }


    }
}
