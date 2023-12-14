using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public void AddInvoice(Invoice invoice);
    public void DeleteInvoice(Invoice invoice);
    public void UpdateInvoice(Invoice invoice);
    public Task GetInvoices();
    public Task<Invoice> GetInvoice();
}