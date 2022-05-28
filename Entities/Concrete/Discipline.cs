using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Disciplines")]
    public class Discipline : IEntity
    {
        public int Id { get; set; }
        public string DisciplineType { get; set; }
        public ICollection<Posting> Postings { get; set; }
        public ICollection<Individual> Individuals { get; set; }



    }
}
