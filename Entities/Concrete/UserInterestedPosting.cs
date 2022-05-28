using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserInterestedPosting :  IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        //public string UserName { get; set; }
        //public string UserSurName { get; set; }
        //public string CountryName { get; set; }
        public long Budget { get; set; }
        public int Quota { get; set; }
        public string Remark { get; set; }
        public bool ISFunded { get; set; }
        public string FundingFor { get; set; }
        public int Hours { get; set; }
        public string DisciplineType { get; set; }
        public string TitleType { get; set; }
        public string Name { get; set; }
        //public string PostingType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public bool IsActive { get; set; }

    }
}
