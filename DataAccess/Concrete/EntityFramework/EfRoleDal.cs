using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal: EfEntityRepositoryBase<Role, DataContext>, IRoleDal
    {

    }
}
