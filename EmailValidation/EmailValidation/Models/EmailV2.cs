using System;

namespace EmailValidation.Models
{
    public class EmailV2
    {
        public int Id {get; set;}
        public string Email_Address {get; set;}
        public string Domain {get; set;}
        public bool Valid_Syntax {get; set;}
        public bool Disposable {get; set;}
        public bool WebMail {get; set;}
        public bool Deliverable {get; set;}
        public bool Catch_All {get; set;}
        public bool Gibberish {get; set;}
        public bool Spam {get; set;} 
        public DateTime Created_At {get; set;}
        
    }

    
}