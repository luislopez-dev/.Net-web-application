using FluentValidation.Results;

namespace Business.Exceptions.Product.Exceptions.ValidationExceptions;

public class ProductValidationException: ValidationException
{
    public ProductValidationException(List<ValidationFailure> failures) : base(failures)
    {
    }
}