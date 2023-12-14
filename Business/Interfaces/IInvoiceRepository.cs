using Business.Models;

namespace Business.Interfaces;

public interface IInvoiceRepository
{
    public void AddInvoice(Invoice invoice);
    public void DeleteInvoice(Invoice invoice);
    public void UpdateInvoice(Invoice invoice);
    public Task<List<Invoice>> GetInvoices();
    public Task<Invoice> GetInvoice();
}