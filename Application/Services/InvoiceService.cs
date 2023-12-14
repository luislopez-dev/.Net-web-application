using Application.Abstractions;
using Business.Interfaces;
using Business.Models;

namespace Application.Services;

public class InvoiceService: IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    public void AddInvoice(Invoice invoice)
    {
        _invoiceRepository.AddInvoice(invoice);
    }

    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await _invoiceRepository.GetInvoicesAsync();
    }
}