using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public void AddInvoice(Invoice invoice);
    public Task<List<Invoice>> GetInvoicesAsync();
}