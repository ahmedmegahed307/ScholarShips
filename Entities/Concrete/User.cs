using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Users")]
    public class User : IEntity
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }


        public ICollection<Apply> Applies { get; set; }
        public ICollection<EmailConfirmed> EmailConfirmeds { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Posting> Postings { get; set; }
        public ICollection<UserTool> UserTool { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<CV> CVs { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
        public ICollection<SavedPosting> SavedPosting { get; set; }

        public ICollection<Image> Image { get; set; }
    }


}

