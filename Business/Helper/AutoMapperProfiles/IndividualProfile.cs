using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Helper.AutoMapperProfiles
{
    public class IndividualProfile : Profile
    {
        public IndividualProfile()
        {
            //Update
            CreateMap<Individual, UpdateUserDTO>().ReverseMap();
            CreateMap<UpdateUserDTO, Individual>().ReverseMap();
           
            //Register
            CreateMap<RegisterDTO, Individual>().ReverseMap();
            CreateMap<Individual, RegisterDTO>().ReverseMap();





        }
    }
}
