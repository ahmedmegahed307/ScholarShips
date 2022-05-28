using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ImageType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
