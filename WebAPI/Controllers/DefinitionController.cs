using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly ITitleService _titleService;
        private readonly IDisciplineService _disciplineService;
        private readonly IPostingTypeService _postingTypeService;
        private readonly IUniversityService _universityService;



        public DefinitionController(IRoleService roleService, ICountryService countryService, ICityService cityService, IUniversityService universityService ,
            ITitleService titleService,     IDisciplineService disciplineService,    IPostingTypeService postingTypeService )
        {
            _roleService = roleService;
            _countryService = countryService;
            _cityService = cityService;
            _universityService = universityService;

            _titleService = titleService;
            _disciplineService = disciplineService;
            _postingTypeService = postingTypeService;
        }




        [HttpGet("getallrole/{id=}")]
        public ActionResult GetAllRole()
        {
            var result = _roleService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetListCountryDTO/{id=}")]
        public ActionResult GetListCountryDTO()
        {
            var result = _countryService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

        [HttpGet("GetUniversity/{id=}")]
        public ActionResult GetUniversity(int id)
        {

            var result = _universityService.GetUniversity(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getallbycountry/{id=}")]                      // Country İd ye göre city datasını çekiyorum
        public ActionResult GetAllByCountryId(int id)
        {

            var result = _cityService.GetAllByCountryId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }
        [HttpGet("GetListPostingTypeDTO/{id=}")]
        public ActionResult GetListPostingTypeDTO()
        {
            var result = _postingTypeService.GetListPostingTypeDTO();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetListTitleDTO/{id=}")]
        public ActionResult GetListTitleDTO()
        {
            var result = _titleService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetListDisciplineDTO/{id=}")]
        public ActionResult GetListDisciplineDTO()
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
