using Business.Helper.ApiHelper;
using Entities.Concrete;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class EventController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;//sunucu ortamı ile ilgili işlevlerimizi yürütebilmemizi sağlıyor.
        readonly IApiHelper _api;
        Random rnd = new Random();//resme rastgele isim vermemizi sağlar.
        

       


        public EventController(IApiHelper api, IWebHostEnvironment hostingEnv)
        {
            _hostingEnvironment = hostingEnv;
            _api = api;

        }
        //ilan ekleme sayfasına gider.
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListEvents(int Id)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;
            EventDTO eventDTO = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.GET, "/Event/GetEvent/" + Id, null, GetToken()).Data;
            eventDTO.Id = Id;

            

            return View(eventDTO);
        }
        public IActionResult ListAllEvents(int Id)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;
            EventDTO eventDTO = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.GET, "/Event/GetAllEvent/" + Id, null, GetToken()).Data;
            eventDTO.Id = Id;



            return View(eventDTO);
        }
        //tüm event'ları getir.
        public IActionResult GetAllEvents()
        {
            EventDTO eventDTO = new();
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;


            //List<EventDTO> eventDTOs = _api.GetObjectResponseFromApi<List<EventDTO>>(RestSharp.Method.GET, "/Event/GetUserEvent/" + model, null, GetToken()).Data;
            var eventDTOs = _api.GetObjectResponseFromApi<List<EventDTO>>(RestSharp.Method.GET, "/Event/GetAllEvent/" + model, null, GetToken()).Data;
            return View(eventDTOs);

        }

        //Kullanıcının açtığı ilanları listeliyor.
        public IActionResult GetUserEvent()
        {
            EventDTO eventDTO = new();
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;
           

            //List<EventDTO> eventDTOs = _api.GetObjectResponseFromApi<List<EventDTO>>(RestSharp.Method.GET, "/Event/GetUserEvent/" + model, null, GetToken()).Data;
            var eventDTOs = _api.GetObjectResponseFromApi<List<EventDTO>>(RestSharp.Method.GET, "/Event/GetUserEvent/" + model, null, GetToken()).Data;
            return View(eventDTOs);

        }
        //kullanıcının seçtiği event'ı sil
        [HttpGet]
        public ActionResult DeleteEvent(int Id)
        {
            UserDTO applicationUsersDTO = new();
            applicationUsersDTO = GetCurrentUser();
            var model = applicationUsersDTO.Id;
           EventDTO eventDTO = new();
            eventDTO = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.GET, "/Event/DeleteSelectedEvent/" + Id, null , GetToken()).Data;


            var eventDTOs = _api.GetObjectResponseFromApi<List<EventDTO>>(RestSharp.Method.GET, "/Event/GetAllEvent/" + model, null, GetToken()).Data;//verileri güncel halini alsın


            return View("GetUserEvent", eventDTOs);//güncel halini listelesin


        }
        //Yeni event oluşturma
        [HttpPost]
        public ActionResult CreateNewEvent(EventDTO eventDTO)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;

            long uploaded_files_size = 0;
            eventDTO.UserId = userDTO.Id;
            var response = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/CreateEvent" , eventDTO, GetToken());//event ekliyor. Event tablosuna
            eventDTO.Id = response.Data.Id;
            string path_for_Uploaded_Images = _hostingEnvironment.WebRootPath + "/images/eventPath/";   // buraya event resmi kaydedilir.
            var files = Request.Form.Files;
            var newFileName = ""; //resime random isim verir.
            if(files!=null && files.Count > 0)
            {
                foreach(var picture in files)
                {
                    FileInfo fi = new FileInfo(picture.FileName);

                   uploaded_files_size += picture.Length;   //resmin boyutu
                    newFileName="Image_"+ DateTime.Now.TimeOfDay.Milliseconds+ rnd.Next(0, 99999).ToString() + ".png";
                    string path = path_for_Uploaded_Images + newFileName;   // resmi sunucuya kaydederken kullandığım url

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        picture.CopyTo(stream);

                    }
                    var pathson = "/images/eventPath/" + newFileName;
                    eventDTO.EventImagePath = pathson;//resmin yolunu veritabanına atar.
                    var response2 = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/CreateEventImage" , eventDTO, GetToken());
                    




                }
                return Json(response);
            }
            return Json(response);
            /*
            if (files != null)
            {
                //var files = Request.Form.Files;
                var newFileName = rnd.Next(0, 99999).ToString() + ".png";//isme random isim verir.
                using (var fileStream = new FileStream(Path.Combine(path_for_Uploaded_Images, newFileName), FileMode.Create, FileAccess.Write))
                {
                    formFile.CopyTo(fileStream);//resmi yüklüyor.

                }
                var pathson = "/images/eventPath/" + newFileName;
                eventDTO.EventImagePath = pathson;//resmin yolunu veritabanına atar.
                var response2 = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/CreateEventImage/" + model, eventDTO, GetToken());
                return Json(response);

            }
            return Json(response);
            */


           






        }
        //ilan güncelleme sayfasına gider
        [HttpGet]
        public IActionResult UpdatSelectedEventPage(int Id)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;

            //TempData.Add("Alert", "alert deneme");

            EventDTO eventDTO = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.GET, "/Event/GetEvent/" + Id, null, GetToken()).Data;
            eventDTO.Id = Id;



            return View(eventDTO);
        }
        //event güncelleme
        [HttpPost]
        public ActionResult UpdateEvent(EventDTO eventDTO)
        {
            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;

            long uploaded_files_size = 0;
            eventDTO.UserId = userDTO.Id;
            var response = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/UpdateSelectedEvent" , eventDTO, GetToken());//event ekliyor. Event tablosuna
            eventDTO.Id = response.Data.Id;
            string path_for_Uploaded_Images = _hostingEnvironment.WebRootPath + "/images/eventPath/";   // buraya event resmi kaydedilir.
            var files = Request.Form.Files;
            var newFileName = ""; //resime random isim verir.
            if (files != null && files.Count > 0)
            {
                foreach (var picture in files)
                {
                    FileInfo fi = new FileInfo(picture.FileName);

                    uploaded_files_size += picture.Length;   //resmin boyutu
                    newFileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + rnd.Next(0, 99999).ToString() + ".png";
                    string path = path_for_Uploaded_Images + newFileName;   // resmi sunucuya kaydederken kullandığım url

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        picture.CopyTo(stream);

                    }
                    var pathson = "/images/eventPath/" + newFileName;
                    eventDTO.EventImagePath = pathson;//resmin yolunu veritabanına atar.
                    var response2 = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/UpdateEventImage" , eventDTO, GetToken());





                }
                return Json(response);
            }
            return Json(response);






        }
        //ilan güncelleme sayfasına gider.
        public IActionResult UpdateEventPage()
        {
            return View();
        }

        /*
        [HttpPost]
        public IActionResult CreateEvent(EventDTO eventDTO)
        {

            UserDTO userDTO = new();
            userDTO = GetCurrentUser();
            var model = userDTO.Id;
            //long uploaded_size = 0;




            var response = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/CreateNewEvent/" + model, eventDTO, GetToken());
            eventDTO.Id = response.Data.Id;
            return Json(response);
            //Yazarın seçtiği dosyayı yüklemesi işlemi
            /*
            string path_for_Uploaded_Files = _hostingEnvironment.WebRootPath + "/images/eventPath/";   //resmin yolunu veriyoruz.

            var files = Request.Form.Files;
            if (files != null && files.Count > 0 && files.Count < 4)
            {

                foreach (var uploaded_file in files)
                {
                    FileInfo fi = new FileInfo(uploaded_file.FileName);

                    uploaded_size += uploaded_file.Length;   //resmin boyutu

                    var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + userDTO.Name + ".jpg";   // resmin adının düzenlendiği yer

                    string path = path_for_Uploaded_Files + newfilename;   // resmi sunucuya kaydederken kullandığım url

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        uploaded_file.CopyTo(stream);
                    }

                    var pathson = "/images/eventPath/" + newfilename;      // resmi dbye kaydederken kullandığım url

                    eventDTO.EventPhotoPath = pathson;

                    var response2 = _api.GetObjectResponseFromApi<EventDTO>(RestSharp.Method.POST, "/Event/CreatePostingImage/" + model, eventDTO, GetToken());

                }

                SetProperties(model);

                return Json(response);
        }
            */













    }
}
