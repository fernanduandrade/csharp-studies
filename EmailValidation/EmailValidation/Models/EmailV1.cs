using System;

namespace EmailValidation.Models
{
    public class EmailV1
    {
        public int Id {get;set;}
        public string Email {get;set;}
        public string Domain {get;set;}
        public bool Valid_syntax {get; set;}
        public DateTime Created_At {get; set;}
    }
}