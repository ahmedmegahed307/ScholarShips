using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.InterjectionDTO;
using Entities.Concrete;
using Business.Constants;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _ımageDal;
        private readonly IImageTypeDal _uyy;
        private readonly IMapper _mapper;

        public ImageManager(IImageDal ımageDal, IMapper mapper, IImageTypeDal uyy)
        {
            _ımageDal = ımageDal;
            _mapper = mapper;
            _uyy = uyy;

        }

        public ResultDTO<EventDTO> CreateNewEventImage(EventDTO model)
        {
            //event için resim ekleme
            ImageDTO ımageDTO = new();
            ımageDTO.EventId = model.Id;               // ilan ve resimler için ara tabloya kayıt attıgım yer
            ımageDTO.IsActive = true;
            ımageDTO.ImageTypeId = 2;
            ımageDTO.ImagePath = model.EventImagePath;

            _ımageDal.Add(_mapper.Map<Image>(ımageDTO));

            return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventImageCreated, Success = true };

        }

        public ResultDTO<PostingDTO> CreatePostingImage(PostingDTO model)
        {
            ImageDTO ımageDTO = new();
            ımageDTO.PostingId = model.Id;               // ilan ve resimler için ara tabloya kayıt attıgım yer
            ımageDTO.IsActive = true;
            ımageDTO.ImageTypeId = 2;
            ımageDTO.ImagePath = model.PostingImagePath;

            _ımageDal.Add(_mapper.Map<Image>(ımageDTO));

            return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingİmageCreated, Success = true };
        }
        //etkinlik resmi güncelle
        public ResultDTO<EventDTO> UpdateEventImage(EventDTO model)
        {
            var deleteEventImages = _ımageDal.Get(x => x.ImagePath == model.EventImagePath);
            if (deleteEventImages == null)
            {
                deleteEventImages.ImagePath = model.EventImagePath;
                _ımageDal.Update(deleteEventImages);
                return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventImageUpdated, Success = true };

            }

            deleteEventImages.ImagePath = model.EventImagePath;
            _ımageDal.Add(deleteEventImages);
            return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventImageUpdated, Success = true };

        }

        public ResultDTO<PostingDTO> UpdatePostingImage(PostingDTO model)
        {
            var deletePostingImageTables = _ımageDal.Get(a => a.ImagePath == model.PostingImagePath);  // var olan resim kayıtlarını siliyorum

            if (deletePostingImageTables == null)
            {
                deletePostingImageTables.ImagePath = model.PostingImagePath;
                _ımageDal.Update(deletePostingImageTables);

                return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingİmageUpdated, Success = true };
            }

            deletePostingImageTables.ImagePath = model.PostingImagePath;
            _ımageDal.Add(deletePostingImageTables);

            return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingİmageUpdated, Success = true };
        }
    }
}
