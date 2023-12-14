using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class OrderValidator: AbstractValidator<Order>
{
    public OrderValidator()
    {
    }
}