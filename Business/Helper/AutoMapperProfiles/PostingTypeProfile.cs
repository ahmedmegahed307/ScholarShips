using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;


namespace Business.Helper.AutoMapperProfiles
{
    public class PostingTypeProfile : Profile
    {
        public PostingTypeProfile()
        {
            CreateMap<PostingType, PostingTypeDTO>()
                .ForMember(dest => dest.PostingType, opt => opt.MapFrom(src => src.Type))


                .ReverseMap();
            CreateMap<PostingTypeDTO, PostingType>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.PostingType))


                .ReverseMap();

        }
    }
}
