using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries))

                .ReverseMap();
            CreateMap<CountryDTO, Country>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries))

                .ReverseMap();
        }
    }
}