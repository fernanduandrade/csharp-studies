using System;
using EmailValidation.Models;

namespace EmailValidation.Builders
{
    public class EmailV2Builder
    {
        private dynamic _evaDTO {get;set;}
        public EmailV2Builder(dynamic evaDTO)
        {
            _evaDTO = evaDTO;
        }

        public EmailV2 Build()
        {
            EmailV2 emailv2 = new EmailV2()
            {
                Email_Address = _evaDTO.email_address,
                Domain = _evaDTO.domain,
                Valid_Syntax = _evaDTO.valid_syntax,
                Disposable = _evaDTO.disposable,
                WebMail = _evaDTO.webmail,
                Deliverable = _evaDTO.deliverable,
                Catch_All = _evaDTO.catch_all,
                Gibberish = _evaDTO.gibberish,
                Spam = _evaDTO.spam,
                Created_At = DateTime.Now
            };

            return emailv2;
        }
    }
}