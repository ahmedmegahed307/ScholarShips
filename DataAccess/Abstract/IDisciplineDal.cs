using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IDisciplineDal : IEntityRepository<Discipline>
    {
        List<Discipline> GetListAll();

    }
}
