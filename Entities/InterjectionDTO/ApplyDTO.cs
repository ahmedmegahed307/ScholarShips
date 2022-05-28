using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class ApplyDTO : BaseDTO, IDTO
    {
        public int CvId { get; set; }
        public int UserId { get; set; }
        public int PostingId { get; set; }
    }
}
