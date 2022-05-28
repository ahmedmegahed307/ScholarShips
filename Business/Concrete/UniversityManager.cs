using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UniversityManager: IUniversityService
    {
        private readonly IUniversityDal _universityDal;
        readonly IMapper _mapper;
        public UniversityManager(IUniversityDal universityDal, IMapper mapper)
        {
            _universityDal = universityDal;
            _mapper = mapper;
        }
        public ResultDTO<List<UniversityDTO>> GetUniversity(int id)
        {

            var universities = _universityDal.GetAll(i => i.CountryId == id);
            var mapper = _mapper.Map<List<UniversityDTO>>(universities);
            return new ResultDTO<List<UniversityDTO>> { Data = mapper, Message = Messages.CountryByCity, Success = true };

        }

    }
}
