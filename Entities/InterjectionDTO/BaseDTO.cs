using Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.InterjectionDTO
{
    public class BaseDTO:IDTO
    {
        [ScaffoldColumn(false)]
        public int Id
        {
            get; set;
        }
        [ScaffoldColumn(false)]
        [Display(Name = "BaseDTO.IsActive.Display")]
        public bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "BaseDTO.CreateDate.Display")]
        public DateTime? CreateDate { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "BaseDTO.CreateUser.Display")]
        public int? CreateUser { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "BaseDTO.UpdateUser.Display")]
        public int? UpdateUser { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "BaseDTO.UpdateDate.Display")]
        public DateTime? UpdateDate { get; set; }
        //[ScaffoldColumn(false)]
        //public string OriginalDTO { get; set; }
    }
}
