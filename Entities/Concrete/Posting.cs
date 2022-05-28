using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Postings")]
    public class Posting : IEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }
        public int TitleId { get; set; }
        public int PostingTypeId { get; set; }
        public int? UniversityId { get; set; }
        //public int? ImageId { get; set; }

        public long Budget { get; set; }
        public int Quota { get; set; }
        public string Remark { get; set; }
        public bool ISFunded { get; set; }
        public string FundingFor { get; set; }
        public string PostingTitle { get; set; }
        public int Hours { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public User User { get; set; }
        public Discipline Discipline { get; set; }
        public Title Title { get; set; }
        public PostingType PostingType { get; set; }
        public University University { get; set; }
      
        //public Image Image { get; set; }
        public ICollection<Apply> Applies { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<SavedPosting> SavedPosting { get; set; }



    }
}
