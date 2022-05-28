using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<DisciplineDTO, Discipline>()
                .ForMember(dest => dest.DisciplineType, opt => opt.MapFrom(src => src.DisciplineType))
              

                .ReverseMap();
            CreateMap<Discipline, DisciplineDTO>()
                .ForMember(dest => dest.DisciplineType, opt => opt.MapFrom(src => src.DisciplineType))
                

                .ReverseMap();

        }
    }
}