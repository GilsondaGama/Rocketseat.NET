using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;

public class ResponseRegisterTaskJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public DateTime DueDate { get; set; }
    public StatusType Status { get; set; }
}
