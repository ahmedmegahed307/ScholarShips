using Business.Abstract;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostingController : ControllerBase
    {
        private readonly IPostingService _postingService;
        private readonly IImageService _ımageService;
        private readonly ISavedPostingService _savedPostingService;
        private readonly IApplyService _applyService;
        private readonly IUniversityService _universityService;



        public PostingController(IPostingService postingService,   IImageService ımageService, IApplyService applyService,
              ISavedPostingService savedPostingService,
            IUniversityService universityService)

        {
            _ımageService = ımageService;
            _postingService = postingService;
            _savedPostingService = savedPostingService;
            _applyService = applyService;
            _universityService = universityService;
        }

        [HttpPost("CreatePosting")]
        public ActionResult CreatePosting(PostingDTO model)
        {
            var result = _postingService.CreatePosting(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("GetUserPostingAll/{id=}/{skip=}")]
        public ActionResult GetUserPostingAll(int Id , int skip)
        {
            var result = _postingService.GetUserPostingAll(Id, skip);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("GetPosting/{id=}")]
        public ActionResult GetPosting(int Id)
        {
            var result = _postingService.GetPosting(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetPostingAll/{id=}")]
        public ActionResult GetPostingAll(int Id)
        {
            var result = _postingService.GetPostingAll(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        //TODO:{id=} ? bunlar neden var?
        [HttpPost("GetListPostingDTO")]
        public ActionResult GetListPostingDTO(CustomPostingDTO p)
        {
            var result = _postingService.GetList(p);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }
        
        [HttpPost("GetFilteredListPostingDTO")]
        public ActionResult GetFilteredListPostingDTO(CustomPostingDTO p)
        {
          

            var result = _postingService.GetFilteredList(p);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }










        [HttpGet("DeletePosting/{id=}")]
        public ActionResult DeletePosting(int Id)
        {
            _postingService.DeletePosting(Id);
            //var result = _postingService.DeletePosting(Id);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            return Ok();
            //return BadRequest(result);

        }

        [HttpPost("UpdatePosting")]
        public ActionResult UpdatePosting(PostingDTO model)
        {
            var result = _postingService.UpdatePosting(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }




        #region ilan kaydetme (begenme)
        [HttpPost("SavedPostingDTO")]
        public ActionResult UpdateCv(SavedPostingDTO model)
        {
            var result = _savedPostingService.SavedPostingDTO(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region İlan Başvurma 
        [HttpPost("ApplyPosting")]                        
        public ActionResult ApplyPosting(CustomPostingDTO model)
        {
            var result = _applyService.ApplyPosting(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetApplicantsPosting/{id=}/{skip=}")]
        public ActionResult GetApplicantsPosting(int Id, int skip)
        {
            var result = _postingService.GetApplicantsPosting(Id, skip);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Cv İşlemleri

        [HttpPost("UpdateCv")]
        public ActionResult UpdateCv(CVDTO model)
        {
            var result = _postingService.UpdateCv(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion






    }


}
