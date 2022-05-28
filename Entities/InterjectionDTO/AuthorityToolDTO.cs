using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class AuthorityToolDTO : BaseDTO,IDTO
    {
        public bool IsWrite { get; set; }
        public bool IsRead { get; set; }
        public bool IsModify { get; set; }
        public bool IsDelete { get; set; }
        public ToolDTO ApplicationTool { get; set; }
    }
}
