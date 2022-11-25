using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("appsettings")]
    public class AppSettingsController : Controller
    {
        protected readonly IConfiguration _configuration;

        public AppSettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       /// [Route("first-way")]
        //public IActionResult FirstWay()
        //{
        //    //return Content(_configuration.GetSection("RoundTheCodeSync").GetChildren().FirstOrDefault());
        //}
    }
}
