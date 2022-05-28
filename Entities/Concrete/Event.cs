using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Events")]
    public class Event : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EventTitle { get; set; }
        public string EventRemark { get; set; }
        public string EventPhotoPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int CreateEvent { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UpdateDeadLine { get; set; }
        public int? UpdateEvent { get; set; }
        //public Image Image { get; set; }
        public ICollection<Image> Image { get; set; }
        public User User { get; set; }
    }
}
