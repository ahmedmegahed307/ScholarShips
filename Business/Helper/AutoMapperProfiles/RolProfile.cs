using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                .ReverseMap();
            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))

                .ReverseMap();
        }

    }
}