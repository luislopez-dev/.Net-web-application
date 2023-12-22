using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator: AbstractValidator<Product> {
    
    public ProductValidator()
    {
        // Validations for Name attribute
        RuleFor(product => product.Name)
            .NotNull()
            .Length(5, 60)
            .WithName("¡El nombre del producto no debe estar vacio!");
        
        // Validations for Price attribute
        RuleFor(product => product.Price)
            .NotNull()
            .InclusiveBetween(0.10, 100000)
            .WithName("¡El precio del producto no debe estar vacio!");
        
        // Validations for Description attribute
        RuleFor(product => product.Description)
            .NotNull()
            .Length(5, 900)
            .WithName("¡La descripción del producto!");
            
        // Validations for Stock attribute
        RuleFor(product => product.Stock)
            .NotNull()
            .InclusiveBetween(1, 1000000)
            .WithName("¡El stock del producto no debe estar vacio!");
    }
}