/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using FluentValidation.Results;

namespace Business.Exceptions.Invoice.Exceptions.ValidationExceptions;

public class InvoiceValidationException: ValidationException
{
    public InvoiceValidationException(List<ValidationFailure> failures) : base(failures)
    {
    }
}