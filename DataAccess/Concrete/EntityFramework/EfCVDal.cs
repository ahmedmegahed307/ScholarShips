using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCVDal : EfEntityRepositoryBase<CV, DataContext>, ICVDal
    {
        public List<PostingDTO> GetPosting(int Id)
        {
            using (var context = new DataContext())
            {

                var deneme = (from d1 in context.Postings
                              join d2 in context.Disciplines
                              on d1.DisciplineId equals d2.Id
                              join d3 in context.Titles
                              on d1.TitleId equals d3.Id
                              join d4 in context.PostingTypes
                              on d1.PostingTypeId equals d4.Id

                              join d5 in context.CVs
                              on d1.UserId equals d5.UserId
                              where d5.UserId == Id


                              //where d1.IsActive == true

                              select new PostingDTO
                              {
                                  Id = d1.Id,
                                  IsActive = d1.IsActive,
                                  DisciplineId = d2.Id,
                                  DisciplineType = d2.DisciplineType,
                                  TitleId = d3.Id,
                                  TitleType = d3.TitleType,
                                  PostingTypeId = d4.Id,
                                  PostingType = d4.Type,
                                  CVPath=d5.CvPath,
                                  CvId= d5.Id

                              }).ToList();
                return deneme;
            }
        }
    }
}
