using Microsoft.AspNetCore.Mvc;


namespace EmailValidation.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HealthController : ControllerBase
    {
        public ActionResult Health()
        {
            var result = new
            {
                status = "ok",
                code = 200,
                results = new[] {
                    new{message = "Servidor executando na porta 8080"}
                }
            };

            return Ok(result);
        }
    }
}