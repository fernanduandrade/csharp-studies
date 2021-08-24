using System.Linq;

namespace EmailValidation.Utils
{
    public class ValidEmail
    {
        public static bool IsValid(string email)
        {
            string[] valid_emails = {".com", ".com.br", ".gov", ".org"};

            return valid_emails.Any(element => email.Contains(element));
        }
    }
}