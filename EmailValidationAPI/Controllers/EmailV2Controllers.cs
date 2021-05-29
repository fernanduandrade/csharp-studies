using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using EmailValidation.Models;
using EmailValidation.Dtos;
using System.Collections.Generic;
using EmailValidation.Repositories;
using EmailValidation.Services;

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
        public async Task<ActionResult> CreateEmailV2(CreateEmailsv2Dto createEmailsv2Dto) 
        {
            EvaService eva = new EvaService(createEmailsv2Dto.Email_Address);
            
            dynamic evaDTO = eva.EvaRequest();

            EmailV2 emailv2 = new()
            {
                Email_Address = evaDTO.email_address,
                Domain = evaDTO.domain,
                Valid_Syntax = evaDTO.valid_syntax,
                Disposable = evaDTO.disposable,
                WebMail = evaDTO.webmail,
                Deliverable = evaDTO.deliverable,
                Catch_All = evaDTO.catch_all,
                Gibberish = evaDTO.gibberish,
                Spam = evaDTO.spam,
                Created_At = DateTime.Now
            };

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
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmailV2(int id)
        {
            await _emailV2Repository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmailV2(int id, UpdateEmailV2Dto updateEmailV2Dto)
        {
            EmailV2 email = new()
            {
                Id = id,
                Email_Address = updateEmailV2Dto.Email_Address,
                Domain = updateEmailV2Dto.Domain,
                Valid_Syntax = updateEmailV2Dto.Valid_Syntax,
                Disposable = updateEmailV2Dto.Disposable,
                WebMail = updateEmailV2Dto.WebMail,
                Deliverable = updateEmailV2Dto.Deliverable,
                Catch_All = updateEmailV2Dto.Catch_All,
                Gibberish = updateEmailV2Dto.Gibberish,
                Spam = updateEmailV2Dto.Spam,
                Created_At = DateTime.Now
            };

            await _emailV2Repository.Update(email);
            return Ok();
        }
    }
}