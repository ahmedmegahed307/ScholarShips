using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.InterjectionDTO
{
    public class CustomPostingDTO : BaseDTO, IDTO
    {
        public int PageIndex { get;  set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPages { get;  set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }
        public int TitleId { get; set; }
        public int PostingTypeId { get; set; }
        public int CountryId { get; set; }
        public int UniversityId { get; set; }
        public int CvId { get; set; }
        public List<PostingDTO> PostingDTOItems { get; set; }
        public List<PostingDTO> PostingDTOFalseItems { get; set; }
        public List<CVDTO> CVDTOItems { get; set; }
        public UserDTO UserDTOItems { get; set; }
        public List<UserDTO> ListUserDTOItems { get; set; }
        public List<ApplicantsPostingDTO> ApplicantsPostingDTOItems { get; set; }



    }
}
