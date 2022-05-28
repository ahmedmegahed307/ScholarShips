using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class PostingProfile : Profile
    {
        public PostingProfile()
        {
            CreateMap<Posting, PostingDTO>()
                
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => src.FinishTime))

                .ReverseMap();
            CreateMap<PostingDTO, Posting>()
               
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => src.FinishTime))
                
                .ReverseMap();
            CreateMap<UserInterestedPosting, PostingDTO>()

                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.Name))

                .ReverseMap();
        }

    }
}