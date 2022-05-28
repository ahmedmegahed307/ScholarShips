using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Images")]
    public class Image : IEntity
    {
        public int Id { get; set; }

        public int ImageTypeId { get; set; }
        public int? PostingId { get; set; }
        public int? EventId { get; set; }
        public int? UserId { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }

        public ImageType ImageType { get; set; }
        public Posting Posting { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        //public ICollection<Posting> Posting { get; set; }
        //public ICollection<Event> Event { get; set; }

    }
}
