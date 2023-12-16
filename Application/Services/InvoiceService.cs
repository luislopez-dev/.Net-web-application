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

    public void AddInvoice(Invoice invoice)
    {
        _unitOfWork
            .InvoiceRepository
            .AddInvoice(invoice);
    }
    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await _unitOfWork
            .InvoiceRepository
            .GetInvoicesAsync();
    }
}