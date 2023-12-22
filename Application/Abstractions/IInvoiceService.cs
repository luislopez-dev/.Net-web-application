using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public Task AddInvoiceAsync(Invoice invoice, int[] selectedProducts);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync();
}