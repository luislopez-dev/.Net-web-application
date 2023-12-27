/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class InvoiceProductRepository : IInvoiceProductRepository
{
    private readonly DataContext _context;
    
    public InvoiceProductRepository(DataContext context)
    {
        _context = context;
    }
    public async Task CreateRecordAsync(int invoiceId, int[] selectedProducts, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var productId in selectedProducts)
            {
                var record = new InvoiceProduct
                {
                    InvoiceId = invoiceId,
                    ProductId = productId
                };
                await _context.InvoiceProducts.AddAsync(record, cancellationToken);
            }
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}