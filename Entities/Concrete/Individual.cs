using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Individuals")]
    public class Individual : User ,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DisciplineId { get; set; }
        public int? TitleId { get; set; }
        public int? UniversityId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime Experience { get; set; }
        public string JobTitle { get; set; }
        public string JobTitleAbbreviation { get; set; }
        public string MotivationLetter { get; set; }
        public string Nationality { get; set; }
        public University University { get; set; }
        public Title Title { get; set; }
        public Discipline Discipline { get; set; }
    }
}
