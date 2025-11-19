using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Application.UseCases.Tasks.Update;
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

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateTask([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();
        useCase.Execute(id, request);

        return NoContent();
    }

}
