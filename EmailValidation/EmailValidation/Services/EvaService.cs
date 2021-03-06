using RestSharp;
using Newtonsoft.Json.Linq;

namespace EmailValidation.Services
{
    public class EvaService
    {
        private string _email;
        public EvaService(string email)
        {
            _email = email;
        }

        public dynamic EvaRequest()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://api.eva.pingutil.com/email?email={_email}");
            IRestResponse response = client.Get(request);
            
            dynamic result = JObject.Parse(response.Content);
            
            return result.data;

        }

    }

    

 
}