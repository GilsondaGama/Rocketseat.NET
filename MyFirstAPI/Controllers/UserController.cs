using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

    public IActionResult GetUser([FromHeader] int id, [FromHeader] string? nickname)
    {
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Age = 30
        };

        return Ok(Response);
    }
}

