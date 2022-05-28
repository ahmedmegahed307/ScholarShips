using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                
                .ReverseMap();
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))

                .ReverseMap();
          


            CreateMap<Individual, UserDTO>().ReverseMap();
            CreateMap<UserDTO, Individual>().ReverseMap();
           ;

        }
    }
}
