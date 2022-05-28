using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostingTypeDal : EfEntityRepositoryBase<PostingType, DataContext>, IPostingTypeDal
    {
    }
}
