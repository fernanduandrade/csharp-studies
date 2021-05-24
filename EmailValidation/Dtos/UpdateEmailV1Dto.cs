using EmailValidation.Utils;

namespace EmailValidation.Dtos
{
    public class UpdateEmailV1Dto
    {
        public string Email {get; set;}
        public string Domain {get; set;}
        public bool Valid_syntax {get => ValidEmail.IsValid(Email);}
    }
}