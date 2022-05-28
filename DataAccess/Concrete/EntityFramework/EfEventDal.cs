using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : EfEntityRepositoryBase<Event, DataContext>, IEventDal
    {
        /*
        public List<EventDTO> GetListAll()
        {
            using (var context = new DataContext())
            {

                var values = (from d1 in context.Events
                              
                              select new EventDTO
                              {
                                  Id = d1.Id,
                                  EventTitle = d1.EventTitle,
                                  EventRemark = d1.EventRemark,
                                  EventPhotoPath = d1.EventPhotoPath,
                                  DeadLine = d1.DeadLine





                              }).ToList();
                return values;




            }
        */
        //kullanıcının açtığı ilanlar.
        public List<EventDTO> GetListAll(int Id)
        {
            using (var context = new DataContext())
            {

                var deneme = (from d1 in context.Events
                              where d1.UserId == Id
                              where d1.IsActive==true


                              select new EventDTO
                              {
                                  Id = d1.Id,
                                  
                                  EventTitle = d1.EventTitle,
                                  EventRemark = d1.EventRemark,
                                  EventPhotoPath = d1.EventPhotoPath,
                                  DeadLine = d1.DeadLine
                                  
                              }).ToList();
                return deneme;
            }
        }
        //tüm aktif ilanlar

        public List<EventDTO> GetListAll()
        {
            using (var context = new DataContext())
            {

                var deneme = (from d1 in context.Events
                              where d1.IsActive == true



                              select new EventDTO
                              {
                                  Id = d1.Id,
                                  EventTitle = d1.EventTitle,
                                  EventRemark = d1.EventRemark,
                                  EventPhotoPath = d1.EventPhotoPath,
                                  DeadLine = d1.DeadLine
                              }).ToList();
                return deneme;
            }
        }
        //sadece seçili event'ı getirir.
        public EventDTO GetSelectedEvent(int Id)
        {
            using (var context = new DataContext())
            {

                var values = (from d1 in context.Events
                              where d1.IsActive == true
                              where d1.Id == Id



                              select new EventDTO
                              {
                                  Id = d1.Id,
                                  EventTitle = d1.EventTitle,
                                  EventRemark = d1.EventRemark,
                                  EventPhotoPath = d1.EventPhotoPath,
                                  DeadLine = d1.DeadLine
                              }).FirstOrDefault();
                return values;
            }
        }
    }
}
