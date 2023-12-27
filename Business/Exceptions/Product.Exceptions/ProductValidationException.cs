/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using FluentValidation.Results;

namespace Business.Exceptions.Product.Exceptions;

public class ProductValidationException: ValidationException
{
    public ProductValidationException(List<ValidationFailure> failures) : base(failures)
    {
    }
}