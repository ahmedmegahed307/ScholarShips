using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class ToolDTO : BaseDTO, IDTO
    {
        public string ObjectController { get; set; }
        public string ObjectTitle { get; set; }
    }
}
