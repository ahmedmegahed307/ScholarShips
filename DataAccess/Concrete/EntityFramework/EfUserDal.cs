using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;

using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,DataContext>,IUserDal
    {
        //kullanıcının açtığı ilanlar.
        public UserDTO GetListAllEmailUsers(string mail)
        {
            using (var context = new DataContext())
            {

                var values = (from d1 in context.Individuals
                              where d1.Email==mail
                              



                              select new UserDTO
                              {
                                  Id = d1.Id,
                                  Email = d1.Email,
                                  FirstName = d1.FirstName,
                                  LastName = d1.LastName
                                  
                              }).FirstOrDefault();
                return values;
            }


            
        }

       
    }
}
