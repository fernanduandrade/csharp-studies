using Microsoft.AspNetCore.Mvc;

namespace EmailValidation.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            var result = new {
                status = "ok",
                code = 200,
                results = new[] {
                    new{}
                }
            };

            return Ok(result);
        }
    }
}