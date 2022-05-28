using Entities.InterjectionDTO;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public Claim GetClaim(string claimtype)
        {
            return HttpContext.User.Claims.Where(s => s.Type == claimtype).FirstOrDefault();
        }
        public UserDTO GetCurrentUser()
        {
            string userJson = HttpContext.User.Claims.Where(s => s.Type == "UserInfo").FirstOrDefault().Value;
            UserDTO dto = JsonConvert.DeserializeObject<UserDTO>(userJson);
            return dto;
        }
        public List<UserDTO> GetUserTools()
        {
            if (HttpContext.User.Claims.Where(s => s.Type == "AuthorityTools").FirstOrDefault() != null)
            {
                string guid = HttpContext.User.Claims.Where(s => s.Type == "AuthorityTools").FirstOrDefault().Value;

            }
            return null;
        }
        public string GetToken()
        {
            string token = HttpContext.User.Claims.Where(s => s.Type == "Secret").FirstOrDefault().Value;
            return token;
        }
    }
}
