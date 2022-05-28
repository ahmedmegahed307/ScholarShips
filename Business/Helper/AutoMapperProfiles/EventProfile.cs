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
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDTO>()
                
                .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.EventTitle))
                .ForMember(dest => dest.EventRemark, opt => opt.MapFrom(src => src.EventRemark))
                .ForMember(dest => dest.EventPhotoPath, opt => opt.MapFrom(src => src.EventPhotoPath))
                 .ForMember(dest => dest.DeadLine, opt => opt.MapFrom(src => src.DeadLine))
                  .ForMember(dest => dest.CreateEvent, opt => opt.MapFrom(src => src.CreateEvent))
                   .ForMember(dest => dest.UpdateDeadLine, opt => opt.MapFrom(src => src.UpdateDeadLine))
                   .ForMember(dest => dest.UpdateEvent, opt => opt.MapFrom(src => src.UpdateEvent))
                  





                .ReverseMap();
            CreateMap<EventDTO, Event>()

                .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.EventTitle))
                .ForMember(dest => dest.EventRemark, opt => opt.MapFrom(src => src.EventRemark))
                .ForMember(dest => dest.EventPhotoPath, opt => opt.MapFrom(src => src.EventPhotoPath))
                .ForMember(dest => dest.DeadLine, opt => opt.MapFrom(src => src.DeadLine))
                .ForMember(dest => dest.CreateEvent, opt => opt.MapFrom(src => src.CreateEvent))
                   .ForMember(dest => dest.UpdateDeadLine, opt => opt.MapFrom(src => src.UpdateDeadLine))
                   .ForMember(dest => dest.UpdateEvent, opt => opt.MapFrom(src => src.UpdateEvent))
                   


                .ReverseMap();
        }
    }
}
