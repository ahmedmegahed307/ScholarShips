using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;


namespace Business.Concrete
{

    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        readonly IMapper _mapper;
        public CountryManager(ICountryDal countryDal, IMapper mapper)
        {
            _countryDal = countryDal;
            _mapper = mapper;
        }

        public ResultDTO<List<CountryDTO>> GetList()
        {
            var country = _countryDal.GetAll();
            var mapper= _mapper.Map<List<CountryDTO>>(country);
            return new ResultDTO<List<CountryDTO>>{Data = mapper,Message = Messages.CountryListed,Success = true};
        }
    }
    
}
