using Business.Models;

namespace Business.Interfaces;

public interface IInvoiceRepository
{
    public Task AddInvoice(Invoice invoice);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync();
}