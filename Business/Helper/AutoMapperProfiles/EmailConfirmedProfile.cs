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
    public class EmailConfirmedProfile : Profile
    {
        public EmailConfirmedProfile()
        {
            CreateMap<EmailConfirmed, EmailConfirmedDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.EmailConfirmedCode, opt => opt.MapFrom(src => src.EmailConfirmedCode))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))


                .ReverseMap();
            CreateMap<EmailConfirmedDTO, EmailConfirmed>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.EmailConfirmedCode, opt => opt.MapFrom(src => src.EmailConfirmedCode))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ReverseMap();
        }
    }
}
