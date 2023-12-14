using Business.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    public IProductRepository ProductRepository => new ProductRepository(_context);
    public IInvoiceRepository InvoiceRepository => new InvoiceRepository(_context);
    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}