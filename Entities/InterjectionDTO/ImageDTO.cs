using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class ImageDTO : BaseDTO, IDTO
    {
        public int ImageTypeId { get; set; }
        public int? PostingId { get; set; }
        public int? EventId { get; set; }
        public string ImagePath { get; set; }
    }
}
