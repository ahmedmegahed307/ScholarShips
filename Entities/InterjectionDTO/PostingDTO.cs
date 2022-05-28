using Entities.Abstract;
using System;

namespace Entities.InterjectionDTO
{
    
    public class PostingDTO : BaseDTO, IDTO
    {
        public int UserId { get; set; }
        public int DisciplineId { get; set; }
        public int TitleId { get; set; }
        public int PostingTypeId { get; set; }
        public int ImagePathId { get; set; }
        public int CountryId { get; set; }
        public int CvId { get; set; }
        public int CvId2 { get; set; }
        public int UniversityId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UniversityName { get; set; }
        public string CountryName { get; set; }
        public string CvPathName { get; set; }
        public string CvPathName2 { get; set; }
        public string CVPath { get; set; }
        public string CVPath2 { get; set; }
        public int ApplyCount { get; set; }
        public long Budget { get; set; }
        public int Quota { get; set; }
        public string Remark { get; set; }
        public bool ISFunded { get; set; }
        public string FundingFor { get; set; }
        public int Hours { get; set; }
        public string PostingImagePath { get; set; }
        public string DisciplineType { get; set; }
        public string TitleType { get; set; }
        public string PostingType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
