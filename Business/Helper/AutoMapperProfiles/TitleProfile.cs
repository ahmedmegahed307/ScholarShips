using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class TitleProfile :Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleDTO>()
                .ForMember(dest => dest.TitleType, opt => opt.MapFrom(src => src.TitleType))
                

                .ReverseMap();
            CreateMap<TitleDTO, Title>()
                .ForMember(dest => dest.TitleType, opt => opt.MapFrom(src => src.TitleType))
                

                .ReverseMap();
        }
    }
}
