using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRoleService 
    {

        ResultDTO<List<RoleDTO>> GetList();


    }
}
