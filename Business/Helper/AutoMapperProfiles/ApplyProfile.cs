using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class ApplyProfile : Profile
    {
        public ApplyProfile()
        {
            CreateMap<ApplyDTO, Apply>()
               .ForMember(dest => dest.CvId, opt => opt.MapFrom(src => src.CvId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))


               .ReverseMap();
            CreateMap<Apply, ApplyDTO>()
               .ForMember(dest => dest.CvId, opt => opt.MapFrom(src => src.CvId))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))
                .ReverseMap();

        }
    }
}