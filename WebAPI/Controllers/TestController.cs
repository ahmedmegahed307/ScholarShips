using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        IDisciplineService _disciplineService;


        public TestController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

     

        [HttpGet("getlist/{id=}")]
        public ActionResult GetList()
        {
            var result = _disciplineService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }
    }
}
