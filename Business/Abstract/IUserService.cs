
using Entities.Concrete;
using Entities.InterjectionDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService 
    {
        ResultDTO<UserDTO> SignIn(string EmailAdress, string Password);
        ResultDTO<UserDTO> GetById(int id);
        ResultDTO<UserDTO> GetByMail(string email);
        //Google Login
        ResultDTO<UserDTO> GetUsersByMail(string email);

        ResultDTO<UserDTO> SignInWithGoogle(string EmailAddress);
        



    }
}
