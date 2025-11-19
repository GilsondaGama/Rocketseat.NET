using TaskManager.Communication.Enums;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(Guid id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Name = "Sample Task",
            Description = "This is a sample task description.",
            Priority = PriorityType.medium,
            DueDate = DateTime.UtcNow.AddDays(7),
            Status = StatusType.inProgress
        };
    }
}
