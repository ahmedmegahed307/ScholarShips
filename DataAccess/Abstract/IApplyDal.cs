using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IApplyDal : IEntityRepository<Apply>
    {
        List<ApplicantsPostingDTO> GetListAll(int Id, int skip);

    }
}