using Entities.Abstract;
using System;


namespace Entities.Concrete
{
    public class SavedPosting : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostingId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public User User { get; set; }
        public Posting Posting { get; set; }
    }
}
