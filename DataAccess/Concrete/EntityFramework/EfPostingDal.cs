using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostingDal : EfEntityRepositoryBase<Posting, DataContext>, IPostingDal
    {


        public List<PostingDTO> GetFilteredList(CustomPostingDTO p)
        {
           

            if (p.DisciplineId != 0 && p.PostingTypeId != 0 && p.CountryId != 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id

                                  where d1.IsActive == true
                                  where d1.DisciplineId == p.DisciplineId
                                  where d1.PostingTypeId == p.PostingTypeId
                                  where d1.TitleId == p.TitleId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId == 0 && p.CountryId != 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.DisciplineId == p.DisciplineId
                                  where d1.TitleId == p.TitleId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,


                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId != 0 && p.CountryId == 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id


                                  where d1.IsActive == true
                                  where d1.DisciplineId == p.DisciplineId
                                  where d1.TitleId == p.TitleId
                                  where d1.PostingTypeId == p.PostingTypeId
                                 

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId != 0 && p.CountryId != 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.TitleId == p.TitleId
                                  where d1.PostingTypeId == p.PostingTypeId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,


                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId != 0 && p.CountryId != 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.PostingTypeId == p.PostingTypeId
                                  where d1.DisciplineId == p.DisciplineId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId == 0 && p.CountryId == 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.TitleId == p.TitleId
                                  where d1.DisciplineId == p.DisciplineId


                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId == 0 && p.CountryId != 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.TitleId == p.TitleId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId == 0 && p.CountryId != 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true
                                  where d1.DisciplineId == p.DisciplineId
                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId != 0 && p.CountryId == 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d1.TitleId == p.TitleId
                                  where d1.PostingTypeId == p.PostingTypeId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId != 0 && p.CountryId == 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d1.DisciplineId == p.DisciplineId
                                  where d1.PostingTypeId == p.PostingTypeId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId != 0 && p.CountryId != 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d5.CountryId == p.CountryId
                                  where d1.PostingTypeId == p.PostingTypeId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId == 0 && p.CountryId == 0 && p.TitleId != 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d1.TitleId == p.TitleId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId != 0 && p.PostingTypeId == 0 && p.CountryId == 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d1.DisciplineId == p.DisciplineId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId == 0 && p.CountryId != 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d5.CountryId == p.CountryId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else if (p.DisciplineId == 0 && p.PostingTypeId != 0 && p.CountryId == 0 && p.TitleId == 0)
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  where d1.PostingTypeId == p.PostingTypeId

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }
            else
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
                                  join d5 in context.University
                                  on d1.UniversityId equals d5.Id
                                  join d6 in context.Users
                                  on d1.UserId equals d6.Id

                                  where d1.IsActive == true

                                  select new PostingDTO
                                  {
                                      Id = d1.Id,
                                      Remark = d1.Remark,
                                      Budget = d1.Budget,
                                      Quota = d1.Quota,
                                      Hours = d1.Hours,
                                      StartTime = d1.StartTime,
                                      FinishTime = d1.FinishTime,
                                      IsActive = d1.IsActive,
                                      DisciplineId = d2.Id,
                                      DisciplineType = d2.DisciplineType,
                                      TitleId = d3.Id,
                                      TitleType = d3.TitleType,
                                      PostingTypeId = d4.Id,
                                      PostingType = d4.Type,
                                      UniversityName = d5.Name,
                                      CountryId = d5.CountryId,
                                      UserId = d6.Id,



                                  }).ToList();
                    return deneme;
                }
            }

            //List<PostingDTO> cc = new List<PostingDTO>();
            //return cc;

        }

        public List<PostingDTO> GetListAll(int Id , int skip)              // belirtilen user idli bütün ilanları döndürür
        {
            using (var context = new DataContext())
            {

                var deneme = (from d1 in context.Postings.OrderByDescending(p => p.Id)
                              join d2 in context.Disciplines
                              on d1.DisciplineId equals d2.Id
                              join d3 in context.Titles
                              on d1.TitleId equals d3.Id
                              join d4 in context.PostingTypes
                              on d1.PostingTypeId equals d4.Id
                              join d5 in context.University
                              on d1.UniversityId equals d5.Id
                              where d1.IsActive == true
                              where d1.UserId == Id

                              select new PostingDTO
                              {
                                  Id = d1.Id,
                                  Remark = d1.Remark,
                                  Budget = d1.Budget,
                                  Quota = d1.Quota,
                                  Hours = d1.Hours,
                                  StartTime = d1.StartTime,
                                  FinishTime = d1.FinishTime,
                                  IsActive = d1.IsActive,
                                  DisciplineId = d2.Id,
                                  DisciplineType = d2.DisciplineType,
                                  TitleId = d3.Id,
                                  TitleType = d3.TitleType,
                                  PostingTypeId = d4.Id,
                                  PostingType = d4.Type,
                                  UniversityName = d5.Name
                              }).Skip((skip - 1) * 2).Take(2).ToList();
                //TODO: Performansı etkileyen bir yöntem olduğunu biliyorum ama aktif postingleri çektiğimiz için data çok büyümeyecek şimdilik kalabilir
                return deneme;
            }
        }
        public List<PostingDTO> GetListFalseAll(int Id)              // belirtilen user idli bütün ilanları döndürür
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
                              join d5 in context.University
                              on d1.UniversityId equals d5.Id
                              where d1.IsActive == false
                              where d1.UserId == Id

                              select new PostingDTO
                              {
                                  Id = d1.Id,
                                  Remark = d1.Remark,
                                  Budget = d1.Budget,
                                  Quota = d1.Quota,
                                  Hours = d1.Hours,
                                  StartTime = d1.StartTime,
                                  FinishTime = d1.FinishTime,
                                  IsActive = d1.IsActive,
                                  DisciplineId = d2.Id,
                                  DisciplineType = d2.DisciplineType,
                                  TitleId = d3.Id,
                                  TitleType = d3.TitleType,
                                  PostingTypeId = d4.Id,
                                  PostingType = d4.Type,
                                  UniversityName = d5.Name
                              }).ToList();
                return deneme;
            }
        }
        public List<PostingDTO> GetListAll()          // bütün ilanları döndürür
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
                              join d5 in context.University
                              on d1.UniversityId equals d5.Id
                              join d6 in context.Users
                              on d1.UserId equals d6.Id

                              where d1.IsActive == true

                              select new PostingDTO
                              {
                                  Id = d1.Id,
                                  Remark = d1.Remark,
                                  Budget = d1.Budget,
                                  Quota = d1.Quota,
                                  Hours = d1.Hours,
                                  StartTime = d1.StartTime,
                                  FinishTime = d1.FinishTime,
                                  IsActive = d1.IsActive,
                                  DisciplineId = d2.Id,
                                  DisciplineType = d2.DisciplineType,
                                  TitleId = d3.Id,
                                  TitleType = d3.TitleType,
                                  PostingTypeId = d4.Id,
                                  PostingType = d4.Type,
                                  UniversityName = d5.Name,
                                  CountryId = d5.CountryId,
                                  UserId = d6.Id,



                              }).ToList();
                return deneme;
            }

        }
        public PostingDTO GetPosting(int Id)                    //belirtilen id li ilanı döndürür
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
                              join d5 in context.University
                              on d1.UniversityId equals d5.Id
                              where d1.IsActive == true
                              where d1.Id == Id

                              select new PostingDTO
                              {
                                  Id = d1.Id,
                                  Remark = d1.Remark,
                                  Budget = d1.Budget,
                                  Quota = d1.Quota,
                                  Hours = d1.Hours,
                                  StartTime = d1.StartTime,
                                  FinishTime = d1.FinishTime,
                                  IsActive = d1.IsActive,
                                  DisciplineId = d2.Id,
                                  DisciplineType = d2.DisciplineType,
                                  TitleId = d3.Id,
                                  TitleType = d3.TitleType,
                                  PostingTypeId = d4.Id,
                                  PostingType = d4.Type,
                                  UniversityName = d5.Name

                              }).FirstOrDefault();
                return deneme;
            }
        }
        public List<UserInterestedPosting> GetSPPostingList(int Id)       // şuan çalışıyor ama ana sayfayla baglantısı yapılmadı, indivisualda degişiklikler yapılacak diye.
        {
            List<UserInterestedPosting> p = new();
            SqlParameter pIndividualId;
            List<IndividualDTO> result = new List<IndividualDTO>();
            var db = new DataContext();
            var userfilter = db.Individuals.Where(i => i.Id == Id).FirstOrDefault();
            if (userfilter.DisciplineId != null && userfilter.TitleId != null) // burası user profilini doldurmamıssa store procedure e girmememesi için kontrolü saglıyor
            {
                pIndividualId = new SqlParameter("@IndividualId", Id);

                var fileredata = db.UserInterestedPostings.FromSqlRaw($"[PostingProcedure]@IndividualId", pIndividualId).ToList();


                    return fileredata;
            }
            return p;
        }


    }
}
