using System.Data;
using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotNull()
            .WithName("¡El nombre del producto no debe estar vacio!");
        
        RuleFor(product => product.Price)
            .NotNull()
            .WithName("¡El precio del producto no debe estar vacio!");
        
        RuleFor(product => product.Description)
            .NotNull()
            .WithName("¡La descripción del producto!");
        
        RuleFor(product => product.Stock)
            .NotNull()
            .WithName("¡El stock del producto no debe estar vacio!");
    }
}