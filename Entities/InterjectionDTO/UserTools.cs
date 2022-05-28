using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class UserTools : BaseDTO, IDTO
    {
        public int ApplicationUsersId { get; set; }

        public int ApplicationToolId { get; set; }

        public UserDTO ApplicationUsers { get; set; }
        public ToolDTO ApplicationTool { get; set; }
    }
}
