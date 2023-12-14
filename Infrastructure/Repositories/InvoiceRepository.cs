using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        _context.Add(invoice);
    }

    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        var invoices = from n in _context.Invoices select n;
        return await invoices.ToListAsync();
    }
}