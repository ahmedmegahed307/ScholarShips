using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Countries")]
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Countries { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<University> Universities { get; set; }
        public ICollection<User> Users { get; set; }


    }
}
