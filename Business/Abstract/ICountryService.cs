using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICountryService 
    {
        ResultDTO<List<CountryDTO>> GetList();

    }
}
