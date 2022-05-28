using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class IndividualDTO:BaseDTO,IDTO
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
    }
}
