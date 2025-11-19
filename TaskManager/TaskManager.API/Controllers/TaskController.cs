using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]

    public IActionResult RegisterTask([FromBody] RequestTaskJson request)
    {
        var useCase = new RegisterTaskUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
