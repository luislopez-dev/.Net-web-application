/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class InvoiceValidator: AbstractValidator<Invoice>
{
    public InvoiceValidator()
    {
        RuleFor(invoice => invoice.ClientName)
            .NotNull().WithMessage("¡El nombre del cliente no debe estar vacio!")
            .Length(5, 70).WithMessage("El nombre del cliente debe tener entre 5 a 70 caracteres");
        
        RuleFor(invoice => invoice.ClientAddress)
            .NotNull().WithMessage("¡La dirección del cliente no debe estar vacia!")
            .Length(20, 400).WithMessage("El nombre del cliente debe tener entre 5 a 400 caracteres");
        
        RuleFor(invoice => invoice.ClientNit)
            .NotNull().WithMessage("¡El NIT del cliente no debe estar vacio!")
            .Length(8).WithMessage("El NIT debe tener 8 caracteres");

        RuleFor(invoice => invoice.Discount)
            .NotNull().WithMessage("¡El descuento en la factura no debe estar vacio!")
            .InclusiveBetween(0, 1000000).WithMessage("¡La cifra del descuento en la factura debe estar entre 0 y un millón!");

        RuleFor(invoice => invoice.Total)
            .NotNull().WithMessage("¡El total de la factura no debe estar vacio!")
            .InclusiveBetween(0, 1000000).WithMessage("¡La cifra del total en la factura debe estar entre 0 y un millón!");
    }
}