using System.ComponentModel.DataAnnotations;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Validators;

namespace TaskManager.Communication.Requests;

public class RequestTaskJson
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public PriorityType Priority { get; set; }

    [DateNotPast(ErrorMessage = "A data limite não pode estar no passado.")]
    public DateTime DueDate { get; set; }

    [EnumDataType(typeof(StatusType), ErrorMessage = "Status inválido. Use: pending, inProgress ou completed.")]
    public StatusType Status { get; set; }

}
