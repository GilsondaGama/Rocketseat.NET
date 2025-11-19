using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestTaskJson request)
    {

        return new ResponseRegisterTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status
        };
    }
}
