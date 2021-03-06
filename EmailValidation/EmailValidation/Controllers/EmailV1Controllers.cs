using Microsoft.AspNetCore.Mvc;
using EmailValidation.Repositories;
using System.Threading.Tasks;
using EmailValidation.Models;
using EmailValidation.Dtos;
using System.Collections.Generic;
using System;

namespace EmailValidation.Controllers
{
    [ApiController]
    [Route("/mail/validation/v1")]
    public class EmailV1Controllers : ControllerBase
    {
        private readonly IEmailV1Repository _emailV1Repository1;
        public EmailV1Controllers(IEmailV1Repository emailV1Repository)
        {
            _emailV1Repository1 = emailV1Repository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailV1>> GetEmail(int id)
        {
            var emailv1 = await _emailV1Repository1.Get(id);
            if(string.IsNullOrEmpty(emailv1.Id.ToString()))
                return NotFound();

            return Ok(emailv1);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailV1>>> GetEmailsV1()
        {
            var emailsv1 = await _emailV1Repository1.GetAll();
            return Ok(emailsv1);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmailV1(EmailV1Dto emailV1Dto)
        {
            EmailV1 emailV1 = new()
            {
                Email = emailV1Dto.Email,
                Domain = emailV1Dto.Domain,
                Valid_syntax = emailV1Dto.Valid_syntax,
                Created_At = DateTime.Now

            };

            

            await _emailV1Repository1.Add(emailV1);
            
            var result = new {
                status = "ok", 
                code = 200, 
                results = new[] 
                {
                    new {email_address = emailV1.Email,domain = emailV1.Domain,valid_syntax = emailV1.Valid_syntax}
                }
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmailV1(int id)
        {
            await _emailV1Repository1.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmailV1(int id, EmailV1Dto emailV1Dto)
        {
            EmailV1 email = new()
            {
                Id = id,
                Email = emailV1Dto.Email,
                Domain = emailV1Dto.Domain,
                Valid_syntax = emailV1Dto.Valid_syntax,
                Created_At = DateTime.Now
            };

            await _emailV1Repository1.Update(email);
            return Ok();
        }
    }
}