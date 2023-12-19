using Business.Interfaces;
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
        throw new NotImplementedException();
    }
}