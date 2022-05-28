using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfApplyDal : EfEntityRepositoryBase<Apply,DataContext>,IApplyDal
    {
        public List<ApplicantsPostingDTO> GetListAll(int Id, int skip)
        {
            using (var context = new DataContext())
            {
                //TODO: mehmet user tablosundan image i kaldırdım.Burayı kontrol edip revize et..
                var deneme = (from d1 in context.Applies.OrderBy(p => p.Id)

                              join d2 in context.CVs
                              on d1.CvId equals d2.Id
                              join d3 in context.Individuals
                              on d1.UserId equals d3.Id
                              join d5 in context.Images
                              on d2.UserId equals d5.UserId
                              where d1.PostingId == Id
                              select new ApplicantsPostingDTO
                              {
                                  Id = d1.UserId,
                                  CVPath = d2.CvPath,
                                  CityId = d2.UserId,
                                  FirstName = d3.FirstName,
                                  LastName = d3.LastName,
                                  ProfilPhotoPath = d5.ImagePath,

                              }).Skip((skip - 1) * 1).Take(1).ToList();


                return deneme;
            }
        }
    }
}
