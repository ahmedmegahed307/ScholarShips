using Entities.Abstract;

namespace Entities.Concrete
{
    public class UserTool : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ToolId { get; set; }                      // kullanıcının sayfalar üzerindeki yetkilerini tuttugumuz tablo
        public User User { get; set; }
        public Tool Tool { get; set; }
    }
}
