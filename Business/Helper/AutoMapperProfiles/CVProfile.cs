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
    public class CVProfile:Profile
    {
        public CVProfile()
        {
            CreateMap<CV, CVDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CvPath, opt => opt.MapFrom(src => src.CvPath))


                .ReverseMap();
            CreateMap<CVDTO, CV>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CvPath, opt => opt.MapFrom(src => src.CvPath))
                .ReverseMap();
        }
    }
}
