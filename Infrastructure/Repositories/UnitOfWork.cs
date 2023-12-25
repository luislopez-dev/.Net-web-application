using Business.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

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
    public IInvoiceProductRepository InvoiceProductRepository => new InvoiceProductRepository(_context);

    public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync() > 0;
    }
    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

    public IDbContextTransaction BeginTransaction(CancellationToken cancellationToken)
    {
        return _context.Database.BeginTransaction();
    }
}