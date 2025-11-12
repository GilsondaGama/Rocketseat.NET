using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiBaseController : ControllerBase
    {
        public string Author { get; set; } = "Gilson da Gama";
    }
}
