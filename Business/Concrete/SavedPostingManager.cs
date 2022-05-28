using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class SavedPostingManager : ISavedPostingService
    {
        private readonly ISavedPostingDal _savedPostingDal;
        readonly IMapper _mapper;


        public SavedPostingManager(ISavedPostingDal savedPostingDal, IMapper mapper)
        {
            _savedPostingDal = savedPostingDal;
            _mapper = mapper;

        }
        public ResultDTO<SavedPostingDTO> SavedPostingDTO(SavedPostingDTO model)
        {
            var savedposting = _savedPostingDal.Get(q => q.UserId == model.UserId && q.PostingId == model.PostingId);

            if (savedposting != null)
            {
                model.Id = savedposting.Id;

                if (savedposting.IsActive == true)
                {
                    model.IsActive = false;
                    _savedPostingDal.Update(_mapper.Map<SavedPosting>(model));

                    return new ResultDTO<SavedPostingDTO> { Data = model, Message = Messages.SavedPostingDelete, Success = true };

                }
                else
                {
                    model.IsActive = true;
                    _savedPostingDal.Update(_mapper.Map<SavedPosting>(model));

                    return new ResultDTO<SavedPostingDTO> { Data = model, Message = Messages.SavedPosting, Success = true };

                }

            }
            else
            {
                model.IsActive = true;
                _savedPostingDal.Add(_mapper.Map<SavedPosting>(model));

                return new ResultDTO<SavedPostingDTO> { Data = model, Message = Messages.SavedPosting, Success = true };
            }
        }
    }
}
