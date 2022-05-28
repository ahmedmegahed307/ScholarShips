using Business.Abstract;
using DataAccess.Migrations;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class IndividualsController : ControllerBase
    {
        private readonly IIndividualService _individualService;

        public IndividualsController(IIndividualService individualService)
        {
            _individualService = individualService;
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] UpdateUserDTO updateUser)
        {
            var result = _individualService.Update(updateUser);
            return result.Success ? Ok(result) : BadRequest(result);


        }
        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] RegisterDTO userRegisterDto)
        {
            var result = _individualService.SignUp(userRegisterDto);
            return result.Success ? Ok(result) : BadRequest(result);


        }

        [HttpGet("getbyid/{id=}")]
        public IActionResult GetById(int id)
        {
            var result = _individualService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("EmailCodeSaved")]
        public IActionResult EmailCodeSaved([FromBody] EmailConfirmedDTO emailConfirmedDTO)
        {
            var result = _individualService.EmailCodeSaved(emailConfirmedDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("EmailCodeControl")]
        public IActionResult EmailCodeControl([FromBody] EmailConfirmedDTO model)
        {
            var result = _individualService.EmailCodeControl(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
