using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICityService
    {
        ResultDTO<List<CityDTO>> GetAllByCountryId(int id);
    }
}
