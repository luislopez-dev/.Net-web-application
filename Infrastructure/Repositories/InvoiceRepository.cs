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
    
    /// <summary>
    /// Create a new invoice record in the db
    /// </summary>
    /// <param name="invoice"></param>
    public void AddInvoice(Invoice invoice)
    {
        _context.Add(invoice);
    }

    /// <summary>
    /// Returns all invoices through pagination 
    /// </summary>
    /// <returns></returns>
    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        var invoices = from n in _context.Invoices select n;
        return await invoices.ToListAsync();
    }
}