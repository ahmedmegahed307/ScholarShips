using Entities.InterjectionDTO;

namespace Business.Abstract
{
    public interface IApplyService 
    {
        ResultDTO<CustomPostingDTO> ApplyPosting(CustomPostingDTO model);

    }
}
