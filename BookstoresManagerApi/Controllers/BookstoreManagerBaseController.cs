using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreManagerBaseController : ControllerBase
    {
        public string Author { get; set; } = "Gilson da Gama";
    }
}
