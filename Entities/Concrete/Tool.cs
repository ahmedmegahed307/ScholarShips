using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Tool : IEntity
    {
        public int Id { get; set; }
        public string ObjectController { get; set; }
        public string ObjectTitle { get; set; }                 // sayfalarda ve controllerdaki yetkileri tanımladıgımız yer
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public ICollection<UserTool> UsersTool { get; set; }
        public ICollection<AuthorityTool> AuthorityTool { get; set; }


    }
}
