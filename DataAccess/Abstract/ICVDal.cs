using Entities.Concrete;
using Entities.InterjectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICVDal : IEntityRepository<CV>
    {
        List<PostingDTO> GetPosting(int Id);

    }
}
