using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;

using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
           
        }
        public ResultDTO<UserDTO> GetById(int id)
        {
            var result = _userDal.Get(c => c.Id == id);
            var mapper = _mapper.Map<UserDTO>(result);
            return new ResultDTO<UserDTO> { Data = mapper, Success = true };
        }

        public ResultDTO<UserDTO> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            var mapper = _mapper.Map<UserDTO>(result);
            return new ResultDTO<UserDTO> { Data = mapper, Success = true };
        }

        //maile göre listele - google Login
        public ResultDTO<UserDTO> GetUsersByMail(string email)
        {
            var model = _userDal.GetListAllEmailUsers(email);
            //var mapper = _mapper.Map<UserDTO>(model);
            return new ResultDTO<UserDTO> { Data = model, Message = Messages.EventListed, Success = true };
        }

        

        public ResultDTO<UserDTO> SignIn(string email,string password)
        {
            string encodePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var model = _userDal.Get(u => u.Email == email && u.Password == encodePassword);
            var mapper = _mapper.Map<UserDTO>(model);
            if (mapper != null)
            {
                return new ResultDTO<UserDTO> { Data = mapper, Success = true };
            }
            else
            {
                return new ResultDTO<UserDTO> { Data =null, Success = false };
            }
            
        }

        public ResultDTO<UserDTO> SignInWithGoogle(string EmailAddress)
        {
            var model = _userDal.Get(x => x.Email == EmailAddress);
            var mapper = _mapper.Map<UserDTO>(model);
            if (mapper != null)
            {
                return new ResultDTO<UserDTO> { Data = mapper, Success = true };
            }
            else
            {
                return new ResultDTO<UserDTO> { Data = null, Success = false };
            }

        }
    }
}
