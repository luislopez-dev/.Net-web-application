using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class ProductValidator: AbstractValidator<Product> {
    
    public ProductValidator()
    {
        // Validations for Name attribute
        RuleFor(product => product.Name)
            .NotNull()
            .WithName("¡El nombre del producto no debe estar vacio!");
            .Length(5, 60)
        
        // Validations for Price attribute
        RuleFor(product => product.Price)
            .NotNull()
            .WithName("¡El precio del producto no debe estar vacio!");
            .InclusiveBetween(0.10, 100000)
        
        // Validations for Description attribute
        RuleFor(product => product.Description)
            .NotNull()
            .WithName("¡La descripción del producto no debe estar vacia!");
            .Length(5, 900)
            
            
        // Validations for Stock attribute
        RuleFor(product => product.Stock)
            .NotNull()
            .WithName("¡El stock del producto no debe estar vacio!");
            .InclusiveBetween(1, 1000000)
    }
}