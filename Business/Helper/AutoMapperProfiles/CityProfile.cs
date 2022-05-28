using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>()
                .ForMember(dest => dest.CountryDTO, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.CityName))


                .ReverseMap();
            CreateMap<CityDTO, City>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryDTO))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Cities))
                .ReverseMap();
        }
    }
}