using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    public class DeviceController : MyFirstApiBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Author);
        }
    }
}
