using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator: AbstractValidator<Product> {
    
    public ProductValidator()
    {
        // Validations for Name attribute
        RuleFor(product => product.Name)
            .NotNull()
            .length(3, 60)
            .WithName("¡El nombre del producto no debe estar vacio!");
        
        // Validations for Price attribute
        RuleFor(product => product.Price)
            .NotNull()
            .WithName("¡El precio del producto no debe estar vacio!");
        
        // Validations for Description attribute
        RuleFor(product => product.Description)
            .NotNull()
            .WithName("¡La descripción del producto!");
            
        // Validations for Stock attribute
        RuleFor(product => product.Stock)
            .NotNull()
            .WithName("¡El stock del producto no debe estar vacio!");
    }
}