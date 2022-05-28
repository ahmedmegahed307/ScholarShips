using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.InterjectionDTO
{
    public class UserDTO : BaseDTO, IDTO
    {
        //Geçici olarak Posting id leri verildi.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public int RoleId { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Experience { get; set; }
        public string Institution { get; set; }
        public string ProfilPhotoPath { get; set; }
        public string JopTitle { get; set; }
        public string JobTitleAbbreviation { get; set; }
        public string Nationality { get; set; }
        public bool IsCompany { get; set; }
        public string ContactNumber { get; set; }
        public string WebSite { get; set; }
        public CityDTO City { get; set; }
        public CountryDTO Country { get; set; }
    }
}
