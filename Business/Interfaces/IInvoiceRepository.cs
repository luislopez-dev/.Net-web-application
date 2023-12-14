using Business.Models;

namespace Business.Interfaces;

public interface IInvoiceRepository
{
    public void AddInvoice(Invoice invoice);
    public Task<List<Invoice>> GetInvoicesAsync();
}