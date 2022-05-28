using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        //List<EventDTO> GetListAll();
        List<EventDTO> GetListAll(int Id);
        List<EventDTO> GetListAll();//tüm event'ları listeleyecek
        //sadece seçili event'ın bilgilerini getir
        EventDTO GetSelectedEvent(int Id);

    }
}