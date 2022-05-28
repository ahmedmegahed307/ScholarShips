using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class PostingType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Posting> Postings { get; set; }
    }
}
