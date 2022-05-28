using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTitleDal : EfEntityRepositoryBase<Title, DataContext>, ITitleDal
    {
    }
}
