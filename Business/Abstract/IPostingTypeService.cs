using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPostingTypeService 
    {
        ResultDTO<List<PostingTypeDTO>> GetListPostingTypeDTO();

    }
}
