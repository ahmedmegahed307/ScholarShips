using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InterjectionDTO
{
    public class ApplicantsPostingDTO : BaseDTO, IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string CVPath { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Experience { get; set; }
        public string ProfilPhotoPath { get; set; }
        public string JopTitle { get; set; }
        public string JobTitleAbbreviation { get; set; }
        public string Nationality { get; set; }
        public string WebSite { get; set; }
    }
}
