using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageTypeDal : EfEntityRepositoryBase<ImageType, DataContext>, IImageTypeDal
    {
        
    }
}
