using Entities.Abstract;


namespace Entities.InterjectionDTO
{
    public class CVDTO : BaseDTO, IDTO
    {
        public string CvPathName { get; set; }
        public string CvPath { get; set; }
        public int UserId { get; set; }

    }
}
