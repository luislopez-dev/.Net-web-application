using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class InvoiceRepository: IInvoiceRepository
{
    private readonly DataContext _context;

    public InvoiceRepository(DataContext context)
    {
        _context = context;
    }

    public void AddInvoice(Invoice invoice)
    {
        throw new NotImplementedException();
    }

    public void DeleteInvoice(Invoice invoice)
    {
        throw new NotImplementedException();
    }

    public void UpdateInvoice(Invoice invoice)
    {
        throw new NotImplementedException();
    }

    public Task<List<Invoice>> GetInvoices()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> GetInvoice()
    {
        throw new NotImplementedException();
    }
}