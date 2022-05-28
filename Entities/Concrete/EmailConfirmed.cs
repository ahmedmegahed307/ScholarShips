using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class EmailConfirmed : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailConfirmedCode { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
