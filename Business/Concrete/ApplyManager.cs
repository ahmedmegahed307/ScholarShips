using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace Business.Concrete
{
    public class ApplyManager : IApplyService
    {

        readonly IMapper _mapper;
        private readonly IPostingDal _postingDal;
        private readonly IApplyDal _applyDal;

        public ApplyManager(IMapper mapper, IPostingDal postingDal, IApplyDal applyDal)
        {
            _mapper = mapper;
            _postingDal = postingDal;
            _applyDal = applyDal;

        }

        public ResultDTO<CustomPostingDTO> ApplyPosting(CustomPostingDTO model)
        {
            ApplyDTO applyDTO = new();

            var applycontrol = _applyDal.Get(i => i.PostingId == model.Id && i.UserId == model.UserId);
            if (applycontrol == null)
            {
                applyDTO.UserId = model.UserId;
                applyDTO.PostingId = model.Id;
                applyDTO.CvId = model.CvId;

                _applyDal.Add(_mapper.Map<Apply>(applyDTO));

                return new ResultDTO<CustomPostingDTO> { Data = model, Message = Messages.CreatedApply, Success = true };
            }
            else
            {
                applyDTO.Id = applycontrol.Id;
                applyDTO.UserId = model.UserId;
                applyDTO.PostingId = model.Id;
                applyDTO.CvId = model.CvId;
                _applyDal.Update(_mapper.Map<Apply>(applyDTO));

            }

            return new ResultDTO<CustomPostingDTO> { Data = model, Message = Messages.UpdatedCreatedApply, Success = true };

        }
    }

}

