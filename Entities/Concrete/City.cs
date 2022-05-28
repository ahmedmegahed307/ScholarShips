using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Cities")]
    public class City : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
