using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Web.InfraStructure;
using X.PagedList;

namespace Web.Controllers
{
    public class HomePageController : Controller
    {
        //public IWebHostEnvironment _hostingEnvhostingEnvironment;
        IApiHelper _api;
        UserManager _userManager;

        public HomePageController(IApiHelper api, UserManager userManager)
        {
            _api = api;
           // _hostingEnvhostingEnvironment = hostingEnv;
            _userManager = userManager;
        }
        public ActionResult Index(int page = 1)
        {
            CustomPostingDTO p = new();
            
            if (HttpContext.User.Claims.Where(s => s.Type == "Secret").FirstOrDefault() == null)
            {
                p.UserDTOItems = _userManager.SignIn(this.HttpContext, p.UserDTOItems, true).Data.UsersDTO;
                return RedirectToAction("Index", "HomePage");
            }
            else
            {                
                p.UserDTOItems = JsonConvert.DeserializeObject<UserDTO>(HttpContext.User.Claims.Where(s => s.Type == "UserInfo").FirstOrDefault().Value);
            }
            SetProperties();


            p = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.POST, "/Posting/GetListPostingDTO/", p, GetToken()).Data;

            ViewData["PostingDTO"] = p.PostingDTOItems.ToPagedList(page, 2);

            return View(p);
        }

        [HttpPost]
        public ActionResult Index(CustomPostingDTO p)
        {
            return RedirectToAction("FilteredPosts", p);
        }

        public string GetToken()
        {
            string token = HttpContext.User.Claims.Where(s => s.Type == "Secret").FirstOrDefault().Value;
            return token;
        }
    
        public ActionResult FilteredPosts(CustomPostingDTO p,int page=1)
        {
            p.UserDTOItems = JsonConvert.DeserializeObject<UserDTO>(HttpContext.User.Claims.Where(s => s.Type == "UserInfo").FirstOrDefault().Value);
            p = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.POST, "/Posting/GetFilteredListPostingDTO/", p, GetToken()).Data;
            ViewData["PostingDTOs"] = p.PostingDTOItems.ToPagedList(page, 2);

            SetProperties();
            //FilteredPostsList(p,page);

            ViewBag.PostingTypeId = p.PostingTypeId;
            ViewBag.TitleId = p.TitleId;
            ViewBag.DisciplineId = p.DisciplineId;
            ViewBag.CountryId = p.CountryId;

            return View(p);
        }
    

        public PartialViewResult SideBar()
        {
            SetProperties();
            return PartialView();
        }
        public PartialViewResult CategoryButtons()
        {
            return PartialView();
        }


        private void SetProperties()
        {
            List<DisciplineDTO> disciplineDTOs = _api.GetObjectResponseFromApi<List<DisciplineDTO>>(RestSharp.Method.GET, "/Definition/GetListDisciplineDTO/", null, GetToken()).Data;
            ViewBag.DisciplineDTO = new SelectList(disciplineDTOs, "Id", "DisciplineType");

            List<TitleDTO> titleDTOs = _api.GetObjectResponseFromApi<List<TitleDTO>>(RestSharp.Method.GET, "/Definition/GetListTitleDTO/", null, GetToken()).Data;
            ViewBag.TitleDTO = new SelectList(titleDTOs, "Id", "TitleType");

            List<PostingTypeDTO> postingTypeDTOs = _api.GetObjectResponseFromApi<List<PostingTypeDTO>>(RestSharp.Method.GET, "/Definition/GetListPostingTypeDTO/", null, GetToken()).Data;
            ViewBag.PostingTypeDTO = new SelectList(postingTypeDTOs, "Id", "PostingType");

            List<CountryDTO> countryDTOs = _api.GetObjectResponseFromApi<List<CountryDTO>>(RestSharp.Method.GET, "/Definition/GetListCountryDTO/", null, GetToken()).Data;
            ViewBag.CountryDTO = new SelectList(countryDTOs, "Id", "Countries");
        }
      
        private void UnFilteredPostsList(CustomPostingDTO p,int page)
        {
            p = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.POST, "/Posting/GetListPostingDTO/", p, GetToken()).Data;
            ViewData["PostingDTO"] = p.PostingDTOItems.ToPagedList(page,2);
            
          
        }
        private void FilteredPostsList(CustomPostingDTO p,int page)
        {
            p = _api.GetObjectResponseFromApi<CustomPostingDTO>(RestSharp.Method.POST, "/Posting/GetFilteredListPostingDTO/", p, GetToken()).Data;
            ViewData["PostingDTOs"] = p.PostingDTOItems.ToPagedList(page, 2);
        }
    }
}
