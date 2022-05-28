using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserDTO GetListAllEmailUsers(string mail);
    }
}
