using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using MyFirstAPI.Communication.Requests;
using MyFirstAPI.Communication.Responses;

namespace MyFirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromHeader] int id, [FromHeader] string? nickname)
    {
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Age = 30
        };

        return Ok(Response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RequestRegisterUserJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterUserJson request)
    {
        var response = new RequestRegisterUserJson
        {
            Id = 1,
            Name = request.Name,
            Email = request.Email,
        };

        return Created(string.Empty, response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromBody] RequestUpdateUserProfileJson request)
    {
        return NoContent();
    }

    [HttpDelete]    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete()
    {
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "John Doe",
                Age = 30
            },
            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Age = 25
            }
        };
        return Ok(response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }
}



