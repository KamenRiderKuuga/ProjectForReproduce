using Microsoft.AspNetCore.Mvc;

namespace GetValueFromRequestHeader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return string.Empty;
        }
    }
}
