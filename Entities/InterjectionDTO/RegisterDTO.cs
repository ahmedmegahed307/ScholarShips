using System;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.InterjectionDTO
{
    public class RegisterDTO : BaseDTO, IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
     

    }
}
