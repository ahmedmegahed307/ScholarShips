using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Applies")]
    public class Apply : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostingId { get; set; }
        public int CvId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public CV CV { get; set; }
        public User User { get; set; }
        public Posting Posting { get; set; }

    }
}
