using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using Web.InfraStructure;
using System.Linq;
using System.Threading.Tasks;
using Web.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Business.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;

namespace Web.Controllers
{
    [Authorize]
    public class LoginController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;
        
        
        
        private readonly UserManager _userManager;
       

        public LoginController(IApiHelper api, UserManager userManager, IWebHostEnvironment hostingEnv)
        {
            _api = api;
            _userManager = userManager;
            _hostingEnvironment = hostingEnv;
           
           
        }
        [HttpGet]
        public ActionResult Index()         //login indexi
        {

            UserDTO userDTO = new();
            return View(userDTO);
        }
        //google login
        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public string passwordGenerate()
        {
            Random rastgele = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ascii = rastgele.Next(32, 127);
                char karakter = Convert.ToChar(ascii);
                sb.Append(karakter);

            }
            return sb.ToString();
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
                

            });
            //var mail = result.Principal.FindFirst(ClaimTypes.Email);
            
            //giriş yapanın bilgileri geliyor.
            var Email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var givenName = result.Principal.FindFirstValue(ClaimTypes.GivenName);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);
            var surname = result.Principal.FindFirstValue(ClaimTypes.Surname);
            //UserDTO applicationUsersDTO = new();
            //applicationUsersDTO = GetCurrentUser();
            //var model = applicationUsersDTO.Id;
            UserDTO loginDTO = new();
            loginDTO = _api.GetObjectResponseFromApi<UserDTO>(RestSharp.Method.GET, "/GoogleLogin/GetUsersByMail/" + Email ).Data;
            //var deneme = loginDTO.Email;
            if (loginDTO != null)
            {

                string error = "";

                try
                {
                    ResultDTO<ApiTokenResponseDTO> resultToken = _userManager.SignInWithGoogle(this.HttpContext, loginDTO, true);
                    if (result != null)
                    {

                        //return Json(new { success = true, user = result.Data.UsersDTO });
                        return Json(claims);

                    }

                    else
                    {
                        error = "Login is failed!";
                    }
                }
                catch
                {
                    error = "Login is failed!";
                }
                

            }
            else
            {
                RegisterDTO register = new RegisterDTO();

                register.Email = Email;
                register.Password = passwordGenerate();
                register.FirstName = name;
                register.LastName = surname;
                register.RoleId = 1;
                var resultDTO = _api.GetObjectResponseFromApi<RegisterDTO>(RestSharp.Method.POST, "Individuals/SignUp", register);
                if (resultDTO.Success)
                {
                    return Json(new { Success = true });
                }
                else if (resultDTO.Success == false)
                {
                    return Json(new { Success = false });

                }
            }
            return View("Index");
            /*
            var gender = result.Principal.FindFirstValue(ClaimTypes.Gender);
            var phone = result.Principal.FindFirstValue(ClaimTypes.MobilePhone);
            var dateOfBirth = result.Principal.FindFirstValue(ClaimTypes.DateOfBirth);
            var country = result.Principal.FindFirstValue(ClaimTypes.Country);
            var password = result.Principal.FindFirstValue(ClaimTypes.Hash);
            */






                /*
            var userDTOs = _api.GetObjectResponseFromApi<UserDTO>(RestSharp.Method.GET, "/GoogleLogin/GetByMail/" + Email);
            //UserDTO user = _api.GetObjectResponseFromApi<UserDTO>(RestSharp.Method.GET, "/GoogleLogin/getbymail/" + Email, null).Data;
            //var value = userDTOs.Email;
            if (userDTOs!=null)
            {
                return Json(claims);
            }
            return View("Index");
                */
            
            





        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");



        }
        

[HttpPost]
[AllowAnonymous]
public IActionResult Login(UserDTO model)
{
    string error = "";

    try
    {
        ResultDTO<ApiTokenResponseDTO> result = _userManager.SignIn(this.HttpContext, model, true);
        if (result != null)
        {

            return Json(new { success = true, user = result.Data.UsersDTO });

        }

        else
        {
            error = "Login is failed!";
        }
    }
    catch
    {
        error = "Login is failed!";
    }
    return Json(new { success = false, errorMessage = error });
}
[HttpGet]
public ActionResult LogOff()
{
    _userManager.SignOut(this.HttpContext);
    return RedirectToAction("Index", "HomePage" , false);
}





}
}
