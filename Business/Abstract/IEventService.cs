using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEventService 
    {
        //ResultDTO<List<EventDTO>> GetEvent(int id);
        //ResultDTO<List<EventDTO>> GetAllEvent();
        //ResultDTO<EventDTO> CreateEvent(EventDTO model);
        ResultDTO<List<EventDTO>> GetAllEvents();//tüm event'lar gelecek
        ResultDTO<List<EventDTO>> GetUserEvent(int Id);//kullanıcının açtığı tüm event'ları getirecek
        ResultDTO<EventDTO> DeleteSelectedEvent(int Id);//seçili id'ye ait event'ı sil

        ResultDTO<EventDTO> CreateEvent(EventDTO model);//Etkinlik oluşturma
        ResultDTO<EventDTO> UpdateEvent(EventDTO model);//Etkinlik güncelleme
        ResultDTO<EventDTO> GetSelectedEvent(int Id);//sadece seçili event'ı bana getir




    }
}
