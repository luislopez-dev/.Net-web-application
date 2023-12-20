using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Invoices Repository
/// </summary>
internal class InvoiceRepository: IInvoiceRepository
{
    private readonly DataContext _context;

    public InvoiceRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task AddInvoice(Invoice invoice)
    {
        await _context.AddAsync(invoice);
    }
    
    public async Task<List<Invoice>> GetInvoicesPaginatedAsync()
    {
       return await _context.Invoices
       .Include(invoice => invoice.InvoiceProducts)
       .ThenInclude(record => record.Product)
       .ToListAsync();
    }
}