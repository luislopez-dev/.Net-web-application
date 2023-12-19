using Business.Interfaces;
using Business.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

internal class InvoiceProductRepository : IInvoiceProductRepository
{
    private readonly DataContext _context;

    public InvoiceProductRepository(DataContext context)
    {
        _context = context;
    }
    public void CreateRecord(int invoiceId, int[] selectedProducts)
    {
        foreach (var productId in selectedProducts)
        {
            var record = new InvoiceProduct
            {
                InvoiceId = invoiceId,
                ProductId = productId
            };
            _context.InvoiceProducts.Add(record);
        }
    }
}