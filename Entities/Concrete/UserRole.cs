using Entities.Abstract;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }             // kaydolurken kullanıcının sectigi rollerin sayısı birden fazla olabilecegi için
                                                                //  kullanıcının rollerini tuttugumuz tablo
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
