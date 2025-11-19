using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTaskJson Execute()
    {
        return new ResponseAllTaskJson
        {
            Tasks = new List<ResponseShortTaskJson>
            {
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 1"
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 2"
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 3"
                }
            }
        };
    }
}
