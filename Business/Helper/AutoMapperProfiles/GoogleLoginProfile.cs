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
    public class GoogleLoginProfile : Profile
    {
        public GoogleLoginProfile()
        {
            CreateMap<User, GoogleLoginDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            CreateMap<User, GoogleLoginDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))

                .ReverseMap();
            CreateMap<Individual, GoogleLoginDTO>().ReverseMap();
            CreateMap<GoogleLoginDTO, Individual>().ReverseMap();




        }
    }
}
