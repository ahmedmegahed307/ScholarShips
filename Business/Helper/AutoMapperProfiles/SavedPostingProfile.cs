using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.AutoMapperProfiles
{
    public class SavedPostingProfile : Profile
    {
        public SavedPostingProfile()
        {
            CreateMap<SavedPosting, SavedPostingDTO>()
                .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))

                .ReverseMap();

            CreateMap<SavedPostingDTO, SavedPosting>()
                .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))

                .ReverseMap();

        }
    }
}
