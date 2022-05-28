using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        readonly IMapper _mapper;
        private readonly IEventDal _eventDal;
        private readonly IImageDal _imageDal;


        public EventManager(IMapper mapper, IEventDal eventDal,IImageDal imageDal)
        {
            _mapper = mapper;
            _eventDal = eventDal;
            _imageDal = imageDal;
        }
        //etkinlik oluşturma
        public ResultDTO<EventDTO> CreateEvent(EventDTO model)
        {
            //TODO: bu deneme gibi console çıktıları kaldırılsın
            System.Console.WriteLine("deneme");
            //etkinlik oluştur.
            var eventCount = _eventDal.GetAll(x => x.UserId == model.UserId);
            System.Console.WriteLine("deneme2");

            if (eventCount.Count<20)
            {
                model.CreateDate = System.DateTime.Now;
               
                model.CreateUser = 1; //TODO:Bu ne?? Kullanıcı event oluşturuyor dto ile gelmeli bilgisi
                model.IsActive = true;
                var mapper = _mapper.Map<Event>(model);

                
                _eventDal.Add(mapper);
                model.Id = mapper.Id;
                return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventCreated, Success = true };//Eğer 
                //kullanıcının 20'den fazla ilanı yoksa ekleyebilir. Ama varsa ekleme yeni ilan oluşturma yapılamaz.
            }
            else
            {
                return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventNotCreated, Success = true };
            }
        }

        //seçilen id'ye ait event'ı sil
        public ResultDTO<EventDTO> DeleteSelectedEvent(int Id)
        {
            EventDTO selectedEventDTO = new();

            var deleteEvent = _eventDal.Get(x => x.Id == Id && x.IsActive == true);  // deger varmı yokmu kontrolünü yapıyorum.

            var deleteEventImages = _imageDal.GetAll(y => y.PostingId == Id && y.IsActive == true);  // var olan kayıtları siliyorum

            foreach (var item in deleteEventImages)
            {
                var deleteEventImageTables = _imageDal.Get(a => a.Id == item.Id);  // var olan kayıtları siliyorum
                deleteEventImageTables.IsActive = false;
                _imageDal.Update(deleteEventImageTables);
            }

            deleteEvent.IsActive = false;
            _eventDal.Update(deleteEvent);
            //TODO:selectedEventDTO oluşturulup boş döndürülüyor, gereksiz burdadönüş tipi değiştirilip revize edilebilir
            return new ResultDTO<EventDTO> { Data = selectedEventDTO, Message = Messages.EventDeleted, Success = true };
           

        }

        public ResultDTO<List<EventDTO>> GetAllEvents()
        {
            var model = _eventDal.GetListAll();
            for (int i = 0; i < model.Count; i++)
            {
                var imageCount = _imageDal.GetAll(x => x.EventId == model[i].Id);
                if (imageCount.Count == 1)
                {
                    model[i].EventImage = imageCount[0].ImagePath;
                }

            }
            return new ResultDTO<List<EventDTO>> { Data = model, Message = Messages.EventListed, Success = true };
        }

        //sadece seçili etkinliği bana getir.
        public ResultDTO<EventDTO> GetSelectedEvent(int Id)
        {
            var model = _eventDal.GetSelectedEvent(Id);
            return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventListed, Success = true };

        }

        /*
        public ResultDTO<EventDTO> CreateEvent(EventDTO model)
        {

            model.CreateDate= System.DateTime.Now;
            model.CreateUser = 1;
            model.IsActive = true;                                                
            var mapper = _mapper.Map<Event>(model);

            _eventDal.Add(mapper);
            model.Id = mapper.Id;

            return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventAdded, Success = true };
        }
        */

        //tüm event'lar gelecek
        /*
        public ResultDTO<List<EventDTO>> GetAllEvent()
        {
            var model = _eventDal.GetListAll();
            var value = _mapper.Map<List<EventDTO>>(model);
            return new ResultDTO<List<EventDTO>> { Data = value, Message = Messages.EventListed, Success = true };
        }

        public ResultDTO<List<EventDTO>> GetEvent(int id)
        {
            var model = _eventDal.GetListAll(id);
            var value = _mapper.Map<List<EventDTO>>(model);
            return new ResultDTO<List<EventDTO>> { Data = value, Message = Messages.EventListed, Success = true };

        }
        */
        //kullanıcının açtığı tüm event'lar gelecek

        public ResultDTO<List<EventDTO>> GetUserEvent(int Id)
        {
            var model = _eventDal.GetListAll(Id);
            for(int i = 0; i < model.Count; i++)
            {
                var imageCount = _imageDal.GetAll(x => x.EventId == model[i].Id);
                if (imageCount.Count == 1) { 
                    model[i].EventImage = imageCount[0].ImagePath;
                }

            }
            return new ResultDTO<List<EventDTO>> { Data = model, Message = Messages.EventListed, Success = true };
        }
        //Etkinlik güncelle
        public ResultDTO<EventDTO> UpdateEvent(EventDTO model)
        {
            var eventsUpdated = _eventDal.Get(x => x.Id == model.Id);//event var mı kontrolü yapılır.
            model.Id = eventsUpdated.Id;
            model.IsActive = true;
            var mapper = _mapper.Map<Event>(model);
            _eventDal.Update(mapper);
            return new ResultDTO<EventDTO> { Data = model, Message = Messages.EventUpdated, Success = true };

        }




        /*
        public ResultDTO<List<EventDTO>> GetEventsAll()
        {

            var model = _eventDal.GetAll();


            return new ResultDTO<List<EventDTO>> { Data = model, Message = Messages.PostingListed, Success = true };
        }








    }

    public ResultDTO<List<EventDTO>> GetEvent(int id)
    {
        throw new System.NotImplementedException();
    }
        */
    }
}
