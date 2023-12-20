using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public Task AddInvoice(Invoice invoice, int[] selectedProducts);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync();
}