using Application.Abstractions;
using Business.Interfaces;
using Business.Models;

namespace Application.Services;

public class InvoiceService: IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddInvoice(Invoice invoice, int[] selectedProducts)
    {
        invoice.Total = 10;
        invoice.Discount = 2;
        
        await _unitOfWork
            .InvoiceRepository
            .AddInvoice(invoice);
        
        await _unitOfWork.CompleteAsync();
        
        await _unitOfWork
                .InvoiceProductRepository
                .CreateRecordAsync(invoice.Id, selectedProducts);
    }
    public async Task<List<Invoice>> GetInvoicesPaginatedAsync()
    {
        return await _unitOfWork
            .InvoiceRepository
            .GetInvoicesPaginatedAsync();
    }
}