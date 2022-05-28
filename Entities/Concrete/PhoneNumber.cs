using Entities.Abstract;

namespace Entities.Concrete
{
    public class PhoneNumber : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CallNumber { get; set; }
        public User User { get; set; }
    }
}
