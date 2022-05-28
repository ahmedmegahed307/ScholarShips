using System.Collections.Generic;
using Business.Abstract;
using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{

    public class IndividualsController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;

        public IndividualsController(IWebHostEnvironment hostingEnvironment, IApiHelper api)
        {
            _hostingEnvironment = hostingEnvironment;
            _api = api;
        }


        [HttpGet]
        public IActionResult SignUpWeb()
        {
            RegisterDTO registerDto = new();

            var resultDtos = _api.GetObjectResponseFromApi<List<RoleDTO>>(RestSharp.Method.GET, "/Definition/getallrole/1", null, GetToken()).Data;
            ViewData["RoleDTO"] = new SelectList(resultDtos, "Id", "RoleName");
            return View(registerDto);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;
            UpdateUserDTO updateUser = _api.GetObjectResponseFromApi<UpdateUserDTO>(RestSharp.Method.GET, "/Individuals/getbyid/" + id, null, GetToken()).Data;
            updateUser.Id = id;
            SetProperties();

            return View(updateUser);
        }


        [HttpPost]
        public IActionResult UpdatePost(UpdateUserDTO updateUser)
        {
            //if (!ModelState.IsValid)
            //{
            //    var messages = ModelState.ToList();
            //    return BadRequest(messages);
            //}
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            updateUser.Id = userDTO.Id;
            var result = _api.GetObjectResponseFromApi<UpdateUserDTO>(RestSharp.Method.POST, "/Individuals/Update" , updateUser, GetToken());

      
            return Json(result);
        }
        [HttpPost]
        public IActionResult SignUpWeb(RegisterDTO registerDto)
        {
            var resultDTO = _api.GetObjectResponseFromApi<RegisterDTO>(RestSharp.Method.POST, "Individuals/SignUp", registerDto, GetToken());


            if (resultDTO.Success)
            {
                return Json(new { Success = true });
            }
            else if (resultDTO.Success == false)
            {
                return Json(new { Success = false });

            }
            return BadRequest();

        }

        private void SetProperties()
        {
            List<DisciplineDTO> disciplineDTOs = _api.GetObjectResponseFromApi<List<DisciplineDTO>>(RestSharp.Method.GET, "/Definition/GetListDisciplineDTO/", null, GetToken()).Data;
            ViewData["DisciplineDTO"] = new SelectList(disciplineDTOs, "Id", "DisciplineType");

            List<TitleDTO> titleDTOs = _api.GetObjectResponseFromApi<List<TitleDTO>>(RestSharp.Method.GET, "/Definition/GetListTitleDTO/", null, GetToken()).Data;
            ViewData["TitleDTO"] = new SelectList(titleDTOs, "Id", "TitleType");

            List<CountryDTO> countryDTOs = _api.GetObjectResponseFromApi<List<CountryDTO>>(RestSharp.Method.GET, "/Definition/GetListCountryDTO/", null, GetToken()).Data;
            ViewData["CountryDTO"] = new SelectList(countryDTOs, "Id", "Countries");

        }


        public IActionResult GetCity(int id)
        {
            var resultDtos = _api.GetObjectResponseFromApi<List<CityDTO>>(RestSharp.Method.GET, "/Definition/getallbycountry/" + id, null, GetToken()).Data;
            ViewData["CityDTO"] = resultDtos;
            return Json(resultDtos);
        }

        public ActionResult GetUniversityWeb(int id)
        {
            var resultDtos = _api.GetObjectResponseFromApi<List<UniversityDTO>>(RestSharp.Method.GET, "/Definition/GetUniversity/" + id, null, GetToken()).Data;
            ViewData["UniversityDTO"] = resultDtos;
            return Json(resultDtos);
        }
    }
}
