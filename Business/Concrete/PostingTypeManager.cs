using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PostingTypeManager : IPostingTypeService
    {
        private readonly IPostingTypeDal _postingTypeDal;
        readonly IMapper _mapper;

        public PostingTypeManager(IPostingTypeDal postingTypeDal, IMapper mapper)
        {
            _postingTypeDal = postingTypeDal;
            _mapper = mapper;
        }

        public ResultDTO<List<PostingTypeDTO>> GetListPostingTypeDTO()
        {
            var postingtypes = _postingTypeDal.GetAll();

            var map= _mapper.Map<List<PostingTypeDTO>>(postingtypes);
            return new ResultDTO<List<PostingTypeDTO>> { Data = map, Message = Messages.PostingTypeListed, Success = true };

        }
    }
}
