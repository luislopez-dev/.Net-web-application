using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public void AddInvoice(Invoice invoice, int[] selectedProducts);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync();
}