using Business.Abstract;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;

        public EventController(IEventService eventService,IImageService imageService)
        {
            _eventService = eventService;
            _imageService = imageService;
        }
        /*
        [HttpGet("GetEvent/{id=}")]
        public ActionResult GetEvent(int Id)
        {
            var result = _eventService.GetEvent(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("GetEvent/{id=}")]
        public ActionResult GetAllEvent()
        {
            var result = _eventService.GetAllEvent();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        */
        //Kullanıcının açtığı event'ları listele
        [HttpGet("GetUserEvent/{id=}")]
        public ActionResult GetUserEvent(int Id)
        {
            var result = _eventService.GetUserEvent(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        //Tüm event'lar
        [HttpGet("GetAllEvent/{id=}")]
        public ActionResult GetAllEvent()
        {
            var result = _eventService.GetAllEvents();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        //seçili event'ı sil

        [HttpGet("DeleteSelectedEvent/{id=}")]
        public ActionResult DeletePosting(int Id)
        {
            var result = _eventService.DeleteSelectedEvent(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        //yeni event ekle
        [HttpPost("CreateEvent/{id=}")]
        public ActionResult CreateEvent(EventDTO model)
        {
            var result = _eventService.CreateEvent(model);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }
        //İlan resimleri için ekleme
        [HttpPost("CreateEventImage")]
        public ActionResult CreateEventImage(EventDTO model)
        {
            var result = _imageService.CreateNewEventImage(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        //update event 
        [HttpPost("UpdateSelectedEvent")]
        public ActionResult UpdateSelectedEvent(EventDTO model)
        {
            var result = _eventService.UpdateEvent(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("UpdateEventImage")]
        public ActionResult UpdateEventImage(EventDTO model)
        {
            var result = _imageService.UpdateEventImage(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        //seçili event'ları getir
        [HttpGet("GetEvent/{id=}")]
        public ActionResult GetEvent(int Id)
        {
            var result = _eventService.GetSelectedEvent(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        /*
        [HttpPost("CreateNewEvent/{id=}")]
        public ActionResult CreateNewEvent(EventDTO model)
        {
            var result = _eventService.CreateEvent(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        */
        /*
        [HttpPost("CreateEventImage/{id=}")]
        public ActionResult CreatePostingImage(PostingDTO model)
        {
            var result = _ımageService.CreatePostingImage(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        */


    }
}
