using Entities.InterjectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISavedPostingService
    {
        ResultDTO<SavedPostingDTO> SavedPostingDTO(SavedPostingDTO model);

    }
}
