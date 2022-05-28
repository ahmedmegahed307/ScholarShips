using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITitleService 
    {
        ResultDTO<List<TitleDTO>> GetList();
    }
}
