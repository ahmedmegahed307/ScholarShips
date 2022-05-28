using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class UpdateUserDTO : BaseDTO, IDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DisciplineId { get; set; }
        public int TitleId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int UniversityId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
