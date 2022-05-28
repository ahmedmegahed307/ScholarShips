using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Titles")]
    public class Title : IEntity
    {
        public int Id { get; set; }
        public string TitleType { get; set; }
        public ICollection<Posting> Postings { get; set; }
        public ICollection<Individual> Individuals { get; set; }

    }
}
