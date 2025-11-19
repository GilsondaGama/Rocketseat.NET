using System.ComponentModel.DataAnnotations;

namespace TaskManager.Communication.Validators;

public class DateNotPastAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
            return true;

        var date = (DateTime)value;

        return date.Date >= DateTime.UtcNow.Date;
    }
}
