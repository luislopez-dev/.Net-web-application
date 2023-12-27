using FluentValidation.Results;

namespace Business.Exceptions;

public class ValidationException: Exception
{
    public List<ValidationFailure> ValidationFailures { get; }

    public ValidationException(List<ValidationFailure> validationFailures)
    {
        ValidationFailures = validationFailures;
    }
}