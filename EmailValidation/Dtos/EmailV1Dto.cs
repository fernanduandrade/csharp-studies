using EmailValidation.Utils;

namespace EmailValidation.Dtos
{
    public class EmailV1Dto
    {
        public string Email {get; set;}
        public string Domain {get; set;}
        public bool Valid_syntax {get => ValidEmail.IsValid(Email);}
    }
}