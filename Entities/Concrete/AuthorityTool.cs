using Entities.Abstract;

namespace Entities.Concrete
{
    public class AuthorityTool : IEntity
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public bool IsWrite { get; set; }
        public bool IsRead { get; set; }                            // sayfalarda ve controllerdaki yetkileri tanımladıgımız yer
        public bool IsModify { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public Tool Tool { get; set; }
    }
}
