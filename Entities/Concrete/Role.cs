using System.Collections.Generic;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UsersRole { get; set; }
    }
}
