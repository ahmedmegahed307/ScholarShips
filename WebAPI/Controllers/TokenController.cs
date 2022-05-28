using Business.Abstract;
using Entities.InterjectionDTO;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public TokenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;

        }
        [AllowAnonymous]
        [HttpPost("GetTokenForGoogle")]
        public ResultDTO<ApiTokenResponseDTO> GetTokenForGoogle([FromBody] ApiTokenRequestDTO request)
        {
            /*
             * ResultDTO<ApiTokenResponseDTO> response = new ResultDTO<ApiTokenResponseDTO>();
             * var userInfo = _userService.SignInWithGoogle(request.EmailAdress);
             * if(userInfo==null){
             * response.Success = false;
                response.Message = "LoginError";
             * 
             * }
             * else{
             *  var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:SigningKey"));
                var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(new Claim[]{
            new Claim(ClaimTypes.Email,userInfo.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            
             * }
             */
            ResultDTO<ApiTokenResponseDTO> response = new ResultDTO<ApiTokenResponseDTO>();

            //var userInfo = _userService.SignIn(request.EmailAdress, request.Password);
            //Buraya mailine göre tüm bilgilerini getiren bir metod çağıralım
            //SignIn gibi
            var userInfo = _userService.SignInWithGoogle(request.EmailAdress);
            

            if (userInfo.Data!=null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:SigningKey"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, userInfo.Data.Id.ToString())
                    }),
                    Audience = _configuration.GetValue<string>("Token:Audience"),
                    Issuer = _configuration.GetValue<string>("Token:Issuer"),
                    Expires = DateTime.Now.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response = new ResultDTO<ApiTokenResponseDTO>
                {
                    Success = true,
                    Data = new ApiTokenResponseDTO
                    {
                        ValidTo = token.ValidTo,
                        ValidFrom = token.ValidFrom,
                        Token = tokenHandler.WriteToken(token),
                        UsersDTO = userInfo.Data,
                        
                    }
                };
            }
            else
            {
                response.Success = false;
                response.Message = "LoginError";
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public ResultDTO<ApiTokenResponseDTO> GetToken([FromBody] ApiTokenRequestDTO request)
        {
            ResultDTO<ApiTokenResponseDTO> response = new ResultDTO<ApiTokenResponseDTO>();

            var userInfo = _userService.SignIn(request.EmailAdress,request.Password);

            if (userInfo.Data != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:SigningKey"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Name,userInfo.Data.Id.ToString())
                            }),
                    Audience = _configuration.GetValue<string>("Token:Audience"),
                    Issuer = _configuration.GetValue<string>("Token:Issuer"),
                    Expires = DateTime.Now.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response = new ResultDTO<ApiTokenResponseDTO>
                {
                    Success = true,
                    Data = new ApiTokenResponseDTO
                    {
                        ValidTo = token.ValidTo,
                        ValidFrom = token.ValidFrom,
                        Token = tokenHandler.WriteToken(token),
                        UsersDTO = userInfo.Data,
                        IsVisitor= request.EmailAdress=="visitor"? true:false
                    }
                };
            }
            else
            {
                response.Success = false;
                response.Message = "LoginError";
            }
            return response;
        }
    }
}
