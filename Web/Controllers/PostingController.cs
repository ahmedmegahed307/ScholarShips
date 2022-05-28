using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using X.PagedList;

namespace Web.Controllers
{
    [Authorize]
    public class PostingController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;
        readonly IApiHelper _api;
        public PostingController(IApiHelper api, IWebHostEnvironment hostingEnv)
        {
            _hostingEnvironment = hostingEnv;
            _api = api;

        }
        public IActionResult CreatePostingWeb()
        {
            var userDTO = GetCurrentUser();
            var model = userDTO.Id;


            SetProperties();

            return View();
        }
        public IActionResult MyPostingsWeb(int? page )
        {
            int pagenumber = (page ?? 1);
            var userDTO = GetCurrentUser();
            var model = userDTO.Id;

            var custompostingDTOs = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.GET, "/Posting/GetUserPostingAll/" + model+"/"+pagenumber, null, GetToken()).Data;

            return View(custompostingDTOs);

        }

        public IActionResult PostingModify(int Id)
        {
            var userDTO = GetCurrentUser();
            var model = userDTO.Id;


            PostingDTO postingDTO = _api.GetObjectResponseFromApi<PostingDTO>(RestSharp.Method.GET, "/Posting/GetPosting/" + Id, null, GetToken()).Data;
            postingDTO.Id = Id;

            SetProperties();

            return View(postingDTO);

        }
        public IActionResult ApplicantsPosting(int? page, int Id )
        {
            int pagenumber = (page ?? 1);
            var userDTO = GetCurrentUser();
            var model = userDTO.Id;

            var postingDTO = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.GET, "/Posting/GetApplicantsPosting/" + Id + "/" + pagenumber, null, GetToken()).Data;
            //postingDTO.Id = Id;
            SetProperties();

            return View(postingDTO);

        }

        private void SetProperties( )
        {
            ViewBag.Budget = new List<string>() { "500000", "10000000" };

            ViewBag.Quota = new List<string>() { "5", "10" };

            List<DisciplineDTO> disciplineDTOs = _api.GetObjectResponseFromApi<List<DisciplineDTO>>(RestSharp.Method.GET, "/Definition/GetListDisciplineDTO/", null, GetToken()).Data;
            ViewData["DisciplineDTO"] = new SelectList(disciplineDTOs, "Id", "DisciplineType");
            List<TitleDTO> titleDTOs = _api.GetObjectResponseFromApi<List<TitleDTO>>(RestSharp.Method.GET, "/Definition/GetListTitleDTO/", null, GetToken()).Data;
            ViewData["TitleDTO"] = new SelectList(titleDTOs, "Id", "TitleType");

            List<PostingTypeDTO> postingTypeDTOs = _api.GetObjectResponseFromApi<List<PostingTypeDTO>>(RestSharp.Method.GET, "/Definition/GetListPostingTypeDTO/", null, GetToken()).Data;
            ViewData["PostingTypeDTO"] = new SelectList(postingTypeDTOs, "Id", "PostingType");


        }


        [HttpPost]
        public IActionResult CreatePostingWeb(PostingDTO postingDTO)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return BadRequest(messages);
            }

            var userDTO = GetCurrentUser();


            postingDTO.UserId = userDTO.Id;

            var response = _api.GetObjectResponseFromApi<PostingDTO>(RestSharp.Method.POST, "/Posting/CreatePosting"  , postingDTO, GetToken());
            postingDTO.Id = response.Data.Id;


            return Json(response);

        }
        [HttpPost]
        public IActionResult UpdatePostingWeb(PostingDTO postingDTO)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return BadRequest(messages);
            }
            var applicationUsersDTO = GetCurrentUser();

            postingDTO.UserId = applicationUsersDTO.Id;

            var response = _api.GetObjectResponseFromApi<PostingDTO>(RestSharp.Method.POST, "/Posting/UpdatePosting" , postingDTO, GetToken());

            SetProperties();
            return Json(response);



        }
        [HttpGet]
        public ActionResult DeletePosting(int Id)
        {
            var applicationUsersDTO = GetCurrentUser();
            var model = applicationUsersDTO.Id;

            var postingDTO = _api.GetObjectResponseFromApi<PostingDTO>(RestSharp.Method.GET, "/Posting/DeletePosting/" +Id , null, GetToken());

            SetProperties();
            var custompostingDTOs = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.GET, "/Posting/GetUserPostingAll/" + model + "/" + 1, null, GetToken()).Data;


            return View("MyPostingsWeb", custompostingDTOs);


        }

        #region İlanı kaydetme ve başvurma işlemleri
        [HttpPost]
        public IActionResult SavedPosting(SavedPostingDTO model)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();

            model.UserId = userDTO.Id;
            var response = _api.GetObjectResponseFromApi<SavedPostingDTO>(RestSharp.Method.POST, "/Posting/SavedPostingDTO" , model, GetToken());

            return Json(response);


        }

        [HttpPost]
        public IActionResult ApplyPostingWeb(CustomPostingDTO model)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return BadRequest();
            }
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var userıd = userDTO.Id;
            model.UserId = userıd;
            var response = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.POST, "/Posting/ApplyPosting"  , model, GetToken());

            return Json(response);

        }
        #endregion


        [HttpGet]
        public ActionResult GetCountry()
        {

            var resultDtos = _api.GetObjectResponseFromApi<List<CountryDTO>>(RestSharp.Method.GET, "/Definition/GetListCountryDTO/" , null, GetToken()).Data;
            ViewData["CountryDTO"] = resultDtos;
            return Json(resultDtos);
        }
        [HttpGet]
        public ActionResult GetUniversityWeb(int id)
        {

            var resultDtos = _api.GetObjectResponseFromApi<List<UniversityDTO>>(RestSharp.Method.GET, "/Definition/GetUniversity/" + id, null, GetToken()).Data;

            ViewData["University"] = resultDtos;

            return Json(resultDtos);
        }

        #region cv ekelme işlemleri

        public IActionResult UploadCV()
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;

            CustomPostingDTO customPostingDTOs = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.GET, "/Posting/GetPostingAll/" + model, null, GetToken()).Data;

            return View(customPostingDTOs);
        }

        public IActionResult SingleFile(CVDTO model)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();

            var files = Request.Form.Files;

            var newfilename = "Cv_" + DateTime.Now.TimeOfDay.Milliseconds + ".pdf";
            string path_for_Uploaded_Files = _hostingEnvironment.WebRootPath + "/CvPath/";
            string path = path_for_Uploaded_Files + newfilename;


            using (var fileStream = new FileStream(Path.Combine(path), FileMode.Create, FileAccess.Write))
            {
                files[0].CopyTo(fileStream);
            }
            var pathson = "/CvPath/" + newfilename;

            model.CvPath = pathson;
            model.UserId = userDTO.Id;
            var cvupload = _api.GetObjectResponseFromApi<ApplyDTO>(RestSharp.Method.POST, "/Posting/UpdateCv", model, GetToken()).Data;

            return RedirectToAction("Index");
        }
        #endregion

    }
}
