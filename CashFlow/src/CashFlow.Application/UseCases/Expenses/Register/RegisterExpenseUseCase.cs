using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        // to do validations and business rules

        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {        
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        if (DateTime.Compare(request.Date, DateTime.UtcNow) > 0)
        {
            throw new ArgumentException("Date cannot be in the future");
        }

        if (!Enum.IsDefined(typeof(PaymentType), request.PaymentType))
        {
            throw new ArgumentException("Invalid payment type");
        }
    }
}
