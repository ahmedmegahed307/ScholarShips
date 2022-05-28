using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPostingService 
    {
        ResultDTO<CustomPostingDTO> GetPostingAll(int Id);   // tüm postları getirmek için kullandıgım metod ( id sitede gezinen kişinin idsi cvleri çekmek için)
        ResultDTO<PostingDTO> CreatePosting(PostingDTO model);   //  ilan oluşturma
        void DeletePosting(int Id);            // ilan silme
        ResultDTO<PostingDTO> UpdatePosting(PostingDTO model);      // ilan güncelleme
        ResultDTO<CustomPostingDTO> GetUserPostingAll(int Id , int skip);   // userin açmış oldugu bütün ilanlarını getirir
        ResultDTO<CustomPostingDTO> GetApplicantsPosting(int Id, int skip);   // userin açmış oldugu bütün ilanlarını getirir

        ResultDTO<PostingDTO> GetPosting(int Id);           // belirtilen ilanı getirir
        ResultDTO<CVDTO> UpdateCv(CVDTO model);             // cv yükleme 

        ResultDTO<CustomPostingDTO> GetList(CustomPostingDTO p);
        ResultDTO<CustomPostingDTO> GetFilteredList(CustomPostingDTO p);


    }
}
