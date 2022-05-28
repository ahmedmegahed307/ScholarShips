using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDisciplineService 
    {
        ResultDTO<List<DisciplineDTO>> GetList();
        
    }
}
