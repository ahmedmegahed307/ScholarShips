using Business.Abstract;
using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;

        public TestController(IWebHostEnvironment hostingEnvironment, IApiHelper api)
        {
            _hostingEnvironment = hostingEnvironment;
            _api = api;
        }

       

        [HttpGet]
        public ActionResult GetList()
        {
            var resultDtos = _api.GetObjectResponseFromApi<List<DisciplineDTO>>(RestSharp.Method.GET, "/Test/getlist/", null).Data;
            return Json(resultDtos);
        }


    }
}
