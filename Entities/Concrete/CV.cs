using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("CVs")]
    public class CV : IEntity
    {
        public int Id { get; set; }
        public string CvPathName { get; set; }
        public string CvPath { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public User User { get; set; }
        public ICollection<Apply> Apply { get; set; }

    }
}
