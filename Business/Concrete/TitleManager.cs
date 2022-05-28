using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;
        private readonly IMapper _mapper;

        public TitleManager(IMapper mapper, ITitleDal titleDal)
        {
            _mapper = mapper;
            _titleDal = titleDal;
        }

        public ResultDTO<List<TitleDTO>> GetList()
        {
            var titles = _titleDal.GetAll();
            var mapper= _mapper.Map<List<TitleDTO>>(titles);
            return new ResultDTO<List<TitleDTO>> {Data = mapper,Message = Messages.TitleListed,Success = true};
        }


    }
}
