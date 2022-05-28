using System.Collections.Generic;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{

    public partial class MyAccountController
    {

        [HttpGet]
        public ActionResult MyDetail()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetCountry()
        {

            var resultDtos = _api.GetObjectResponseFromApi<List<CountryDTO>>(RestSharp.Method.GET, "/Definition/GetListCountryDTO/", null).Data;
            return Json(resultDtos);
        }


        [HttpGet]
        public ActionResult GetCity(int id)
        {

            var resultDtos = _api.GetObjectResponseFromApi<List<CityDTO>>(RestSharp.Method.GET, "/Definition/getallbycountry/" + id, null).Data;

            ViewData["CityDTO"] = resultDtos;

            return Json(resultDtos);
        }

    }
}
