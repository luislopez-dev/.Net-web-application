using Business.Exceptions.Invoice.Exceptions.DatabaseExceptions;
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
    
    public async Task AddInvoice(Invoice invoice, CancellationToken cancellationToken)
    {    
        cancellationToken.ThrowIfCancellationRequested();
        
        try
        {
            await _context.AddAsync(invoice, cancellationToken);
        }
        catch (CreateInvoiceException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<List<Invoice>> GetInvoicesPaginatedAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _context.Invoices
                .Include(invoice => invoice.InvoiceProducts)
                .ThenInclude(record => record.Product)
                .ToListAsync(cancellationToken);
        }
        catch (GetInvoicesException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}