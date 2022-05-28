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
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>()
                .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))
                .ForMember(dest => dest.ImageTypeId, opt => opt.MapFrom(src => src.ImageTypeId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))


                .ReverseMap();
            CreateMap<ImageDTO, Image>()
                .ForMember(dest => dest.PostingId, opt => opt.MapFrom(src => src.PostingId))
                .ForMember(dest => dest.ImageTypeId, opt => opt.MapFrom(src => src.ImageTypeId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ReverseMap();
        }
    }
}
