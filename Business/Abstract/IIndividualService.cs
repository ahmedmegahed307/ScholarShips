using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.InterjectionDTO;

namespace Business.Abstract
{
    public interface IIndividualService
    {
        ResultDTO<RegisterDTO> SignUp(RegisterDTO userRegister);
        ResultDTO<UpdateUserDTO> Update(UpdateUserDTO updateUser);

        ResultDTO<UpdateUserDTO> GetById(int id);
        ResultDTO<EmailConfirmedDTO> EmailCodeSaved(EmailConfirmedDTO emailConfirmedDTO);
        ResultDTO<EmailConfirmedDTO> EmailCodeControl(EmailConfirmedDTO emailConfirmedDTO);


    }
}
