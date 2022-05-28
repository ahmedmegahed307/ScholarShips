using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace Web.InfraStructure
{
    public class UserManager
    {
        readonly IApiHelper api;
        public static string userToken;
        private readonly IHttpContextAccessor accessor;
        public UserManager(IApiHelper api, IHttpContextAccessor accessor)
        {
            this.api = api;
            this.accessor = accessor;
        }
        public ResultDTO<ApiTokenResponseDTO> SignIn(HttpContext httpContext, UserDTO login, bool isPersistent = false)
        {
            try
            {
                string Password = string.Empty;
                string EmailAdress = string.Empty;
                if (login==null)
                { 
                    Password = "Ds2022.753";
                    EmailAdress = "visitor";
                }
                else
                {
                   Password = login.Password;
                   EmailAdress = login.Email;
                }
                ApiTokenRequestDTO query = new ApiTokenRequestDTO
                {
                    GrantType = "password",
                    Password = Password,
                    EmailAdress = EmailAdress,
                    ExternalIP = accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    ClientIP = accessor.HttpContext.Connection.LocalIpAddress.ToString()

                };

                var token = api.GetObjectResponseFromApi<ApiTokenResponseDTO>(RestSharp.Method.POST,
                    "Token/GetToken", query);
                userToken = token.Data.Token;
                if (token == null || string.IsNullOrEmpty(token.Data.Token))
                {
                    return new ResultDTO<ApiTokenResponseDTO> { Message = "Login is failed!", Success = false };
                }
                if (token.Success == false)
                {
                    return new ResultDTO<ApiTokenResponseDTO> { Message = token.Message, Success = false };
                }
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(token.Data),
                CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var SigninTask = httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                    // IssuedUtc=DateTime.UtcNow
                });
                while (!SigninTask.IsCompleted)
                {
                    Thread.Sleep(100);
                }

                return token;
            }
            catch
            {
                return new ResultDTO<ApiTokenResponseDTO> { Message = "Login is failed!", Success = false };
            }
        }
        public async void SignOut(HttpContext httpContext)
        {

            await httpContext.SignOutAsync();
        }
        private IEnumerable<Claim> GetUserClaims(ApiTokenResponseDTO response)
        {
            string guid = Guid.NewGuid().ToString();

            var userInfo = response.UsersDTO;

            List<Claim> claim = new List<Claim>
            {
                new Claim("Secret", response.Token),
                new Claim("EmailAdress", response.UsersDTO.Email),
                new Claim("UserInfo", JsonConvert.SerializeObject(userInfo)),
            };
            return claim;
        }
        //google login
        public ResultDTO<ApiTokenResponseDTO> SignInWithGoogle(HttpContext httpContext, UserDTO login, bool isPersistent = false)
        {

            

            try
            {

                string Password = login.Password;
                
               
                string EmailAdress = login.Email;


                
                ApiTokenRequestDTO query = new ApiTokenRequestDTO
                {
                    GrantType = "password",
                    Password = Password,
                    EmailAdress = EmailAdress,
                    ExternalIP = accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    ClientIP = accessor.HttpContext.Connection.LocalIpAddress.ToString()

                };

                var token = api.GetObjectResponseFromApi<ApiTokenResponseDTO>(RestSharp.Method.POST,
                    "Token/GetTokenForGoogle", query);
                userToken = token.Data.Token;
                if (token == null || string.IsNullOrEmpty(token.Data.Token))
                {
                    return new ResultDTO<ApiTokenResponseDTO> { Message = "Login is failed!", Success = false };
                }
                if (token.Success == false)
                {
                    return new ResultDTO<ApiTokenResponseDTO> { Message = token.Message, Success = false };
                }
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(token.Data),
                CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                var SigninTask = httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                    // IssuedUtc=DateTime.UtcNow
                });
                while (!SigninTask.IsCompleted)
                {
                    Thread.Sleep(100);
                }

                return token;
            }
            catch
            {
                return new ResultDTO<ApiTokenResponseDTO> { Message = "Login is failed!", Success = false };
            }
        }
    }
}
