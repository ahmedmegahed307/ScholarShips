using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.InterjectionDTO;
using System.Collections.Generic;
using Business.Constants;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        readonly IMapper _mapper;
        public RoleManager(IRoleDal roleDal, IMapper mapper)
        {
            _roleDal = roleDal;
            _mapper = mapper;

        }

        public ResultDTO<List<RoleDTO>> GetList()
        {
            var roles = _roleDal.GetAll();
            var mapper= _mapper.Map<List<RoleDTO>>(roles);
            return new ResultDTO<List<RoleDTO>>{Data = mapper,Message = Messages.RoleListed,Success = true};

        }



    }
}
