using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class GoogleLoginController : Controller
    {
        private readonly IUserService _userService;

        public GoogleLoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpGet("GetByMail/{mail=}")]
        public IActionResult GetByMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        */
        //Sadece o maile sahip kullanıcıları getir
        [HttpGet("GetUsersByMail/{mail=}")]
        public ActionResult GetUsersByMail(string mail)
        {
            string Mail = mail;
            //mail = "iremsamur129@gmail.com";
            var result = _userService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
