using Entities.InterjectionDTO;

namespace Business.Abstract
{
    public interface IImageService 
    {
        //IDataResult<PostingDTO> CreatePostingImage(PostingDTO model);
        //IDataResult<PostingDTO> UpdatePostingImage(PostingDTO model);

        //posting resimleri
        ResultDTO<PostingDTO> CreatePostingImage(PostingDTO model);

        ResultDTO<PostingDTO> UpdatePostingImage(PostingDTO model);

        ResultDTO<EventDTO> CreateNewEventImage(EventDTO model);//etkinlik açarken resim ekleme seçme işlemi 
        ResultDTO<EventDTO> UpdateEventImage(EventDTO model);//etkinlik resmini güncelleme yapar.



    }
}
