using Microsoft.AspNetCore.Mvc;


namespace EmailValidation.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult Health()
        {
            var result = new
            {
                status = "ok",
                code = 200,
                error = false,
                list = false,
                results = new[] {
                    new{message = "Servidor executando na porta 5000"}
                }
            };

            return Ok(result);
        }
    }
}