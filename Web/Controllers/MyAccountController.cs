using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Business.Constants;
using Business.Helper.ApiHelper;
using Entities.InterjectionDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public partial class MyAccountController : BaseController
    {
        public IWebHostEnvironment _hostingEnvironment;
        private readonly IApiHelper _api;

        public MyAccountController(IWebHostEnvironment hostingEnvironment, IApiHelper api)
        {
            _hostingEnvironment = hostingEnvironment;
            _api = api;
        }
        public IActionResult EmailConformation()
        {

            EmailConfirmedDTO emailConfirmedDTO = new();



            return View();
        }
        public IActionResult EmailCode()
        {
            var UserDto = GetCurrentUser();
            Random rnd = new();

            string onaykodu;
            onaykodu = rnd.Next(1000) + rnd.Next(100)+ rnd.Next(10) + rnd.Next(1).ToString();
            EmailConfirmedDTO emailConfirmedDTO = new();
            emailConfirmedDTO.UserId = UserDto.Id;
            emailConfirmedDTO.EmailConfirmedCode = onaykodu;
            var response = _api.GetObjectResponseFromApi<EmailConfirmedDTO>(RestSharp.Method.POST, "/Individuals/EmailCodeSaved", emailConfirmedDTO, GetToken());
            if (response.Data.IsActive==true)
            {
                MailMessage message = new MailMessage("maili atacak hesap", "maili kime atacagı", "güvenillk", "kod=" + onaykodu);
                message.IsBodyHtml = true;
                SmtpClient smtpClient = new();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("mail atacak hesap", "emailşifresi gelcek");
                smtpClient.Send(message);
            }

            //TODO: Model success olmasa bile true dönüyor. Burada bir güncellemeye ihtiyaç var "bütün action resultlar için" notification yapısının kurulması ile ilgili bir task açmıştım, server hatalarını alıp ön yüze aktaracak yapı kurulmalı.. Model state kullanılabilir.
            //return Json(new { Success = true, Data = response });
            return Json( response);
        }



        [HttpPost]
        public IActionResult EmailCodeControl(EmailConfirmedDTO model)
        {
            var UserDto = GetCurrentUser();
            model.UserId = UserDto.Id;

            var result = _api.GetObjectResponseFromApi<EmailConfirmedDTO>(RestSharp.Method.POST, "/Individuals/EmailCodeControl" ,model, GetToken());

            return Json(result);
        }

    }
}
