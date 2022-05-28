using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Institutions")]
    public class Institution : User ,IEntity
    {
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactMail { get; set; }
        public string CompanyName { get; set; }
        public string WebSite { get; set; }

    }
}
