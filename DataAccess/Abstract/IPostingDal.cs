using System.Collections.Generic;
using Entities.Concrete;
using Entities.InterjectionDTO;

namespace DataAccess.Abstract
{
    public interface IPostingDal : IEntityRepository<Posting>
    {
        List<PostingDTO> GetListAll(int Id, int skip);
        List<PostingDTO> GetListFalseAll(int Id);
        List<PostingDTO> GetListAll();
        PostingDTO GetPosting(int Id);
        List<PostingDTO> GetFilteredList(CustomPostingDTO p);
        List<UserInterestedPosting> GetSPPostingList(int Id);


    }
}