using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
    }
}