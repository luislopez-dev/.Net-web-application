using Application.Abstractions;
using Business.Interfaces;
using Business.Models;

namespace Application.Services;

internal class InvoiceService: IInvoiceService
{
    private readonly IServiceManager _serviceManager;

    public InvoiceService(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    public void AddInvoice(Invoice invoice)
    {
        _serviceManager
            .InvoiceService
            .AddInvoice(invoice);
    }
    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await _serviceManager
            .InvoiceService
            .GetInvoicesAsync();
    }
}