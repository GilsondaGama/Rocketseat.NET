using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUser()
    {
        return Ok("User data");
    }
}

