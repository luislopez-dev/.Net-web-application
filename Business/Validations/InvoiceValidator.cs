using System.Data;
using Business.Models;
using FluentValidation;

namespace Business.Validations;

public class InvoiceValidator: AbstractValidator<Invoice>
{
    public InvoiceValidator()
    {
        RuleFor(invoice => invoice.ClientName)
            .NotNull()
        .WithName("¡El nombre del cliente no debe estar vacio!");
        
        RuleFor(invoice => invoice.ClientAddress)
            .NotNull()
            .WithName("¡La dirección del cliente no debe estar vacia!");
        
        RuleFor(invoice => invoice.ClientNit)
            .NotNull()
            .WithName("¡El NIT del cliente no debe estar vacio!");
        
        RuleFor(invoice => invoice.Discount)
            .NotNull()
            .WithName("¡El descuento en la factura no debe estar vacio!");

        RuleFor(invoice => invoice.Total)
            .NotNull()
            .WithName("¡El total de la factura no debe estar vacio!");

        RuleFor(invoice => invoice.PaymentMethod)
            .NotNull()
            .WithName("!El método de pago no debe estar vacio¡");
    }
}