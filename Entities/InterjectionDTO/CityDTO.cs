using Entities.Abstract;

namespace Entities.InterjectionDTO
{
    public class CityDTO : BaseDTO, IDTO
    {
        public int CountryId { get; set; }

        public string Cities { get; set; }
        public CountryDTO CountryDTO { get; set; }
    }
}
