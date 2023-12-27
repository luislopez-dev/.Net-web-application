using FluentValidation.Results;

namespace Business.Exceptions.Invoice.Exceptions.ValidationExceptions;

public class InvoiceValidationException: ValidationException
{
    public InvoiceValidationException(List<ValidationFailure> failures) : base(failures)
    {
    }
}