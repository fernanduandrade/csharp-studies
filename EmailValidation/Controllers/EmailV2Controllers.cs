using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmailValidation.Utils;
using EmailValidation.Builders;
using EmailValidation.Models;
using EmailValidation.Dtos;
using System.Collections.Generic;
using EmailValidation.Repositories;
using EmailValidation.Services;
using System.Net;
using System.Net.Http;

namespace EmailValidation.Controllers
{
    [ApiController]
    [Route("/mail/validation/v2")]
    public class EmailV2Controllers : ControllerBase
    {
        private readonly IEmailV2Repository _emailV2Repository;
        public EmailV2Controllers(IEmailV2Repository emailV2)
        {
            _emailV2Repository = emailV2;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmailV2>> GetEmail(int id)
        {
            var emailv2 = await _emailV2Repository.Get(id);
            if(emailv2 == null)
                return NotFound();

            return Ok(emailv2);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailV2>>> GetEmailsV2()
        {
            var emailsv2 = await _emailV2Repository.GetAll();
            return Ok(emailsv2);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmailV2(EmailV2Dto emailV2Dto) 
        {
            EvaService eva = new EvaService(emailV2Dto.Email_Address);
            
            dynamic evaDTO = eva.EvaRequest();

            EmailV2Builder emailv2Builder = new EmailV2Builder(evaDTO);
            
            EmailV2 emailv2 = emailv2Builder.Build();
          
            await _emailV2Repository.Add(emailv2);
            
            // Ignora isso
            var result = new {
                status = "ok", 
                code = 200, 
                results = new[] 
                {
                    new {data = emailv2}
                }
            };
            GenerateLog logger = new GenerateLog();
            logger.WriteLog(new HttpResponseMessage(HttpStatusCode.OK).ToString());
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmailV2(int id)
        {
            await _emailV2Repository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmailV2(int id, EmailV2Dto emailV2Dto)
        {
            EmailV2 email = new()
            {
                Id = id,
                Email_Address = emailV2Dto.Email_Address,
                Domain = emailV2Dto.Domain,
                Valid_Syntax = emailV2Dto.Valid_Syntax,
                Disposable = emailV2Dto.Disposable,
                WebMail = emailV2Dto.WebMail,
                Deliverable = emailV2Dto.Deliverable,
                Catch_All = emailV2Dto.Catch_All,
                Gibberish = emailV2Dto.Gibberish,
                Spam = emailV2Dto.Spam,
                Created_At = DateTime.Now
            };

            await _emailV2Repository.Update(email);
            return Ok();
        }
    }
}