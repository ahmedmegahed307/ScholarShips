using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        readonly IMapper _mapper;

        public CityManager(ICityDal cityDal,IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;

        }

        public ResultDTO<List<CityDTO>> GetAllByCountryId(int id)
        {

            var cities = _cityDal.GetAll(i => i.CountryId == id); 
            var mapper = _mapper.Map<List<CityDTO>>(cities);
            return new ResultDTO<List<CityDTO>> { Data = mapper, Message = Messages.CountryByCity, Success = true };

        }
    }
}
