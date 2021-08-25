using EmailValidation.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace EmailValidationTest
{
    public class HealthControllerTest
    {
        [Fact]
        public async Task HealthTest()
        {
            var controller = new HealthController();
            
            IActionResult actionResult = controller.Health();

            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            var model = Assert.IsType<HealthController>(okObjectResult.Value);
            Assert.Equal(controller, model);
        }



    }
}
