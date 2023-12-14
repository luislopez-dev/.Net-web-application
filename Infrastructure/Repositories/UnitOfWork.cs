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
    public Task<bool> Complete()
    {
        throw new NotImplementedException();
    }
    public bool HasChanges()
    {
        throw new NotImplementedException();
    }
}