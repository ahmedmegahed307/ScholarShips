using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class DisciplineManager : IDisciplineService
    {
        private readonly IDisciplineDal _disciplineDal;
        readonly IMapper _mapper;
        public DisciplineManager(IDisciplineDal disciplineDal, IMapper mapper)
        {
            _disciplineDal = disciplineDal;
            _mapper = mapper;

        }

        public ResultDTO<List<DisciplineDTO>> GetList()
        {
            var disciplines = _disciplineDal.GetAll();
            var mapper= _mapper.Map<List<DisciplineDTO>>(disciplines);
            return new ResultDTO<List<DisciplineDTO>> {Data = mapper,Message = Messages.DisciplineListed,Success = true};
        }

      
    }
}
