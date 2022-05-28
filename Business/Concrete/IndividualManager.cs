using System;
using System.Collections.Generic;
using System.Linq;
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
    public class IndividualManager : IIndividualService
    {
        private readonly IIndividualDal _individualDal;
        private readonly IUserService _userService;
        private readonly IUserRoleDal _userRoleDal;
        private readonly IImageDal _ımageDal;
        private readonly IEmailConfirmedDal _emailConfirmedDal;



        private readonly IMapper _mapper;

        public IndividualManager(IUserRoleDal userRoleDal, IMapper mapper, IIndividualDal individualDal,
            IImageDal ımageDal, IUserService userService, IEmailConfirmedDal emailConfirmedDal)
        {
            _userRoleDal = userRoleDal;
            _mapper = mapper;
            _individualDal = individualDal;
            _ımageDal = ımageDal;
            _userService = userService;
            _emailConfirmedDal = emailConfirmedDal;
        }

        public ResultDTO<RegisterDTO> SignUp(RegisterDTO userRegister)
        {
            var userToCheck = _userService.GetByMail(userRegister.Email);
            if (userToCheck.Data != null)
            {
                return new ResultDTO<RegisterDTO> { Message = Messages.UserAlreadyExist, Success = false };
            }

            string encodePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(userRegister.Password));
            Individual individual = new Individual
            {
                Email = userRegister.Email,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                Password = encodePassword,
                CreateDate = DateTime.Now,
                IsActive = true,
            };
            _individualDal.Add(individual);

            Image ımage = new Image {
                UserId = individual.Id,
                ImagePath = "/images/userPath/anonim.jpg",
                ImageTypeId = 1,
                CreateDate = DateTime.Now,
                IsActive = true,
             };

            _ımageDal.Add(ımage);

            UserRole userRole = new UserRole
            {
                RoleId = userRegister.RoleId,
                UserId = individual.Id
            };
            _userRoleDal.Add(userRole);

            return new ResultDTO<RegisterDTO> { Data = userRegister, Success = true };
        }

        public ResultDTO<UpdateUserDTO> Update(UpdateUserDTO updateUser)
        {
            var user = GetById(updateUser.Id);
            if (user != null)
            {
                updateUser.Id = user.Data.Id;
                updateUser.UpdateDate = DateTime.Now;
                updateUser.IsActive = true;

                var mapper = _mapper.Map<Individual>(updateUser);
                _individualDal.Update(mapper);
     
                return new ResultDTO<UpdateUserDTO> { Data = updateUser, Success = true,Message = Messages.UserUpdated};
            }

            return new ResultDTO<UpdateUserDTO> { Success = false };
        }

        public ResultDTO<UpdateUserDTO> GetById(int id)
        {
            var result = _individualDal.Get(i => i.Id == id);
            var mapper = _mapper.Map<UpdateUserDTO>(result);
            return new ResultDTO<UpdateUserDTO> { Data = mapper, Success = true };
        }
        public ResultDTO<EmailConfirmedDTO> EmailCodeSaved(EmailConfirmedDTO emailConfirmedDTO)
        {
            emailConfirmedDTO.CreateDate = DateTime.Now;
            emailConfirmedDTO.FinishDate = DateTime.Now.AddHours(3);
            emailConfirmedDTO.IsActive = true;
            var mapper = _mapper.Map<EmailConfirmed>(emailConfirmedDTO);
            var control = _emailConfirmedDal.Get(i => i.UserId == mapper.UserId);
            if (control != null  )
            {
                if (control.IsActive == false)
                {
                    emailConfirmedDTO.IsActive = false;
                    return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailConfirmedAlreadyIsTrue, Success = true };
                }
                else if (control.FinishDate.CompareTo(DateTime.Now) == 1)
                {
                    emailConfirmedDTO.IsActive = false;
                    return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailConfirmedCodeAlreadyHave, Success = true };

                }
                else
                {
                    mapper.Id = control.Id;
                    _emailConfirmedDal.Update(mapper);
                    emailConfirmedDTO.Id = mapper.Id;
                    return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message= Messages.EmailConfirmedCodeCreateTrue , Success = true };
                }
            }
            _emailConfirmedDal.Add(mapper);
            emailConfirmedDTO.Id = mapper.Id;
            return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailConfirmedCodeCreateTrue, Success = true };
        }

        public ResultDTO<EmailConfirmedDTO> EmailCodeControl(EmailConfirmedDTO emailConfirmedDTO)
        {
            var model = _emailConfirmedDal.Get(i => i.UserId == emailConfirmedDTO.UserId);
            if (model.IsActive==false)
            {
                return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailConfirmedAlreadyIsTrue, Success = true };

            }
            else if (model.IsActive == true && model.EmailConfirmedCode == emailConfirmedDTO.EmailConfirmedCode)
            {
                model.IsActive = false;
                _emailConfirmedDal.Update(model);
                var user = _individualDal.Get(i => i.Id == model.UserId);
                user.EmailConfirmed = true;
                _individualDal.Update(user);
                return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailConfirmedIsTrue, Success = true };

            }
            return new ResultDTO<EmailConfirmedDTO> { Data = emailConfirmedDTO, Message = Messages.EmailCodeEnteredIncorrectly, Success = true };

        }
    }
}
