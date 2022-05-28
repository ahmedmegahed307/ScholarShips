using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDisciplineDal : EfEntityRepositoryBase<Discipline, DataContext>, IDisciplineDal
    {
        public List<Discipline> GetListAll()
        {
            using (var c = new DataContext())
            {
                return c.Disciplines
                    
                   .Include(x => x.DisciplineType).ToList();
                    

            }
        }
    }
}
